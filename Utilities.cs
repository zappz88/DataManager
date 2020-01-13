using MarketplaceManager.DbContexts;
using MarketplaceManager.NullObjectModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;

namespace MarketplaceManager
{
	public static class Utilities
	{
		public static bool InputFieldNullOrEmpty(TextBox textBox)
		{
			if (string.IsNullOrEmpty(textBox.Text) || textBox.TextLength == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static List<Control> GetControlTypeRecursive(Control container, Type controlType)
		{
			List<Control> controlList = new List<Control>();

			if (container == null && container.Controls.Count == 0)
			{
				return controlList;
			}

			foreach (Control control in container.Controls)
			{
				if (control.GetType() == controlType)
				{
					controlList.Add(control);
				}
				else
				{
					controlList.AddRange(GetControlTypeRecursive(control, controlType));
				}
			}

			return controlList;
		}

		public static object GetTableModel(Enum tableModelEnum)
		{
			object tableModel = null;
			switch (tableModelEnum)
			{
				case TableEnum.AmazonXref:
					tableModel = new AmazonXref();
					break;
				case TableEnum.eBayXref:
					tableModel = new eBayXref();
					break;
				case TableEnum.NewEggXref:
					tableModel = new NewEggXref();
					break;
				case TableEnum.WalmartXref:
					tableModel = new WalmartXref();
					break;
				default:
					tableModel = null;
					break;
			}
			return tableModel;
		}

		public static object GetNullTableModel(Enum tableModelEnum)
		{
			object tableModel = null;
			switch (tableModelEnum)
			{
				case TableEnum.AmazonXref:
					tableModel = new NullAmazonXrefModel();
					break;
				case TableEnum.eBayXref:
					tableModel = new NulleBayXrefModel();
					break;
				case TableEnum.NewEggXref:
					tableModel = new NullNewEggXrefModel();
					break;
				case TableEnum.WalmartXref:
					tableModel = new NullWalmartXrefModel();
					break;
				default:
					tableModel = null;
					break;
			}
			return tableModel;
		}

		public static DbContext GetDbContext(Enum dbContextEnum)
		{
			DbContext dbContext = null;
			switch (dbContextEnum)
			{
				case DatabaseEnum.CPInv:
					dbContext = new CPInvEntities();
					break;
			}
			return dbContext;
		}
	}
}
