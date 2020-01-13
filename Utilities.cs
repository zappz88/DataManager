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
