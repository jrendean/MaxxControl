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
	/// Summary description for Connect.
	/// </summary>
	public class Connect : System.Windows.Forms.Form
	{
		private MenuItem menuItemConnect;
		private MenuItem menuItemExit;
		private Label label1;
		private ComboBox comboBoxCOMPort;
		private Label labelError;
		/// <summary>
		/// Main menu for the form.
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;

		public Connect()
		{
			InitializeComponent();
		}

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
			this.menuItemConnect = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
			this.labelError = new System.Windows.Forms.Label();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItemConnect);
			this.mainMenu1.MenuItems.Add(this.menuItemExit);
			// 
			// menuItemConnect
			// 
			this.menuItemConnect.Text = "Connect";
			this.menuItemConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Text = "Exit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Size = new System.Drawing.Size(82, 22);
			this.label1.Text = "COM Port:";
			// 
			// comboBoxCOMPort
			// 
			this.comboBoxCOMPort.Items.Add("1");
			this.comboBoxCOMPort.Items.Add("2");
			this.comboBoxCOMPort.Items.Add("3");
			this.comboBoxCOMPort.Items.Add("4");
			this.comboBoxCOMPort.Items.Add("5");
			this.comboBoxCOMPort.Items.Add("6");
			this.comboBoxCOMPort.Items.Add("7");
			this.comboBoxCOMPort.Items.Add("8");
			this.comboBoxCOMPort.Location = new System.Drawing.Point(91, 10);
			this.comboBoxCOMPort.Size = new System.Drawing.Size(55, 24);
			// 
			// labelError
			// 
			this.labelError.ForeColor = System.Drawing.Color.Red;
			this.labelError.Location = new System.Drawing.Point(3, 48);
			this.labelError.Size = new System.Drawing.Size(170, 113);
			this.labelError.Visible = false;
			// 
			// Connect
			// 
			this.ClientSize = new System.Drawing.Size(176, 180);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxCOMPort);
			this.Controls.Add(this.labelError);
			this.Menu = this.mainMenu1;
			this.Text = "Connect";

		}

		#endregion

		
		private Connector connection;
		
		private void menuItemExit_Click(object sender, EventArgs e)
		{
			if (connection != null)
				connection.Disconnect();
			
			Application.Exit();
		}

		private void menuItemConnect_Click(object sender, EventArgs e)
		{
			if (connection == null)
				connection = new Connector();

			if (menuItemConnect.Text == "Connect")
			{
				if (!connection.Connect(comboBoxCOMPort.Text))
				{
					labelError.Text = "Error connecting to COM Port " + comboBoxCOMPort.Text + ". Please verify that it is the correct one and that BlueTooth is turned on.";
					labelError.Visible = true;
				}
				else
				{
					labelError.Visible = false;
					menuItemConnect.Text = "Disconnect";
					new ControlMain(connection).Show();
				}
			}
			else if (menuItemConnect.Text == "Disconnect")
			{
				if (!connection.Disconnect())
				{	
					labelError.Text = "Error disconnecting to COM Port " + comboBoxCOMPort.Text + ".";
					labelError.Visible = true;
				}
				else
				{
					labelError.Visible = false;
					menuItemConnect.Text = "Connect";
				}
			}
		}
	}
}
