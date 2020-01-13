namespace MarketplaceManager
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.searchParameterComboBox = new System.Windows.Forms.ComboBox();
			this.searchParameterLabel = new System.Windows.Forms.Label();
			this.searchParameterTextBox = new System.Windows.Forms.TextBox();
			this.tableDataGridView = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.selectServerLabel = new System.Windows.Forms.Label();
			this.tableSelectionComboBox = new System.Windows.Forms.ComboBox();
			this.databaseSelectionComboBox = new System.Windows.Forms.ComboBox();
			this.serverSelectionComboBox = new System.Windows.Forms.ComboBox();
			this.selectDatabaseLabel = new System.Windows.Forms.Label();
			this.selectTableLabel = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.addToolTip = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.searchParameterComboBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.searchParameterLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.searchParameterTextBox, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 28);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(137, 100);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// searchParameterComboBox
			// 
			this.searchParameterComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.searchParameterComboBox.FormattingEnabled = true;
			this.searchParameterComboBox.Location = new System.Drawing.Point(7, 39);
			this.searchParameterComboBox.Name = "searchParameterComboBox";
			this.searchParameterComboBox.Size = new System.Drawing.Size(123, 21);
			this.searchParameterComboBox.TabIndex = 19;
			// 
			// searchParameterLabel
			// 
			this.searchParameterLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.searchParameterLabel.AutoSize = true;
			this.searchParameterLabel.Location = new System.Drawing.Point(22, 20);
			this.searchParameterLabel.Name = "searchParameterLabel";
			this.searchParameterLabel.Size = new System.Drawing.Size(92, 13);
			this.searchParameterLabel.TabIndex = 6;
			this.searchParameterLabel.Text = "Search Parameter";
			// 
			// searchParameterTextBox
			// 
			this.searchParameterTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.searchParameterTextBox.Location = new System.Drawing.Point(7, 73);
			this.searchParameterTextBox.Name = "searchParameterTextBox";
			this.searchParameterTextBox.Size = new System.Drawing.Size(122, 20);
			this.searchParameterTextBox.TabIndex = 0;
			this.searchParameterTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
			this.searchParameterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyEvent);
			// 
			// tableDataGridView
			// 
			this.tableDataGridView.AllowUserToAddRows = false;
			this.tableDataGridView.AllowUserToDeleteRows = false;
			this.tableDataGridView.AllowUserToResizeColumns = false;
			this.tableDataGridView.AllowUserToResizeRows = false;
			this.tableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableDataGridView.Location = new System.Drawing.Point(12, 134);
			this.tableDataGridView.Name = "tableDataGridView";
			this.tableDataGridView.ReadOnly = true;
			this.tableDataGridView.RowHeadersVisible = false;
			this.tableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.tableDataGridView.Size = new System.Drawing.Size(1105, 420);
			this.tableDataGridView.TabIndex = 11;
			this.tableDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableDataGridView_CellDoubleClick);
			this.tableDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GetDataGridViewCellCollection);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.17921F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.82079F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
			this.tableLayoutPanel2.Controls.Add(this.selectServerLabel, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableSelectionComboBox, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.databaseSelectionComboBox, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.serverSelectionComboBox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.selectDatabaseLabel, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.selectTableLabel, 2, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(369, 28);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.14286F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.85714F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(391, 56);
			this.tableLayoutPanel2.TabIndex = 17;
			// 
			// selectServerLabel
			// 
			this.selectServerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectServerLabel.AutoSize = true;
			this.selectServerLabel.Location = new System.Drawing.Point(28, 6);
			this.selectServerLabel.Name = "selectServerLabel";
			this.selectServerLabel.Size = new System.Drawing.Size(71, 13);
			this.selectServerLabel.TabIndex = 15;
			this.selectServerLabel.Text = "Select Server";
			this.selectServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableSelectionComboBox
			// 
			this.tableSelectionComboBox.FormattingEnabled = true;
			this.tableSelectionComboBox.Location = new System.Drawing.Point(257, 29);
			this.tableSelectionComboBox.Name = "tableSelectionComboBox";
			this.tableSelectionComboBox.Size = new System.Drawing.Size(121, 21);
			this.tableSelectionComboBox.TabIndex = 10;
			this.tableSelectionComboBox.SelectedValueChanged += new System.EventHandler(this.tableSelectionComboBox_ItemSelected);
			// 
			// databaseSelectionComboBox
			// 
			this.databaseSelectionComboBox.FormattingEnabled = true;
			this.databaseSelectionComboBox.Location = new System.Drawing.Point(130, 29);
			this.databaseSelectionComboBox.Name = "databaseSelectionComboBox";
			this.databaseSelectionComboBox.Size = new System.Drawing.Size(121, 21);
			this.databaseSelectionComboBox.TabIndex = 12;
			this.databaseSelectionComboBox.SelectedValueChanged += new System.EventHandler(this.databaseSelectionComboBox_ItemSelected);
			// 
			// serverSelectionComboBox
			// 
			this.serverSelectionComboBox.FormattingEnabled = true;
			this.serverSelectionComboBox.Location = new System.Drawing.Point(3, 29);
			this.serverSelectionComboBox.Name = "serverSelectionComboBox";
			this.serverSelectionComboBox.Size = new System.Drawing.Size(121, 21);
			this.serverSelectionComboBox.TabIndex = 14;
			this.serverSelectionComboBox.SelectedValueChanged += new System.EventHandler(this.serverSelectionComboBox_ItemSelected);
			// 
			// selectDatabaseLabel
			// 
			this.selectDatabaseLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectDatabaseLabel.AutoSize = true;
			this.selectDatabaseLabel.Location = new System.Drawing.Point(147, 6);
			this.selectDatabaseLabel.Name = "selectDatabaseLabel";
			this.selectDatabaseLabel.Size = new System.Drawing.Size(86, 13);
			this.selectDatabaseLabel.TabIndex = 13;
			this.selectDatabaseLabel.Text = "Select Database";
			this.selectDatabaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// selectTableLabel
			// 
			this.selectTableLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectTableLabel.AutoSize = true;
			this.selectTableLabel.Location = new System.Drawing.Point(289, 6);
			this.selectTableLabel.Name = "selectTableLabel";
			this.selectTableLabel.Size = new System.Drawing.Size(67, 13);
			this.selectTableLabel.TabIndex = 11;
			this.selectTableLabel.Text = "Select Table";
			this.selectTableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolTip,
            this.toolStripSeparator1,
            this.refreshToolStripButton,
            this.toolStripSeparator2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1129, 25);
			this.toolStrip1.TabIndex = 18;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// addToolTip
			// 
			this.addToolTip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.addToolTip.Image = ((System.Drawing.Image)(resources.GetObject("addToolTip.Image")));
			this.addToolTip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addToolTip.Name = "addToolTip";
			this.addToolTip.Size = new System.Drawing.Size(23, 22);
			this.addToolTip.Text = "toolStripButton1";
			this.addToolTip.Click += new System.EventHandler(this.addItemButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// refreshToolStripButton
			// 
			this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
			this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.refreshToolStripButton.Name = "refreshToolStripButton";
			this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.refreshToolStripButton.Text = "toolStripButton2";
			this.refreshToolStripButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1129, 566);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableDataGridView);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MarketplaceManager";
			this.Load += new System.EventHandler(this.mainFormLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label searchParameterLabel;
		private System.Windows.Forms.TextBox searchParameterTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label selectServerLabel;
		private System.Windows.Forms.Label selectDatabaseLabel;
		private System.Windows.Forms.Label selectTableLabel;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton addToolTip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton refreshToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ComboBox searchParameterComboBox;
		public System.Windows.Forms.DataGridView tableDataGridView;
		public System.Windows.Forms.ComboBox tableSelectionComboBox;
		public System.Windows.Forms.ComboBox databaseSelectionComboBox;
		public System.Windows.Forms.ComboBox serverSelectionComboBox;
	}
}

