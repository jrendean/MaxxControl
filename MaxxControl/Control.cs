#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

#endregion

namespace MaxxControl
{
	/// <summary>
	/// Summary description for Control.
	/// </summary>
	public class ControlMain : System.Windows.Forms.Form
	{
		/// <summary>
		/// Main menu for the form.
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemAllStop = new System.Windows.Forms.MenuItem();
            this.menuItemController = new System.Windows.Forms.MenuItem();
            this.menuItemWheels = new System.Windows.Forms.MenuItem();
            this.menuItemArms = new System.Windows.Forms.MenuItem();
            this.menuItemWrist = new System.Windows.Forms.MenuItem();
            this.menuItemClaw = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentControl = new System.Windows.Forms.Label();
            this.listViewControls = new System.Windows.Forms.ListView();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemAllStop);
            this.mainMenu1.MenuItems.Add(this.menuItemController);
            // 
            // menuItemAllStop
            // 
            this.menuItemAllStop.Text = "All Stop";
            this.menuItemAllStop.Click += new System.EventHandler(this.menuItemAllStop_Click);
            // 
            // menuItemController
            // 
            this.menuItemController.MenuItems.Add(this.menuItemWheels);
            this.menuItemController.MenuItems.Add(this.menuItemArms);
            this.menuItemController.MenuItems.Add(this.menuItemWrist);
            this.menuItemController.MenuItems.Add(this.menuItemClaw);
            this.menuItemController.MenuItems.Add(this.menuItemExit);
            this.menuItemController.MenuItems.Add(this.menuItem1);
            this.menuItemController.MenuItems.Add(this.menuItem2);
            this.menuItemController.Text = "Controller";
            // 
            // menuItemWheels
            // 
            this.menuItemWheels.Text = "Wheels";
            this.menuItemWheels.Click += new System.EventHandler(this.ControlParts);
            // 
            // menuItemArms
            // 
            this.menuItemArms.Text = "Arms";
            this.menuItemArms.Click += new System.EventHandler(this.ControlParts);
            // 
            // menuItemWrist
            // 
            this.menuItemWrist.Text = "Wrist";
            this.menuItemWrist.Click += new System.EventHandler(this.ControlParts);
            // 
            // menuItemClaw
            // 
            this.menuItemClaw.Text = "Claw";
            this.menuItemClaw.Click += new System.EventHandler(this.ControlParts);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.Text = "Controlling:";
            // 
            // labelCurrentControl
            // 
            this.labelCurrentControl.Location = new System.Drawing.Point(96, 0);
            this.labelCurrentControl.Name = "labelCurrentControl";
            this.labelCurrentControl.Size = new System.Drawing.Size(80, 22);
            // 
            // listViewControls
            // 
            this.listViewControls.Location = new System.Drawing.Point(0, 49);
            this.listViewControls.Name = "listViewControls";
            this.listViewControls.Size = new System.Drawing.Size(176, 131);
            this.listViewControls.TabIndex = 2;
            this.listViewControls.View = System.Windows.Forms.View.List;
            this.listViewControls.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Red";
            this.menuItem1.Click += new System.EventHandler(this.ControlParts);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Green";
            this.menuItem2.Click += new System.EventHandler(this.ControlParts);
            // 
            // ControlMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 266);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCurrentControl);
            this.Controls.Add(this.listViewControls);
            this.Menu = this.mainMenu1;
            this.Name = "ControlMain";
            this.Text = "Control";
            this.ResumeLayout(false);

		}

		#endregion

		private MenuItem menuItemAllStop;
		private MenuItem menuItemController;
		private MenuItem menuItemWheels;
		private MenuItem menuItemArms;
		private MenuItem menuItemWrist;
		private MenuItem menuItemClaw;
		private Label label1;
		private Label labelCurrentControl;
		private ListView listViewControls;
		private MenuItem menuItemExit;
        private MenuItem menuItem1;
        private MenuItem menuItem2;


		private Connector connection;

		public ControlMain(Connector connection)
		{
			this.connection = connection;
			InitializeComponent();
		}


		private void menuItemAllStop_Click(object sender, EventArgs e)
		{
			connection.Write("h");
		}

		private void ControlParts(object sender, EventArgs e)
		{
			string control = (sender as MenuItem).Text;
			labelCurrentControl.Text = control;

			switch (control)
			{
				case "Wheels":
					listViewControls.Items.Clear();
					listViewControls.Items.Add(new ListViewItem("2 - Forward"));
					listViewControls.Items.Add(new ListViewItem("4 - Left"));
					listViewControls.Items.Add(new ListViewItem("6 - Right"));
					listViewControls.Items.Add(new ListViewItem("8 - Backward"));
					break;

				case "Arms":
					listViewControls.Items.Clear();
					listViewControls.Items.Add(new ListViewItem("2 - Up"));
					listViewControls.Items.Add(new ListViewItem("8 - Down"));
					break;

				case "Wrist":
					listViewControls.Items.Clear();
					listViewControls.Items.Add(new ListViewItem("2 - Away"));
					listViewControls.Items.Add(new ListViewItem("8 - Towards"));
					break;

				case "Claw":
					listViewControls.Items.Clear();
					listViewControls.Items.Add(new ListViewItem("4 - Rotate"));
					listViewControls.Items.Add(new ListViewItem("6 - Open/Close"));
					break;
			}


		}

		private void KeyPress(object sender, KeyPressEventArgs e)
		{
			string dataToWrite = String.Empty;

			switch (labelCurrentControl.Text)
			{
				case "Wheels":
					dataToWrite = "w:";
					if (e.KeyChar == '2')
						dataToWrite += "f";
					else if (e.KeyChar == '4')
						dataToWrite += "l";
					else if (e.KeyChar == '6')
						dataToWrite += "r";
					else if (e.KeyChar == '8')
						dataToWrite += "b";
					break;

				case "Arms":
					dataToWrite = "a:";
					if (e.KeyChar == '2')
						dataToWrite += "u";
					else if (e.KeyChar == '8')
						dataToWrite += "d";

					break;

				case "Wrist":
					dataToWrite = "r:";
					if (e.KeyChar == '2')
						dataToWrite += "a";
					else if (e.KeyChar == '8')
						dataToWrite += "t";
					break;

				case "Claw":
					dataToWrite = "c:";
					if (e.KeyChar == '4')
						dataToWrite += "r";
					else if (e.KeyChar == '6')
						dataToWrite += "o";
					break;

                case "Red":
                    dataToWrite = "r";
                    if (e.KeyChar == '4')
                        dataToWrite += "1";
                    else if (e.KeyChar == '6')
                        dataToWrite += "0";
                    break;
                case "Green":
                    dataToWrite = "g";
                    if (e.KeyChar == '4')
                        dataToWrite += "1";
                    else if (e.KeyChar == '6')
                        dataToWrite += "0";
                    break;
			}
			
			if (dataToWrite != String.Empty)
				connection.Write(dataToWrite);
		}

		private void ControlMain_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void menuItemExit_Click(object sender, EventArgs e)
		{
			menuItemAllStop_Click(sender, e);

			this.Close();
        }
	}
}
