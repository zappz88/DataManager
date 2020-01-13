using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MarketplaceManager
{
	public partial class AddForm: Form
	{
		public object nullTableModelObject { get; set; }
		public object tableModelObject { get; set; }
		public DbContext dbContextObject { get; set; }
		public AddForm()
		{
			InitializeComponent();
		}

		public void addFormLoad(object sender, EventArgs e)
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

			var props = nullTableModelObject.GetType().GetProperties();

			foreach (var prop in props)
			{
				if (prop.Name != "ID")
				{
					switch (Type.GetTypeCode(prop.GetValue(nullTableModelObject, null).GetType()))
					{
						case TypeCode.Boolean:
							var checkBox = new CheckBox();
							checkBox.Name = prop.Name;
							checkBox.Text = prop.Name;
							checkBox.DataBindings.Add("Checked", nullTableModelObject, prop.Name);
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
							textBox.DataBindings.Add("Text", nullTableModelObject, prop.Name);
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

			if (nullTableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance) != null)
			{
				var locationEnums = Enum.GetValues(typeof(Locations));

				var pullFromWarehouseCheckedListBox2 = new CheckedListBox();
				pullFromWarehouseCheckedListBox2.Height = this.Height / 2;

				foreach (Enum locationEnum in locationEnums)
				{
					pullFromWarehouseCheckedListBox2.Items.Add(locationEnum);
				}

				var pullFromWareHouseProperty = nullTableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance).GetValue(nullTableModelObject, null);

				if (pullFromWareHouseProperty != null)
				{
					var tableModelObjectLocations = Convert.ToString(pullFromWareHouseProperty).Split(',');
					for (int i = 0; i < pullFromWarehouseCheckedListBox2.Items.Count; i++)
					{
						for (int j = 0; j < tableModelObjectLocations.Length; j++)
						{
							if (tableModelObjectLocations[j] != string.Empty)
							{
								if (Convert.ToInt32(pullFromWarehouseCheckedListBox2.Items[i]) == Convert.ToInt32(tableModelObjectLocations[j]))
								{
									pullFromWarehouseCheckedListBox2.SetItemChecked(i, true);
									break;
								}
							}
						}
					}
				}

				controlsTableLayout.Controls.Add(pullFromWarehouseCheckedListBox2);
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			try
			{
				var context = dbContextObject;
				var entitySet = context.Set(tableModelObject.GetType());
				var props = tableModelObject.GetType().GetProperties();

				var textBoxes = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(TextBox));
				foreach (TextBox textBox in textBoxes)
				{
					foreach (var prop in props)
					{
						if (!string.IsNullOrEmpty(textBox.Text))
						{
							if (prop.Name.ToUpper() == textBox.Name.ToUpper())
							{
								var convertedValue = Convert.ChangeType(textBox.Text, prop.PropertyType);
								prop.SetValue(tableModelObject, convertedValue);
								break;
							}
						}
						else
						{
							throw new Exception("Input required");
						}
					}
				}

			var checkBoxes = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(CheckBox));
			foreach (CheckBox checkBox in checkBoxes)
			{
				foreach (var prop in props)
				{
					if (prop.Name.ToUpper() == checkBox.Name.ToUpper())
					{
						prop.SetValue(tableModelObject, checkBox.Checked);
						break;
					}
				}
			}

			if (tableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance) != null)
			{
				var pullFromWarehouseCheckedListBox = Utilities.GetControlTypeRecursive(this.Controls["mainControl"], typeof(CheckedListBox))[0] as CheckedListBox;
				var checkedItemsCollection = pullFromWarehouseCheckedListBox.CheckedItems;

				if (checkedItemsCollection.Count == 0)
				{
					throw new Exception("Input required");
				}

				var checkedItemsList = new List<string>();

				foreach (var item in checkedItemsCollection)
				{
					checkedItemsList.Add(Convert.ToString(Convert.ToInt32(item)));
				}

				var checkedItemsString = string.Join(",", checkedItemsList);

				tableModelObject.GetType().GetProperty("PullFromWarehouse", BindingFlags.Public | BindingFlags.Instance).SetValue(tableModelObject, checkedItemsString);
			}

			entitySet.Add(tableModelObject);
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
