using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Products_Internal_AgencyModel : UserPageModel
	{

			private readonly Database data;
			public DataTable dt { get; set; }
			public string Categorietype { get; set; }
			public int CountFeedBack { get; set; }
			public int rating { get; set; }

			public DataTable RateTable { get; set; }
			public DataTable ImgsTable { get; set; }
			public Products_Internal_AgencyModel(Database db)
			{
				data = db;
			}
			public void OnGet(int id)
			{
				dt = data.ReadProductRow(id);
				Categorietype = data.ReturnCategoryForProduct(id);
				CountFeedBack = data.CountFeedBackProduct(id);
				rating = data.AVGRATING(id);
				RateTable = data.ReturnRatesForProduct(id);
				ImgsTable = data.ImgsForProduct(id);
			}
			public void OnPost()
			{

			}
	}
}
