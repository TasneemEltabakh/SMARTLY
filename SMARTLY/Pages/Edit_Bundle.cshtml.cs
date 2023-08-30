using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;
using ChartExample.Models.Chart;

namespace SMARTLY.Pages
{
    public class Edit_BundleModel : UserPageModel
	{
		private readonly Database db;
		public Edit_BundleModel(Database data)
		{
			db = data;
		}
		[BindProperty]
		public DataTable Dt { get; set; }

		[BindProperty]
		public int idd { get; set; }

		[BindProperty]
		public Bundle Bundle { get; set; }

		public void OnGet(int id)
        {
			Dt = db.ReadBudle(id);

			if (Dt != null && Dt.Rows.Count != 0)
			{
				Bundle = new Bundle
				{
					Name = Convert.ToString(Dt.Rows[0][4]),
					price = Convert.ToString(Dt.Rows[0][1]),
					Description = Convert.ToString(Dt.Rows[0][3]),
					BundleId = Convert.ToString(Dt.Rows[0][0]),
				};
			}
		}
		public IActionResult OnPost()
		{
			db.Edit_Bundle(Bundle.Name, Bundle.Description, Bundle.price, Bundle.BundleId);
			return RedirectToPage("/Bundle_Out_Admin");
		}
    }
}
