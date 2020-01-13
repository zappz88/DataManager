using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MarketplaceManager
{
	public partial class EditForm : Form
	{
		public object tableModelObject { get; set; }
		public DbContext dbContextObject { get; set; }
		public EditForm()
		{
			InitializeComponent();
		}

		public void editFormLoad(object sender, EventArgs e)
		{
			var controlsTableLayout = new TableLayoutPanel();
			controlsTableLayout.Name = "mainControl";
			controlsTableLayout.ColumnCount = 3;
			controlsTableLayout.AutoSize = true;
			controlsTableLayout.Controls.Clear();
			controlsTableLayout.ColumnStyles.Clear();
			controlsTableLayout.RowStyles.Clear();

			var textBoxTableLayoutPanel = new TableLayoutPanel();
			textBoxTableLayoutPanel.ColumnCount = 4;
			textBoxTableLayoutPanel.AutoSize = true;
			textBoxTableLayoutPanel.Controls.Clear();
			textBoxTableLayoutPanel.ColumnStyles.Clear();
			textBoxTableLayoutPanel.RowStyles.Clear();

			var checkBoxTableLayoutPanel = new TableLayoutPanel();
			checkBoxTableLayoutPanel.RowCount = 4;
			checkBoxTableLayoutPanel.AutoSize = true;
			checkBoxTableLayoutPanel.Controls.Clear();
			checkBoxTableLayoutPanel.ColumnStyles.Clear();
			checkBoxTableLayoutPanel.RowStyles.Clear();

			var props = tableModelObject.GetType().GetProperties();

			foreach (var prop in props)
			{
				if (prop.Name != "ID")
				{ 
					switch (Type.GetTypeCode(prop.GetValue(tableModelObject, null).GetType()))
					{
						case TypeCode.Boolean:
							var checkBox = new CheckBox();
							checkBox.Name = prop.Name;
							checkBox.Text = prop.Name;
							checkBox.DataBindings.Add("Checked", tableModelObject, prop.Name);
							checkBoxTableLayoutPanel.Controls.Add(checkBox);
							break;
						case TypeCode.String:
						case TypeCode.Int16:
						case TypeCode.Int32:
						case TypeCode.Int64:
						case TypeCode.UInt16:
						case TypeCode.UInt32:
						case TypeCode.UInt64:
						case TypeCode.Decimal:
						case TypeCode.Double:
							var textBox = new TextBox();
							textBox.Name = prop.Name;
							textBox.DataBindings.Add("Text", tableModelObject, prop.Name);
							var label = new Label();
							label.Text = prop.Name;
							label.TextAlign = ContentAlignment.MiddleLeft;
							textBoxTableLayoutPanel.Controls.Add(label);
							textBoxTableLayoutPanel.Controls.Add(textBox);
							break;
						case TypeCode.DateTime:
							break;
					}
				}
			}

			this.Controls.Add(controlsTableLayout);
			controlsTableLayout.Controls.Add(textBoxTableLayoutPanel);
			controlsTableLayout.Controls.Add(checkBoxTableLayoutPanel);


			if (tableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance) != null)
			{
				var locationEnums = Enum.GetValues(typeof(Locations)); ;

				var pullFromWarehouseCheckedListBox = new CheckedListBox();
				pullFromWarehouseCheckedListBox.Name = "pullFromWarehouseCheckedListBox";
				pullFromWarehouseCheckedListBox.Height = this.Height / 2;

				foreach (Enum locationEnum in locationEnums)
				{
					pullFromWarehouseCheckedListBox.Items.Add(locationEnum);
				}
				var textBoxes = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(TextBox));


				var pullFromWareHouseProperty = tableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance).GetValue(tableModelObject, null);

				if (pullFromWareHouseProperty != null)
				{
					var tableModelObjectLocations = Convert.ToString(pullFromWareHouseProperty).Split(',');
					for (int i = 0; i < pullFromWarehouseCheckedListBox.Items.Count; i++)
					{
						for (int j = 0; j < tableModelObjectLocations.Length; j++)
						{
							if (Convert.ToInt32(pullFromWarehouseCheckedListBox.Items[i]) == Convert.ToInt32(tableModelObjectLocations[j]))
							{
								pullFromWarehouseCheckedListBox.SetItemChecked(i, true);
								break;
							}
						}
					}
				}

				controlsTableLayout.Controls.Add(pullFromWarehouseCheckedListBox);
			}
		}


		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void editButton_Click(object sender, EventArgs e)
		{
			try
			{
				var context = dbContextObject;
				var entitySet = context.Set(tableModelObject.GetType());
				var selectedElement = entitySet.Find(tableModelObject.GetType().GetProperty("ID").GetValue(tableModelObject, null));
				var props = selectedElement.GetType().GetProperties();

				var textBoxes = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(TextBox));
				foreach (TextBox textBox in textBoxes)
				{
					if (!string.IsNullOrEmpty(textBox.Text))
					{
						foreach (var prop in props)
						{
							if (prop.Name.ToUpper() == textBox.Name.ToUpper())
							{
								var convertedValue = Convert.ChangeType(textBox.Text, prop.PropertyType);
								prop.SetValue(selectedElement, convertedValue);
								break;
							}
						}
					}
					else
					{
						throw new Exception("Input required");
					}
				}

				var checkBoxes = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(CheckBox));
				foreach (CheckBox checkBox in checkBoxes)
				{
					foreach (var prop in props)
					{
						if (prop.Name.ToUpper() == checkBox.Name.ToUpper())
						{
							prop.SetValue(selectedElement, checkBox.Checked);
							break;
						}
					}
				}

				if (tableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance) != null)
				{
					var pullFromWarehouseCheckedListBox = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(CheckedListBox))[0] as CheckedListBox;
					var checkedItemsCollection = pullFromWarehouseCheckedListBox.CheckedItems;
					var checkedItemsList = new List<string>();

					if (checkedItemsCollection.Count == 0)
					{
						throw new Exception("Input required");
					}

					foreach (var item in checkedItemsCollection)
					{
						checkedItemsList.Add(Convert.ToString(Convert.ToInt32(item)));
					}

					var checkedItemsString = string.Join(",", checkedItemsList);

					selectedElement.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance).SetValue(selectedElement, checkedItemsString);
				}

				context.SaveChanges();
				context.Dispose();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
