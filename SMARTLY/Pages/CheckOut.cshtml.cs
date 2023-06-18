using ChartExample.Models.Chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CheckOutModel : UserPageModel
    {
        
        private readonly Database db;

       
        [BindProperty]
        public string password { get; set; }

        [BindProperty]
        public int type { get; set; }

       

        [BindProperty]
        public DataTable Dt { get; set; }
        [BindProperty]
        public DataTable carttable { get; set; }

        public string message { get; set; }


        [BindProperty(SupportsGet = true)]
        public int overall { get; set; }

        public Adress Adress { get; set; }

        [BindProperty(SupportsGet = true)]
        public int total { get; set; }

        [BindProperty(SupportsGet = true)]
        public string shippingFees { get; set; }

        public CheckOutModel(Database database)
        {
            db = database;
           

        }
        public void OnGet()
        {
            Console.WriteLine($"Shipping fees: {shippingFees}, Total price: {total}");
            type = db.returnType(UserName);
            Dt = db.ReadClient(UserName);
            carttable = db.ReadCart(UserName);
            shippingFees =Convert.ToString(carttable.Rows[0][3]);
            overall = Convert.ToInt32(shippingFees) + calcTotal();
        }
        public void OnPost()
        {
            db.UsersAdress(Adress, UserName);
        }
        public string returnName(int id)
        {
            DataTable t = db.ReadProductRow(id);
            string name =Convert.ToString( t.Rows[0][1]);
            return name;
        }
        public int returnPrice(int id)
        {
            DataTable t = db.ReadProductRow(id);
            int name = Convert.ToInt32(t.Rows[0][9]);
            return name;
        }
        public int calcTotal()
        {
            int x = 0;
            for (int i = 0; i < carttable.Rows.Count; i++)
            {

                DataTable t = db.ReadProductRow(Convert.ToInt32(carttable.Rows[i][1]));
                x = (Convert.ToInt32(t.Rows[0][9]) * Convert.ToInt32(carttable.Rows[i][2])) + x;

            }
            total = x;
            return x;



        }

    }
}
