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

        [BindProperty(SupportsGet =true)]
        public List<ProductsCart> ProductCart { get; set; } = new List<ProductsCart>();

        public Adress Adress { get; set; }  

        public CheckOutModel(Database database)
        {
            db = database;
           

        }
        public void OnGet()
        {

            type = db.returnType(UserName);
            Dt = db.ReadClient(UserName);
            carttable = db.ReadCart(UserName);

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
        public string returnPrice(int id)
        {
            DataTable t = db.ReadProductRow(id);
            string name = Convert.ToString(t.Rows[0][2]);
            return name;
        }
        public int calcTotal()
        {
            int sum = 0;
            for(int i =0; i< carttable.Rows.Count; i++)
            {
                sum =+sum;

                DataTable t = db.ReadProductRow(Convert.ToInt32(carttable.Rows[i][1]));
               sum = Convert.ToInt32(t.Rows[0][9])+sum;
                
            }
            return sum+20; 

        }
    }
}
