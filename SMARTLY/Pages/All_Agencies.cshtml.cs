using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;
using System.Reflection.Metadata;

namespace SMARTLY.Pages
{
    public class All_AgenciesModel : UserPageModel
    {
        private readonly Database database;
        public DataTable dt { get; set; }
        [BindProperty]
        public int type { get; set; }
        public All_AgenciesModel(Database database)
        {
            this.database = database;

        }

        public void OnGet()
        {
            type = database.returnType(UserName);
            dt = database.loadTableofAgencies();
        }


    }
}
