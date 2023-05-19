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

        public All_AgenciesModel(Database database)
        {
            this.database = database;

        }

        public void OnGet()
        {
            dt = database.loadTableofAgencies();
        }


    }
}
