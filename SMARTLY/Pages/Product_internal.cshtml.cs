using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;


namespace SMARTLY.Pages
{
    public class Product_internalModel : UserPageModel
    {
 
			private readonly Database data;
			public DataTable dt { get; set; }
			public string Categorietype { get; set; }
			public int CountFeedBack { get; set; }
			public int rating { get; set; }
		    public int id { set; get; }
			public DataTable RateTable { get; set; }
			public DataTable ImgsTable { get; set; }
			public Product_internalModel(Database db)
			{
				data = db;
			}
			public void OnGet(int id)
			{
			    this.id = id;
				dt = data.ReadProductRow(this.id);
				Categorietype = data.ReturnCategoryForProduct(Convert.ToInt32(dt.Rows[0][6]));
				CountFeedBack = data.CountFeedBackProduct(this.id);
				rating = data.AVGRATING(this.id);
				RateTable = data.ReturnRatesForProduct(this.id);
				ImgsTable = data.ImgsForProduct(this.id);
			}
			public void OnPost()
			{

			}


}
}
