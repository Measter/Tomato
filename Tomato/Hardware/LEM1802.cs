using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing.Design;

namespace Tomato.Hardware
{
	public class LEM1802 : Device
	{
		public LEM1802()
		{
			if( DefaultFont == null )
			{
				Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream( "Tomato.DefaultFont.dat" );
				DefaultFont = new ushort[stream.Length / 2];
				for( int i = 0; i < DefaultFont.Length; i++ )
				{
					byte left = (byte)stream.ReadByte();
					byte right = (byte)stream.ReadByte();
					ushort value = (ushort)( right | ( left << 8 ) );
					DefaultFont[i] = value;
				}
			}
			timer = new Timer( ToggleBlinker, null, BlinkRate, BlinkRate );
		}

		Timer timer;
		private void ToggleBlinker( object o )
		{
			BlinkOn = !BlinkOn;
		}

		[Category( "Device Information" )]
		public const int Width = 128;
		[Category( "Device Information" )]
		public const int Height = 96;
		[Category( "Device Information" )]
		public const int CharWidth = 4;
		[Category( "Device Information" )]
		public const int CharHeight = 8;
		/// <summary>
		/// The rate at which blinking characters should blink
		/// </summary>
		[Browsable( false )]
		public static int BlinkRate = 1000;
		[Browsable( false )]
		private bool BlinkOn = true;

		[Category( "Device Status" )]
		[TypeConverter( typeof( HexTypeEditor ) )]
		public ushort ScreenMap
		{
			get;
			set;
		}

		[Category( "Device Status" )]
		[TypeConverter( typeof( HexTypeEditor ) )]
		public ushort FontMap
		{
			get;
			set;
		}

		[Category( "Device Status" )]
		[TypeConverter( typeof( HexTypeEditor ) )]
		public ushort PaletteMap
		{
			get;
			set;
		}

		[Category( "Device Status" )]
		public ushort BorderColorValue
		{
			get;
			set;
		}

		[Browsable( false )]
		public Color BorderColor
		{
			get
			{
				return GetPaletteColor( (byte)BorderColorValue );
			}
		}

		/// <summary>
		/// Gets an image of the screen, without the border.
		/// </summary>
		[Browsable( false )]
		public unsafe Bitmap ScreenImage
		{
			get
			{
				UnsafeBitmap screen = new UnsafeBitmap( Width, Height );
				if( ScreenMap == 0 )
					return screen.Bitmap;

				screen.LockBitmap();
				ushort address = 0;
				for( int y = 0; y < 12; y++ )
					for( int x = 0; x < 32; x++ )
					{
						ushort value = AttachedCPU.Memory[ScreenMap + address];
						uint fontValue;
						if( FontMap == 0 )
							fontValue = (uint)( ( DefaultFont[( value & 0x7F ) * 2] << 16 ) | DefaultFont[( value & 0x7F ) * 2 + 1] );
						else
							fontValue = (uint)( ( AttachedCPU.Memory[FontMap + ( ( value & 0x7F ) * 2 )] << 16 ) | AttachedCPU.Memory[FontMap + ( ( value & 0x7F ) * 2 ) + 1] );
						fontValue = BitConverter.ToUInt32( BitConverter.GetBytes( fontValue ).Reverse().ToArray(), 0 );

						Color background = GetPaletteColor( (byte)( ( value & 0xF00 ) >> 8 ) );
						Color foreground = GetPaletteColor( (byte)( ( value & 0xF000 ) >> 12 ) );
						PixelData forPixel = PixelData.FromColor( foreground );
						PixelData backPixel = PixelData.FromColor( background );
						for( int i = 0; i < sizeof( uint ) * 8; i++ )
						{
							if( ( fontValue & 1 ) == 0 || ( ( ( value & 0x80 ) == 0x80 ) && !BlinkOn ) )
								screen.SetPixel( i / 8 + ( x * CharWidth ), i % 8 + ( y * CharHeight ), backPixel );
							else
								screen.SetPixel( i / 8 + ( x * CharWidth ), i % 8 + ( y * CharHeight ), forPixel );
							fontValue >>= 1;
						}
						address++;
					}

				screen.UnlockBitmap();
				return screen.Bitmap;
			}
		}

		[Category( "Device Information" )]
		[TypeConverter( typeof( HexTypeEditor ) )]
		public override uint DeviceID
		{
			get
			{
				return 0x7349f615;
			}
		}

		[Category( "Device Information" )]
		[TypeConverter( typeof( HexTypeEditor ) )]
		public override uint ManufacturerID
		{
			get
			{
				return 0x1c6c8b36;
			}
		}

		[Category( "Device Information" )]
		[TypeConverter( typeof( HexTypeEditor ) )]
		public override ushort Version
		{
			get
			{
				return 0x1802;
			}
		}

		[Browsable( false )]
		public override string FriendlyName
		{
			get
			{
				return "LEM 1802 Screen";
			}
		}

		public override int HandleInterrupt()
		{
			switch( AttachedCPU.A )
			{
				case 0x00:
					ScreenMap = AttachedCPU.B;
					break;
				case 0x01:
					FontMap = AttachedCPU.B;
					break;
				case 0x02:
					PaletteMap = AttachedCPU.B;
					break;
				case 0x03:
					BorderColorValue = (ushort)( AttachedCPU.B & 0xF );
					break;
				case 0x04:
					Array.Copy( DefaultFont, 0, AttachedCPU.Memory, AttachedCPU.B, DefaultFont.Length );
					return 256;
				case 0x05:
					Array.Copy( DefaultPalette, 0, AttachedCPU.Memory, AttachedCPU.B, DefaultPalette.Length );
					return 16;
			}
			return 0;
		}

		public Color GetPaletteColor( byte value )
		{
			ushort color;
			if( PaletteMap == 0 )
				color = DefaultPalette[value & 0xF];
			else
				color = AttachedCPU.Memory[PaletteMap + ( value & 0xF )];

			byte r, g, b;
			b = (byte)( color & 0xF );
			b |= (byte)( b << 4 );
			g = (byte)( ( color & 0xF0 ) >> 4 );
			g |= (byte)( g << 4 );
			r = (byte)( ( color & 0xF00 ) >> 8 );
			r |= (byte)( r << 4 );

			return Color.FromArgb(
				255, r, g, b
				);
		}

		public override void Reset()
		{
			ScreenMap = FontMap = PaletteMap = 0;
			BorderColorValue = 0;
		}

		#region Default Values

		private static ushort[] DefaultPalette = 
        {
            0x000,0x00A,0x0A0,0x0AA,0xA00,0xA0A,0xA50,0xAAA,0x555,0x55F,0x5F5,0x5FF,0xF55,0xF5F,0xFF5,0xFFF
        };

		private static ushort[] DefaultFont;

		#endregion

		#region Fast Bitmap

		public unsafe class UnsafeBitmap
		{
			Bitmap bitmap;

			// three elements used for MakeGreyUnsafe
			int width;
			BitmapData bitmapData = null;
			Byte* pBase = null;

			public UnsafeBitmap( Bitmap bitmap )
			{
				this.bitmap = new Bitmap( bitmap );
			}

			public UnsafeBitmap( int width, int height )
			{
				this.bitmap = new Bitmap( width, height, PixelFormat.Format24bppRgb );
			}

			public void Dispose()
			{
				bitmap.Dispose();
			}

			public Bitmap Bitmap
			{
				get
				{
					return ( bitmap );
				}
			}

			private Point PixelSize
			{
				get
				{
					GraphicsUnit unit = GraphicsUnit.Pixel;
					RectangleF bounds = bitmap.GetBounds( ref unit );

					return new Point( (int)bounds.Width, (int)bounds.Height );
				}
			}

			public void LockBitmap()
			{
				GraphicsUnit unit = GraphicsUnit.Pixel;
				RectangleF boundsF = bitmap.GetBounds( ref unit );
				Rectangle bounds = new Rectangle( (int)boundsF.X,
			   (int)boundsF.Y,
			   (int)boundsF.Width,
			   (int)boundsF.Height );

				// Figure out the number of bytes in a row
				// This is rounded up to be a multiple of 4
				// bytes, since a scan line in an image must always be a multiple of 4 bytes
				// in length. 
				width = (int)boundsF.Width * sizeof( PixelData );
				if( width % 4 != 0 )
				{
					width = 4 * ( width / 4 + 1 );
				}
				bitmapData =
			   bitmap.LockBits( bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

				pBase = (Byte*)bitmapData.Scan0.ToPointer();
			}

			public PixelData GetPixel( int x, int y )
			{
				PixelData returnValue = *PixelAt( x, y );
				return returnValue;
			}

			public void SetPixel( int x, int y, PixelData colour )
			{
				PixelData* pixel = PixelAt( x, y );
				*pixel = colour;
			}

			public void UnlockBitmap()
			{
				bitmap.UnlockBits( bitmapData );
				bitmapData = null;
				pBase = null;
			}
			public PixelData* PixelAt( int x, int y )
			{
				return (PixelData*)( pBase + y * width + x * sizeof( PixelData ) );
			}
		}

		public struct PixelData
		{
			public byte blue;
			public byte green;
			public byte red;

			public static PixelData FromColor( Color color )
			{
				return new PixelData()
				{
					red = color.R,
					green = color.G,
					blue = color.B
				};
			}
		}

		#endregion
	}
}
