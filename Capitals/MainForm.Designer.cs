/*
 * Created by SharpDevelop.
 * User: SY_Serv
 * Date: 04-Jul-22
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Capitals
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox cbContinent;
		private System.Windows.Forms.Label lCountryName;
		private System.Windows.Forms.TextBox tbCapitalCity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.Label lResult;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fillContinentsToolStripMenuItem;
		private System.Windows.Forms.Label lTotalCountries;
		private System.Windows.Forms.ListBox lbCorrectAnswers;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ListBox lbIncorrectAnswers;
		private System.Windows.Forms.ToolStripMenuItem modifyApplicationToolStripMenuItem;
		private System.Windows.Forms.Button btnHint;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem openDifficultContriesFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openAllCountriesToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbContinent = new System.Windows.Forms.ComboBox();
			this.lCountryName = new System.Windows.Forms.Label();
			this.tbCapitalCity = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnCheck = new System.Windows.Forms.Button();
			this.lResult = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openAllCountriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDifficultContriesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fillContinentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lTotalCountries = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnHint = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lbCorrectAnswers = new System.Windows.Forms.ListBox();
			this.lbIncorrectAnswers = new System.Windows.Forms.ListBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbContinent
			// 
			this.cbContinent.FormattingEnabled = true;
			this.cbContinent.Items.AddRange(new object[] {
			"All Continents",
			"Africa",
			"Asia",
			"Europe",
			"North America",
			"South America",
			"Oceania",
			"Antarctica",
			"Difficult Countries"});
			this.cbContinent.Location = new System.Drawing.Point(29, 80);
			this.cbContinent.Name = "cbContinent";
			this.cbContinent.Size = new System.Drawing.Size(121, 21);
			this.cbContinent.TabIndex = 0;
			this.cbContinent.Text = "Select a Continent";
			this.cbContinent.SelectedIndexChanged += new System.EventHandler(this.CbContinentSelectedIndexChanged);
			// 
			// lCountryName
			// 
			this.lCountryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lCountryName.Location = new System.Drawing.Point(12, 157);
			this.lCountryName.Name = "lCountryName";
			this.lCountryName.Size = new System.Drawing.Size(302, 20);
			this.lCountryName.TabIndex = 1;
			this.lCountryName.Text = " ";
			// 
			// tbCapitalCity
			// 
			this.tbCapitalCity.Location = new System.Drawing.Point(320, 154);
			this.tbCapitalCity.Name = "tbCapitalCity";
			this.tbCapitalCity.Size = new System.Drawing.Size(100, 20);
			this.tbCapitalCity.TabIndex = 2;
			this.tbCapitalCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbCapitalCityKeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Country:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(235, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Capital City:";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(360, 78);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 5;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// btnCheck
			// 
			this.btnCheck.Location = new System.Drawing.Point(441, 152);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(75, 23);
			this.btnCheck.TabIndex = 6;
			this.btnCheck.Text = "Check";
			this.btnCheck.UseVisualStyleBackColor = true;
			this.btnCheck.Click += new System.EventHandler(this.BtnCheckClick);
			// 
			// lResult
			// 
			this.lResult.AutoSize = true;
			this.lResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lResult.Location = new System.Drawing.Point(14, 207);
			this.lResult.MaximumSize = new System.Drawing.Size(300, 100);
			this.lResult.Name = "lResult";
			this.lResult.Size = new System.Drawing.Size(49, 16);
			this.lResult.TabIndex = 7;
			this.lResult.Text = "lResult";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.utilitiesToolStripMenuItem,
			this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(935, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.modifyApplicationToolStripMenuItem,
			this.openAllCountriesToolStripMenuItem,
			this.openDifficultContriesFileToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// modifyApplicationToolStripMenuItem
			// 
			this.modifyApplicationToolStripMenuItem.Name = "modifyApplicationToolStripMenuItem";
			this.modifyApplicationToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.modifyApplicationToolStripMenuItem.Text = "Modify Application";
			this.modifyApplicationToolStripMenuItem.Click += new System.EventHandler(this.ModifyApplicationToolStripMenuItemClick);
			// 
			// openAllCountriesToolStripMenuItem
			// 
			this.openAllCountriesToolStripMenuItem.Name = "openAllCountriesToolStripMenuItem";
			this.openAllCountriesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.openAllCountriesToolStripMenuItem.Text = "Open All Countries";
			this.openAllCountriesToolStripMenuItem.Click += new System.EventHandler(this.OpenAllCountriesToolStripMenuItemClick);
			// 
			// openDifficultContriesFileToolStripMenuItem
			// 
			this.openDifficultContriesFileToolStripMenuItem.Name = "openDifficultContriesFileToolStripMenuItem";
			this.openDifficultContriesFileToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.openDifficultContriesFileToolStripMenuItem.Text = "Open Difficult Contries File";
			this.openDifficultContriesFileToolStripMenuItem.Click += new System.EventHandler(this.OpenDifficultContriesFileToolStripMenuItemClick);
			// 
			// utilitiesToolStripMenuItem
			// 
			this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fillContinentsToolStripMenuItem});
			this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
			this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.utilitiesToolStripMenuItem.Text = "Utilities";
			// 
			// fillContinentsToolStripMenuItem
			// 
			this.fillContinentsToolStripMenuItem.Name = "fillContinentsToolStripMenuItem";
			this.fillContinentsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.fillContinentsToolStripMenuItem.Text = "Fill Continents";
			this.fillContinentsToolStripMenuItem.Click += new System.EventHandler(this.FillContinentsToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// lTotalCountries
			// 
			this.lTotalCountries.Location = new System.Drawing.Point(178, 83);
			this.lTotalCountries.Name = "lTotalCountries";
			this.lTotalCountries.Size = new System.Drawing.Size(157, 18);
			this.lTotalCountries.TabIndex = 9;
			this.lTotalCountries.Text = "lTotalCountries";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 547);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(935, 22);
			this.statusStrip1.TabIndex = 11;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel1.Text = " ";
			// 
			// btnHint
			// 
			this.btnHint.Location = new System.Drawing.Point(441, 181);
			this.btnHint.Name = "btnHint";
			this.btnHint.Size = new System.Drawing.Size(75, 23);
			this.btnHint.TabIndex = 13;
			this.btnHint.Text = "Hint";
			this.btnHint.UseVisualStyleBackColor = true;
			this.btnHint.Click += new System.EventHandler(this.BtnHintClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(522, 43);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lbCorrectAnswers);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lbIncorrectAnswers);
			this.splitContainer1.Size = new System.Drawing.Size(400, 501);
			this.splitContainer1.SplitterDistance = 299;
			this.splitContainer1.TabIndex = 14;
			// 
			// lbCorrectAnswers
			// 
			this.lbCorrectAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lbCorrectAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCorrectAnswers.FormattingEnabled = true;
			this.lbCorrectAnswers.IntegralHeight = false;
			this.lbCorrectAnswers.ItemHeight = 16;
			this.lbCorrectAnswers.Location = new System.Drawing.Point(3, 3);
			this.lbCorrectAnswers.Name = "lbCorrectAnswers";
			this.lbCorrectAnswers.Size = new System.Drawing.Size(394, 293);
			this.lbCorrectAnswers.TabIndex = 11;
			this.lbCorrectAnswers.UseTabStops = false;
			// 
			// lbIncorrectAnswers
			// 
			this.lbIncorrectAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lbIncorrectAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbIncorrectAnswers.FormattingEnabled = true;
			this.lbIncorrectAnswers.IntegralHeight = false;
			this.lbIncorrectAnswers.ItemHeight = 16;
			this.lbIncorrectAnswers.Location = new System.Drawing.Point(3, 3);
			this.lbIncorrectAnswers.Name = "lbIncorrectAnswers";
			this.lbIncorrectAnswers.Size = new System.Drawing.Size(394, 190);
			this.lbIncorrectAnswers.TabIndex = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(935, 569);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnHint);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.lTotalCountries);
			this.Controls.Add(this.lResult);
			this.Controls.Add(this.btnCheck);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbCapitalCity);
			this.Controls.Add(this.lCountryName);
			this.Controls.Add(this.cbContinent);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Capitals";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
