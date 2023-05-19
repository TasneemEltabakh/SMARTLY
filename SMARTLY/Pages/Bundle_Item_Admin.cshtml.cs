using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Bundle_Item_AdminModel : UserPageModel
    {
        private readonly Database data;
        public DataTable dt { get; set; }
        public Bundle_Item_AdminModel(Database db)
        {
            data = db;
        }
        public void OnGet(int id)
        {
            dt=data.ReadBundleRow(id);
        }
    }
}
