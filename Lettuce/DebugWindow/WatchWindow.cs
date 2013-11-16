using System;
using System.Drawing;
using System.Windows.Forms;
using Tomato;
using Tomato.Hardware;

namespace Lettuce
{
	public partial class WatchWindow : Form
	{
		public ListView WatchesList
		{
			get;
			private set;
		}

		public Debugger Debugger
		{
			get;
			set;
		}

		public DCPU CPU
		{
			get;
			set;
		}

		private TextBox m_editBox;

		public WatchWindow()
		{
			InitializeComponent();
			WatchesList = watchesListView;

			m_editBox = new TextBox();
			m_editBox.KeyDown += EditBoxOnKeyDown;

			if( Program.Configuration.WindowSizes.ContainsKey( "watchWindow" ) )
				this.Size = Program.Configuration.WindowSizes["watchWindow"];
			if( Program.Configuration.WindowPositions.ContainsKey( "watchWindow" ) )
			{
				this.StartPosition = FormStartPosition.Manual;
				this.Location = Program.Configuration.WindowPositions["watchWindow"];
			}
		}

		public void UpdateWatches()
		{
			watchesListView.Items.Clear();
			foreach( var watch in Debugger.Watches )
			{
				var item = new ListViewItem( watch );
				try
				{
					item.SubItems.Add( "0x" + Watch.Evaluate( watch, CPU ).ToString( "X4" ) );
				} catch( Exception e )
				{
					item.SubItems.Add( e.Message );
				}
				watchesListView.Items.Add( item );
			}
		}

		private void removeWatchToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if( watchesListView.SelectedIndices.Count != 0 )
				Debugger.Watches.RemoveAt( watchesListView.SelectedIndices[0] );
			Debugger.ResetLayout();
		}

		private void addWatchButton_Click( object sender, EventArgs e )
		{
			Debugger.Watches.Add( watchTextBox.Text );
			watchTextBox.Text = string.Empty;
			Debugger.ResetLayout();
		}

		private void watchesContextMenuStrip_Opening( object sender, System.ComponentModel.CancelEventArgs e )
		{
			if( watchesListView.SelectedIndices.Count == 0 )
				e.Cancel = true;
		}

		private void watchTextBox_KeyUp( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.Enter )
				addWatchButton_Click( sender, e );
		}

		private void WatchWindow_FormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = true;
			this.Hide();

			Program.Configuration.WindowSizes["watchWindow"] = this.Size;
			Program.Configuration.WindowPositions["watchWindow"] = this.Location;
		}

		private void WatchWindow_Shown( object sender, EventArgs e )
		{
			this.Icon = Debugger.Icon;
		}

		private void watchesListView_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			if( watchesListView.SelectedIndices.Count == 0 )
				return;
			if( this.Controls.Contains( m_editBox ) )
			{
				SetWatch();
				this.Controls.Remove( m_editBox );
			}

			ListViewItem watch = watchesListView.SelectedItems[0];

			m_editBox.Text = watch.Text;
			m_editBox.Tag = watch.Index;
			m_editBox.Location = new Point( watch.Position.X + watchesListView.Location.X + 1,
											watch.Position.Y + watchesListView.Location.Y + 1 );
			m_editBox.Size = new Size( watchesListView.Columns[0].Width - watch.Position.X, watch.Bounds.Height );

			this.Controls.Add( m_editBox );
			m_editBox.BringToFront();

			Debugger.ResetLayout();
		}

		private void watchesListView_MouseClick( object sender, MouseEventArgs e )
		{
			if( this.Controls.Contains( m_editBox ) )
			{
				SetWatch();
				this.Controls.Remove( m_editBox );
			}
		}

		private void SetWatch()
		{
			if ( m_editBox == null || m_editBox.Tag == null )
				return;

			int index = (int)m_editBox.Tag;

			if ( string.IsNullOrEmpty( m_editBox.Text ) )
				watchesListView.Items.RemoveAt( index );

			watchesListView.Items[index].Text = m_editBox.Text;
			Debugger.Watches[index] = m_editBox.Text;

			Debugger.ResetLayout();
		}

		private void EditBoxOnKeyDown( object sender, KeyEventArgs keyEventArgs )
		{
			if ( keyEventArgs.Control || keyEventArgs.Alt )
			{
				keyEventArgs.SuppressKeyPress = true;
				keyEventArgs.Handled = true;
				return;
			}
			if ( keyEventArgs.KeyCode == Keys.Enter )
			{
				SetWatch();
				this.Controls.Remove( m_editBox );
				this.Invalidate();
			}
		}
	}
}
