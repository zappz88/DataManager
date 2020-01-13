using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarketplaceManager
{
	public partial class MainForm : Form
	{
		private string baseConnectionString = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout=30;Encrypt=False;TrustServerCertificate=True";
		public DataTable dataTable = new DataTable();
		public MainForm()
		{
			InitializeComponent();
		}

		public void mainFormLoad(object sender, EventArgs e)
		{
			var serverEnumsArray = Enum.GetValues(typeof(ServerEnum));
			foreach (Enum serverEnum in serverEnumsArray)
			{
				this.serverSelectionComboBox.Items.Add(serverEnum);
			}
		}

		private void serverSelectionComboBox_ItemSelected(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			if (comboBox != null)
			{
				switch (comboBox.SelectedItem)
				{
					case ServerEnum.DATASERVER:
						this.databaseSelectionComboBox.Items.Clear();
						this.databaseSelectionComboBox.Items.Add(DatabaseEnum.CPInv);
						break;
				}
			}
		}

		private void databaseSelectionComboBox_ItemSelected(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			if (comboBox != null)
			{
				switch (comboBox.SelectedItem)
				{
					case DatabaseEnum.CPInv:
						this.tableSelectionComboBox.Items.Clear();
						this.tableSelectionComboBox.Items.Add(TableEnum.AmazonXref);
						this.tableSelectionComboBox.Items.Add(TableEnum.eBayXref);
						this.tableSelectionComboBox.Items.Add(TableEnum.NewEggXref);
						this.tableSelectionComboBox.Items.Add(TableEnum.WalmartXref);
						break;
				}
			}
		}

		private void tableSelectionComboBox_ItemSelected(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			if (comboBox != null)
			{
				this.dataTable = GetTable(this.serverSelectionComboBox.SelectedItem as Enum, this.databaseSelectionComboBox.SelectedItem as Enum, $"SELECT * FROM {this.tableSelectionComboBox.SelectedItem}");
				this.tableDataGridView.DataSource = this.dataTable;

				this.searchParameterComboBox.Items.Clear();
				this.searchParameterComboBox.Text = string.Empty;
				foreach (var dataColumn in this.dataTable.Columns)
				{
					this.searchParameterComboBox.Items.Add(dataColumn.ToString());
				}
			}
		}

		private void GetDataGridViewCellCollection(object sender, MouseEventArgs e)
		{
			var dataGridView = sender as DataGridView;
			if (dataGridView != null)
			{
				DataGridView.HitTestInfo hitTestInfo;

				if (e.Button == MouseButtons.Right)
				{
					var contextMenu = new ContextMenu();
					MenuItem deleteToolStrip = new MenuItem("&Delete");
					MenuItem searchParameter1ToolStrip = new MenuItem("&Search Parameter 1");
					MenuItem searchParameter2ToolStrip = new MenuItem("&Search Parameter 2");

					contextMenu.MenuItems.Add(deleteToolStrip);
					//contextMenu.MenuItems.Add(searchParameter1ToolStrip);
					//contextMenu.MenuItems.Add(searchParameter2ToolStrip);
					contextMenu.Show(dataGridView, new Point(e.X, e.Y));

					hitTestInfo = dataGridView.HitTest(e.X, e.Y);
					var rowIndex = hitTestInfo.RowIndex;

					if (rowIndex > -1)
					{

						deleteToolStrip.Click += (o, ev) =>
						{
							var tableModel = Utilities.GetTableModel(this.tableSelectionComboBox.SelectedItem as Enum);
							var tableModelObject = BuildEntityFromDataGridViewRow(dataGridView, tableModel, rowIndex);

							var result = MessageBox.Show("Delete?", "Info", MessageBoxButtons.YesNo);

							if (result == DialogResult.Yes)
							{
								var context = Utilities.GetDbContext(this.databaseSelectionComboBox.SelectedItem as Enum);
								var entitySet = context.Set(tableModelObject.GetType());
								var selectedElement = entitySet.Find(tableModelObject.GetType().GetProperty("ID").GetValue(tableModelObject, null));

								entitySet.Remove(selectedElement);
								context.SaveChanges();
								context.Dispose();
								this.dataTable = GetTable(this.serverSelectionComboBox.SelectedItem as Enum, this.databaseSelectionComboBox.SelectedItem as Enum, $"SELECT * FROM {this.tableSelectionComboBox.SelectedItem}");
								this.tableDataGridView.DataSource = this.dataTable;
							}
						};

						//searchParameter1ToolStrip.Click += (o, ev) =>
						//{
						//	var columnName = dataGridView.Columns[hitTestInfo.ColumnIndex].HeaderCell.Value.ToString();
						//	this.searchParameters1.Text = columnName;
						//};

						//searchParameter2ToolStrip.Click += (o, ev) =>
						//{
						//	var columnName = dataGridView.Columns[hitTestInfo.ColumnIndex].HeaderCell.Value.ToString();
						//	this.searchParameters2.Text = columnName;
						//};
					}
				}
			}
		}

		private void tableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var tableModel = Utilities.GetTableModel(this.tableSelectionComboBox.SelectedItem as Enum);
			var tableModelObject = BuildEntityFromDataGridViewRow(this.tableDataGridView, tableModel, e.RowIndex);
			var dbContextObject = Utilities.GetDbContext(this.databaseSelectionComboBox.SelectedItem as Enum);

			EditForm editForm = new EditForm();
			editForm.tableModelObject = tableModelObject;
			editForm.dbContextObject = dbContextObject;
			editForm.ShowDialog();
		}

		private void addItemButton_Click(object sender, EventArgs e)
		{
			if (this.tableSelectionComboBox.SelectedItem != null)
			{
				var tableModelObject = Utilities.GetTableModel(this.tableSelectionComboBox.SelectedItem as Enum);
				var nullTableModelObject = Utilities.GetNullTableModel(this.tableSelectionComboBox.SelectedItem as Enum);
				var dbContextObject = Utilities.GetDbContext(this.databaseSelectionComboBox.SelectedItem as Enum);

				AddForm addForm = new AddForm();
				addForm.tableModelObject = tableModelObject;
				addForm.nullTableModelObject = nullTableModelObject;
				addForm.dbContextObject = dbContextObject;
				addForm.Show();
			}
		}

		public void refreshButton_Click(object sender, EventArgs e)
		{
			if (this.tableSelectionComboBox.SelectedItem != null)
			{
				this.dataTable = GetTable(this.serverSelectionComboBox.SelectedItem as Enum, this.databaseSelectionComboBox.SelectedItem as Enum, $"SELECT * FROM {this.tableSelectionComboBox.SelectedItem}");
				this.tableDataGridView.DataSource = this.dataTable;
			}
		}

		private void searchTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.searchParameterComboBox.Text))
			{
				filterTable(this.searchParameterComboBox.Text, searchParameterTextBox.Text.Trim());
			}
		}

		private void searchTextBox_KeyEvent(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (!string.IsNullOrEmpty(this.searchParameterComboBox.Text))
				{
					filterTable(this.searchParameterComboBox.Text, searchParameterTextBox.Text.Trim());
				}
			}
		}

		private void filterTable(string columnName1, string filterValue1)
		{
			DataView dataview = new DataView();
			dataview.Table = this.dataTable;

			if (!string.IsNullOrEmpty(columnName1))
			{
				dataview.RowFilter = $"{columnName1} LIKE '%{filterValue1}%'";
			}
			this.tableDataGridView.DataSource = dataview;
		}

		private object BuildEntityFromDataGridViewRow(DataGridView dataGridView, object entityModel, int rowIndex)
		{
			DataGridViewRow selectedRow = dataGridView.Rows[rowIndex];
			var cells = selectedRow.Cells;
			var props = entityModel.GetType().GetProperties();
			foreach (DataGridViewCell cell in cells)
			{
				foreach (var prop in props)
				{
					if (cell.OwningColumn.HeaderCell.Value.ToString().ToUpper() == prop.Name.ToString().ToUpper())
					{
						var convertedValue = Convert.ChangeType(cell.Value, prop.PropertyType);
						prop.SetValue(entityModel, convertedValue);
						break;
					}
				}
			}
			return entityModel;
		}

		public DataTable GetTable(Enum serverEnum, Enum databaseEnum, string queryString)
		{
			string connectionString = GetConnectionString(serverEnum, databaseEnum, "appuser", "NmVuM3IxYw==");

			DataTable dataTable = new DataTable();
			DataSet dataSet = new DataSet();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, connection))
				{
					connection.Open();
					dataAdapter.Fill(dataSet);
					dataTable = dataSet.Tables[0];
					connection.Close();
				}
			}
			return dataTable;
		}

		private string GetConnectionString(Enum serverName, Enum databaseName, string userName, string password, bool passwordIsEncrypted = true)
		{
			string decryptedPassword = password;
			if (passwordIsEncrypted)
			{
				byte[] pwdBytes = Convert.FromBase64String(password);
				decryptedPassword = Encoding.UTF8.GetString(pwdBytes, 0, pwdBytes.Length);
			}
			return String.Format(baseConnectionString, serverName, databaseName, userName, decryptedPassword);
		}
	}
}
