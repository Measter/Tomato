using System;
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

		public WatchWindow()
		{
			InitializeComponent();
			WatchesList = watchesListView;

			

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
	}
}
