using ChartExample.Models.Chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;
using System.Net;

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

        [BindProperty]
        public Adress Adress { get; set; }


        [BindProperty(SupportsGet = true)]
        public int total { get; set; }

        [BindProperty(SupportsGet = true)]
        public string shippingFees { get; set; }
        public DataTable adresst { get; set; }
        public CheckOutModel(Database database)
        {
            db = database;
           

        }
        public void OnGet()
        {
            type = db.returnType(UserName);
            if (type==3)
            {
                Dt = db.ReadClient(UserName);
                carttable = db.ReadCart(UserName);
                adresst = db.ReadAdress(UserName);
                shippingFees = Convert.ToString(carttable.Rows[0][3]);
                overall = Convert.ToInt32(shippingFees) + calcTotal();
                if (adresst != null && adresst.Rows.Count != 0)
                {
                    Adress = new Adress
                    {
                        Zipcode = Convert.ToString(adresst.Rows[0][1]),
                        Gov = Convert.ToString(adresst.Rows[0][2]),
                        City = Convert.ToString(adresst.Rows[0][3]),
                        Street = Convert.ToString(adresst.Rows[0][4]),
                        Buildingno = Convert.ToString(adresst.Rows[0][5]),
                        Floor = Convert.ToString(adresst.Rows[0][6]),
                        Flat = Convert.ToString(adresst.Rows[0][7])
                    };

                }
            }
            else
            {
                carttable = db.ReadCartGuest(UserName);
                shippingFees = Convert.ToString(carttable.Rows[0][3]);
                overall = Convert.ToInt32(shippingFees) + calcTotal();
            }
            
            
           
        }
        public IActionResult OnPostAdress()
        {
            if (type == 3)
            {
                //handling giving adress to fawry
                db.UsersAdress(Adress, UserName);
                return RedirectToPage("/IndexClient");
            }
            else
            {
                //handling giving adress to fawry
                return RedirectToPage("/Index");
            }
              

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
