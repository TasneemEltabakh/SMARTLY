using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Data.Common;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ChartExample.Models.Chart;
using System.Drawing;
using System.Security.Cryptography;

namespace SMARTLY.Pages.Models
{
    public class Database
    {
        public SqlConnection Connection { get; set; }
        public int getUserType { get; set; }
        public string getuserPassword { get; set; }
        public string getUsername { get; set; }

        public Object table { get; set; }
      
        public Database()
        {


            //string connectionString = "Data Source=DESKTOP-A0CE1LT\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True";
			string connectionString = "Data Source=DESKTOP-1BNDCN7\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True";
        //    string connectionString = "Data Source=db970214840.hosting-data.io; Initial Catalog =db970214840; User Id =dbo970214840; Password =smart12345; TrustServerCertificate=true";
            Connection = new SqlConnection(connectionString);

        }
        
        public void SignUpNewMember(User U, Client C)
        {
            string query = "insert into _User values (@USERNAME,@PASSWORD,@TYPE, null);";
            string query2 = " insert into Client values (@USERNAME,@email,@phonenumber,@Fname,@Lname);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            SqlCommand cmd2 = new SqlCommand(query2, Connection);
            cmd.Parameters.AddWithValue("@USERNAME", U.UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", U.password);
            cmd.Parameters.AddWithValue("@TYPE", 3);
            cmd2.Parameters.AddWithValue("@USERNAME", U.UserName);
            cmd2.Parameters.AddWithValue("@email", C.email);
            cmd2.Parameters.AddWithValue("@phonenumber", C.phonenumber);
            cmd2.Parameters.AddWithValue("@Fname", C.FirstName);
            cmd2.Parameters.AddWithValue("@Lname", C.LastName);
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

        }
        public int ReturnTotalCount()
        {
            string query = "select count(*) from _User";
            SqlCommand cmd = new SqlCommand(query, Connection);
            int x = (int)cmd.ExecuteScalar();
            return x;
        }

        public bool CheckPassword(string password, string username)
        {
            string queury = "Select userPassword from _User where username= @username;";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                Connection.Open();
                string PASSWORD = (string)cmd.ExecuteScalar();
                if (String.Equals(PASSWORD, password))
                    return true;
                else return false;

            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool checkemail(string username)
        {
            string queury = "select count(*) from _User where username = @username;";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count != 0)
                    return true;
                else return false;

            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool checkForgotten(string email)
        {
            string queury = "select count(*) from Client where email = @username;";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            cmd.Parameters.AddWithValue("@username", email);
            try
            {
                Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count != 0)
                    return true;
                else return false;

            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int returnType(string username)
        {

            string queury = "select UserType from _User where username = @username;";

            SqlCommand cmd = new SqlCommand(queury, Connection);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                Connection.Open();
                getUserType = (int)cmd.ExecuteScalar();
                return getUserType;
            }
            catch
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable loadTableofAgencies()
        {
            DataTable dt = new DataTable();
            string queury = "select Agencyname,email,Location from Agency";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable loadTableofManagers()
        {
            DataTable dt = new DataTable();
            string queury = "select * from _user where UserType=4";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable loadTableofOrder()
        {
            DataTable dt = new DataTable();
            string queury = "select OrderCode,Username,OrderDate,AmountToPay from AnOrder order by AmountToPay desc\r\n";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public void AddNewAgency(User U, Agency A)
        {

            string query = "insert into _User values (@USERNAME,@PASSWORD,@TYPE,Null); insert into Agency values (@usernameA,@email,@Agencyname,@Location);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@USERNAME", U.UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", U.password);
            cmd.Parameters.AddWithValue("@TYPE", 2);
            cmd.Parameters.AddWithValue("@usernameA", U.UserName);
            cmd.Parameters.AddWithValue("@email", A.email);
            cmd.Parameters.AddWithValue("@Agencyname", A.Name);
            cmd.Parameters.AddWithValue("@Location", A.location);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

        }
        public void AddNewManager(User U)
        {

            string query = "insert into _User values (@USERNAME,@PASSWORD,@TYPE,Null);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@USERNAME", U.UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", U.password);
            cmd.Parameters.AddWithValue("@TYPE", 4);
        

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

        }

        public void UpdateAllAgencies(Agency agency, string username)
        {

            string query = "update Agency set Agencyname = @name , email = @email , Location = @location where username = @username ";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@name", agency.Name);
            cmd.Parameters.AddWithValue("@email", agency.email);
            cmd.Parameters.AddWithValue("@location", agency.location);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
        }

        public object return_info(string username)
        {
            string query = "SELECT Agencyname, email ,Location FROM AGENCY WHERE username= @username";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            DataTable dt = new DataTable();

            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void Deletedrecord(string username)
        {
            string Query = "delete from _User where username = @username ; delete  from Agency where username = @username ;";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
        }
        public void DeletedContact(string username, string message)
        {
            string Query = "delete from Contact  where _Message= @message and Email= @username";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
			cmd.Parameters.AddWithValue("@message", message);
			try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
        }

        public void DeletedrecordManager(string username)
        {
            string Query = "delete from _User where username = @username ;";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
        }

        // nada added for all orders 
        public void DeleteOrder(int OrderCode)
        {
            string q = "DELETE FROM AnOrder WHERE OrderCode= @OrderCode";

            SqlCommand cmd = new SqlCommand(q, Connection);
            cmd.Parameters.AddWithValue("@OrderCode", OrderCode);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
        }
        public string returnUsername(string email)
        {
            string q = "select username from Agency where email = @email";
            SqlCommand cmd = new SqlCommand(q, Connection);

            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                Connection.Open();

                getUsername = (string)cmd.ExecuteScalar();

                return getUsername;
            }
            catch
            {
                return " ";
            }
            finally
            {
                Connection.Close();
            }

        }
        
        public int GetMax(string table_name, string column)
        {
            string q = "select max(@id) from @table ";
            SqlCommand cmd = new SqlCommand(q, Connection);

            cmd.Parameters.AddWithValue("@table", table_name);
            cmd.Parameters.AddWithValue("@id", column);

            try
            {
                Connection.Open();
                int max = (int)cmd.ExecuteScalar();

                return max;
            }
            catch
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable LoadBundlesInfo()
        {
            string query = "select *  from  Bundle";
            SqlCommand cmd = new SqlCommand(query, Connection);

            DataTable dt = new DataTable();

            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable ReadBundleRow(int Id)   //***
        {
            string Q = "select * from Bundle where BundleId= " + @Id;
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
           
        }
        public DataTable ReadCategories()   //***
        {
            string Q = "Select * from Categories";
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable ReadProduct()
        {
            string Q = "Select * from Product";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable ReadCategoryForAddProduct()
        {
            string Q = "Select * from Categories";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable ReadProductspecificcategory(string category)
        {
            if (category == "*")
            {
                string Q = "Select * from Product";
                SqlCommand cmd = new SqlCommand(Q, Connection);
                DataTable dt = new DataTable();
                try
                {
                    Connection.Open();

                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
                catch (SqlException ex)
                {
                    return dt;
                }
                finally
                {
                    Connection.Close();
                }

            }
            else
            {


                string Q = "select * from Product where category in( Select id from Categories where title = @category);";
                SqlCommand cmd = new SqlCommand(Q, Connection);
                cmd.Parameters.AddWithValue("@category", category);
                DataTable dt = new DataTable();
                try
                {
                    Connection.Open();

                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
                catch (SqlException ex)
                {
                    return dt;
                }
                finally
                {
                    Connection.Close();
                }
            }

        }
        public string getTitleCategory(int id)
        {
            string q = "select title  from categories where id = @id;";
            SqlCommand cmd = new SqlCommand(q, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                Connection.Open();
                string max = (string)cmd.ExecuteScalar();

                return max;
            }
            catch
            {
                return " ";
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable ReadProductRow(int id)   //***
        {
            string Q = "Select * from Product where PId= @id";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                //return dt;
            }
            catch (SqlException ex)
            {
                //return dt;
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public DataTable ReadCart(string username)
        {
            string Q = "select * from cart where username= @username";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);

            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable ReadCartGuest(string username)
        {
            string Q = "SELECT * FROM CartGuest WHERE id = @id";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@id", username);

            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void AddProductToCart(string username, string id, int Qu, string sh, int t)   //***
        {
            string Q = "insert into cart values(@username, @id,@q,@sh,@t,null)";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@q", Qu);
            cmd.Parameters.AddWithValue("@sh", sh);
			cmd.Parameters.AddWithValue("@t", t);

			try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }

        }

        public void AddProductToCartGuest(string username, string id, int Qu, string sh)   //***
        {
            string Q = "insert into CartGuest values(@username, @id,@q,@sh)";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@q", Qu);
            cmd.Parameters.AddWithValue("@sh", sh);

            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }

        }
        public void UpdateCart(string id, int Qu, string username,string shipping)   //***
        {
            string Q = "update cart set quantity = @q , Shipping=@sh where productid = @id and username=@username ";
            string Q2 = "update cart set Shipping=@sh where username=@username ";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            SqlCommand cmd2 = new SqlCommand(Q2, Connection);

            cmd.Parameters.AddWithValue("@q", Qu);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@sh", shipping);
            cmd2.Parameters.AddWithValue("@username", username);
            cmd2.Parameters.AddWithValue("@sh", shipping);


            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }

        }
        public void UpdateCartGuest(string pro, int Qu, string username, string shipping)   //***
        {
            string Q = "update CartGuest set quantity = @q , Shipping=@sh where productid = @pro and id=@username";
            string Q2 = "update CartGuest set Shipping=@sh where id=@username ";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            SqlCommand cmd2 = new SqlCommand(Q2, Connection);

            cmd.Parameters.AddWithValue("@q", Qu);
            cmd.Parameters.AddWithValue("@pro", pro);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@sh", shipping);
            cmd2.Parameters.AddWithValue("@username", username);
            cmd2.Parameters.AddWithValue("@sh", shipping);


            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }

        }




        public int countProductsinBundle(int id)   //***
        {
            string Q = "select count(*) from Bundle_Product where Bundle_Product.Bundle_ID= " + id;
            int c = 0;
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                c = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return c;
        }

        public DataTable ProductsOfThisBundle(int Id)   //***
        {
            string Q = "select p.PName,p.Pimage,p.PId from Bundle_Product BP, Product p where BP.product_id=p.PId and BP.Bundle_ID= " + @Id;
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public DataTable ProductsOfBundleCart(int Id)   //***
        {
            string Q = "select price, _Name, img from Bundle  where BundleId= @id";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@id", Id);
            try
            {
                Connection.Open();
                
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public void Insert_New_Bundle(Bundle bundle)
        {
            string Q = "insert Into Bundle(price,level,BundleDescription,_Name,img) values(@bundle.price,@bundle.level,@bundle.BundleDescription,@bundle._Name,@bundle.img);";
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                bundle.BundleId = Convert.ToString( GetMax("Bundle", "BundleId") + 1);
                cmd.Parameters.Add("@bundle.price", SqlDbType.Int).Value = bundle.price;
                cmd.Parameters.Add("@bundle.level", SqlDbType.VarChar).Value = bundle.level;
                cmd.Parameters.Add("@bundle.BundleDescription", SqlDbType.Int).Value = bundle.Description;
                cmd.Parameters.Add("@bundle._Name", SqlDbType.Int).Value = bundle.Name;
                cmd.Parameters.Add("@bundle.img", SqlDbType.Char).Value = bundle.img;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable AllProduct()   //***
        {
            string Q = "select PName,PId from product";
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
		public DataTable ProductsNotInThisBundle(int BundleId)   //** for checkbox Edit Bundle
		{
			string Q = "SELECT pro.PName, pro.PId, pro.Pimage, pro.price_in_bundle FROM product as pro WHERE pro.PId NOT in (SELECT Bun.product_id FROM Bundle_Product as Bun WHERE Bun.Bundle_ID= " + BundleId + ");";
			DataTable dt = new DataTable();
			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);

				dt.Load(cmd.ExecuteReader());
				return dt;
			}
			catch (SqlException ex)
			{
				return dt;
			}
			finally
			{
				Connection.Close();
			}
		}
		public DataTable ProductsInThisBundle(int BundleId)   //** for checkbox Edit Bundle
		{
			string Q = "SELECT pro.PName, pro.PId, pro.Pimage FROM product as pro WHERE pro.PId in (SELECT Bun.product_id FROM Bundle_Product as Bun WHERE Bun.Bundle_ID= " + BundleId + ");";
			DataTable dt = new DataTable();
			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);

				dt.Load(cmd.ExecuteReader());
				return dt;
			}
			catch (SqlException ex)
			{
				return dt;
			}
			finally
			{
				Connection.Close();
			}
		}

		public void DeleteProduct(string PId)
        {
            string q = " UPDATE Bundle SET price = price - ( SELECT price_in_bundle FROM Product WHERE PId = @PId ) WHERE BundleID IN ( SELECT bundle_id FROM Bundle_Product WHERE product_id = @PId );                    DELETE FROM Contain WHERE PId = @PId; DELETE FROM Cart WHERE productid = @PId;DELETE FROM Cart WHERE productid = @PId;DELETE FROM Product_Photoes WHERE product_id = @PId;DELETE FROM Bundle_Product WHERE product_id = @PId ; DELETE FROM FeedBack WHERE PId= @PId ; DELETE FROM OrderFor WHERE PId= @PId ; DELETE FROM Product WHERE PId = @PId;";

            //SqlCommand cmd = new SqlCommand(q, Connection);
            //cmd.Parameters.AddWithValue("@PId", PId);

            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(q, Connection);
                cmd.Parameters.AddWithValue("@PId", PId);
                //cmd.Parameters.AddWithValue("@PId", PId);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
        }
        public void DeleteCategory(string PId)
        {
            string q = @"
        DECLARE @PID INT = (SELECT PId FROM Product WHERE category = @catId);

     DELETE FROM Contain WHERE PId = @PId;DELETE FROM Cart WHERE productid = @PId;DELETE FROM CartGuest WHERE productid = @PId;DELETE FROM Product_Photoes WHERE product_id = @PId;DELETE FROM Bundle_Product WHERE product_id = @PId ; DELETE FROM FeedBack WHERE PId= @PId ; DELETE FROM OrderFor WHERE PId= @PId ; DELETE FROM Product WHERE PId = @PId;

        DELETE FROM Categories WHERE id = @catId;";

            try
            {
                Connection.Open();

                using (SqlTransaction transaction = Connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand(q, Connection, transaction);
                    cmd.Parameters.AddWithValue("@catId", PId);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (SqlException ex)
            {
                // Handle exception
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable LoadProductInfo()
        {
            string query = "select *  from  Product";
            SqlCommand cmd = new SqlCommand(query, Connection);

            DataTable dt = new DataTable();

            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }



        }
        public void AddProductToBundle(int idProduct, int idbundle)
        {
            string Q = "insert into Bundle_Product(product_id,Bundle_ID) values(@product_id,@Bundle_ID);";
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                cmd.Parameters.AddWithValue("@product_id", idProduct);
                cmd.Parameters.AddWithValue("@Bundle_ID", idbundle);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
        }
		public void DeleteProductsFromBundle(int idProduct, int idbundle)   //I added when I worked on checkbox
		{
			string Q = "DELETE FROM Bundle_Product WHERE product_id = @product_id and Bundle_ID = @Bundle_ID;";
			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);
				cmd.Parameters.AddWithValue("@product_id", idProduct);
				cmd.Parameters.AddWithValue("@Bundle_ID", idbundle);

				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{

			}
			finally
			{
				Connection.Close();
			}
		}
		public void UpdateBundlePriceWhenAddNewProduct(int idProduct, int idbundle)  //Bundle price
		{
			string Q = "UPDATE Bundle SET price = price + ( SELECT price_in_bundle FROM Bundle_Product JOIN Product ON Bundle_Product.product_id = Product.PId WHERE Bundle_Product.bundle_id = @Bundle_ID AND Bundle_Product.product_id = @product_id ) WHERE BundleID = @Bundle_ID ;";
			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);
				cmd.Parameters.AddWithValue("@product_id", idProduct);
				cmd.Parameters.AddWithValue("@Bundle_ID", idbundle);

				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{

			}
			finally
			{
				Connection.Close();
			}
		}
		public void UpdateBundlePriceWhenDeleteProduct(int idProduct, int idbundle)  //Bundle price
		{
			string Q = "UPDATE Bundle SET price = price - ( SELECT price_in_bundle FROM Bundle_Product JOIN Product ON Bundle_Product.product_id = Product.PId WHERE Bundle_Product.bundle_id = @Bundle_ID AND Bundle_Product.product_id = @product_id ) WHERE BundleID = @Bundle_ID ;";
			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);
				cmd.Parameters.AddWithValue("@product_id", idProduct);
				cmd.Parameters.AddWithValue("@Bundle_ID", idbundle);

				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{

			}
			finally
			{
				Connection.Close();
			}
		}

		public DataTable Deletefromcart(int id, string username, int t)
        {
            DataTable dt = new DataTable();
            string Q = "delete from cart where Productid = @id and username= @username and _type=@t";
            string Q2 = "select * from Cart where username= @username";

            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);
			cmd.Parameters.AddWithValue("@t", t);
			SqlCommand cmd2 = new SqlCommand(Q2, Connection);
            cmd2.Parameters.AddWithValue("@username", username);
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
                dt.Load(cmd2.ExecuteReader());
                return dt;
             }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable DeletefromcartGuest(int id, string username)
        {
            DataTable dt = new DataTable();
            string Q = "delete from CartGuest where Productid = @id and id= @username";
            string Q2 = "select * from CartGuest where id= @username";

            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);
            SqlCommand cmd2 = new SqlCommand(Q2, Connection);
            cmd2.Parameters.AddWithValue("@username", username);
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
                dt.Load(cmd2.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void insertSubscribe(string email)
        {
            string Q = "insert into Subscribed values(@email)";

            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
        }

        public string ReturnCategoryForProduct(int id)
        {
            string q = "select title from Categories where id=@id";
            SqlCommand cmd = new SqlCommand(q, Connection);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();



                return (string)cmd.ExecuteScalar();
            }
            catch
            {
                return " ";
            }
            finally
            {
                Connection.Close();
            }

        }

        public int CountFeedBackProduct(int id)   //***
        {
            string Q = "select count(*)  from FeedBack f,Product p where f.PId=p.PId and p.PId= " + id;
            int c = 0;
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                c = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return c;
        }

        public void Insert_Feedback(string user, int id,int num)
        {
            string Q = "insert into FeedBack values (@user,@id,@number);";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("user", user);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("number", num);

            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
        }


        public void Insert_Contact(Contact_Us contactcs)
        {
            string Q = "insert into Contact values (@_Name, @Email,@_Subject,@_Message)";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.Add("@_Name", SqlDbType.VarChar).Value = contactcs._Name;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = contactcs.Email;
            cmd.Parameters.Add("@_Subject", SqlDbType.VarChar).Value = contactcs._Subject;
            cmd.Parameters.Add("@_Message", SqlDbType.VarChar).Value = contactcs._Message;
            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable loadTableofContact()
        {
            DataTable dt = new DataTable();
            string queury = "select * from Contact";
            SqlCommand cmd = new SqlCommand(queury, Connection);
            try
            {
                Connection.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }



        }

        public int AVGRATING(int id)   //***
        {
            string Q = "select AVG(Rate) from FeedBack where PId = " + id;
            int c = 0;
            if (CountFeedBackProduct(id) == 0)
            {
                return 0;
            }
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                c = (int)cmd.ExecuteScalar();
                return c;
            }
            catch (SqlException ex)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }

        }

        public DataTable ReturnRatesForProduct(int id)   //***
        {
            string Q = "select u.username,p.PId,f.Rate from FeedBack f,Product p ,_User u where f.PId=p.PId and u.username=f.Username and p.PId =" + id;
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                dt.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return dt;

        }

        public DataTable ImgsForProduct(int id)   //***
        {
            string Q = "select * from Product_Photoes where product_Id = " + id;
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                dt.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public void AddNewProduct(Product product)
        {

            string query = "insert into Product (PId,PName,price,price_in_bundle,Quantity,color,salePercentage,category,AdditionalNotes,Pimage) values(@PId,@PName,@price,@price_in_bundle,@Quantity,@color,@salePercentage,@category,@AdditionalNotes,@Pimage);\r\n";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@PId", product.PId);
            cmd.Parameters.AddWithValue("@PName", product.PName);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@price_in_bundle", product.price_in_bundle);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@color", product.color);
            cmd.Parameters.AddWithValue("@salePercentage", product.salePercentage);
            cmd.Parameters.AddWithValue("@category", product.category);
            if(string.IsNullOrEmpty(product.AdditionalNotes))
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", " ");
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", product.AdditionalNotes);
            }
           
            cmd.Parameters.AddWithValue("@Pimage", product.Pimage);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

        }
		public void AddImgNewProduct(int idd,byte[] imgg,int Img_Num)
		{

			string query = "insert into Product_Photoes (product_Id,p_Img,Img_Num) values(@product_Id,@p_Img,@Img_Num);";
			SqlCommand cmd = new SqlCommand(query, Connection);
			cmd.Parameters.AddWithValue("@product_Id", idd);
			cmd.Parameters.AddWithValue("@p_Img", imgg);
			cmd.Parameters.AddWithValue("@Img_Num", Img_Num);

			try
			{
				Connection.Open();
				cmd.ExecuteNonQuery();

			}
			catch
			{

			}
			finally
			{
				Connection.Close();
			}

		}
		public void EditImgNewProduct(int idd, byte[] imgg, int Img_Num)
		{

			string query = "UPDATE Product_Photoes SET p_Img=@p_Img WHERE product_Id=@product_Id and Img_Num=@Img_Num;";
			SqlCommand cmd = new SqlCommand(query, Connection);
			cmd.Parameters.AddWithValue("@product_Id", idd);
			cmd.Parameters.AddWithValue("@p_Img", imgg);
			cmd.Parameters.AddWithValue("@Img_Num", Img_Num);

			try
			{
				Connection.Open();
				cmd.ExecuteNonQuery();

			}
			catch
			{

			}
			finally
			{
				Connection.Close();
			}

		}
		public void AddImgNewUser(byte[] imgg)
        {

            string query = "UPDATE _User SET img = @p_Img WHERE UserType=1;";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@p_Img", imgg);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

        }
		public void Edit_Bundle(string _Name, string BundleDescription,string BundleId)
		{

			string query = "UPDATE Bundle SET BundleDescription=@BundleDescription,_Name=@_Name WHERE BundleId=@BundleId;";
			SqlCommand cmd = new SqlCommand(query, Connection);
			cmd.Parameters.AddWithValue("@BundleDescription", BundleDescription);
			cmd.Parameters.AddWithValue("@_Name", _Name);
			cmd.Parameters.AddWithValue("@BundleId", BundleId);

			try
			{
				Connection.Open();
				cmd.ExecuteNonQuery();

			}
			catch
			{

			}
			finally
			{
				Connection.Close();
			}

		}
		public void Edit_Product(Product pro)
		{

			string query = "UPDATE Product SET Pimage=@Pimage, PName=@PName, price=@price,Quantity=@Quantity,color=@color, salePercentage=@salePercentage,category=@category,AdditionalNotes=@AdditionalNotes WHERE PId=@PId;";
			SqlCommand cmd = new SqlCommand(query, Connection);
			cmd.Parameters.AddWithValue("@PId", pro.PId);
			cmd.Parameters.AddWithValue("@PName", pro.PName);
			cmd.Parameters.AddWithValue("@price", pro.price);
			cmd.Parameters.AddWithValue("@Quantity", pro.Quantity);
			cmd.Parameters.AddWithValue("@color", pro.color);
			cmd.Parameters.AddWithValue("@salePercentage", pro.salePercentage);
			cmd.Parameters.AddWithValue("@category", pro.category);
			cmd.Parameters.AddWithValue("@AdditionalNotes", pro.AdditionalNotes);
			cmd.Parameters.AddWithValue("@Pimage", pro.Pimage);

			try
			{
				Connection.Open();
				cmd.ExecuteNonQuery();

			}
			catch
			{

			}
			finally
			{
				Connection.Close();
			}

		}
		public int GetMaxProductId()
        {
            int max = -1;
            string Q = "Select Max(PId) From Product";
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                if (string.IsNullOrEmpty(Convert.ToString(cmd.ExecuteScalar()))) 
                {
                    return 1;
                }
                max = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex) { }
            finally { Connection.Close(); }
            return max + 1;
        }
        public int GetMaxBundleId()
        {
            int max = -1;
            string Q = "Select Max(BundleId) From Bundle";
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
                max = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex) { }
            finally { Connection.Close(); }
            return max + 1;
        }
        public void AddNewBundle(Bundle bundle)
        {
            string query = "insert into Bundle values(@BundleId,@price,@level,@BundleDescription,@_Name,@img);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@BundleId", bundle.BundleId);
            cmd.Parameters.AddWithValue("@price", bundle.price);
            cmd.Parameters.AddWithValue("@level", bundle.level);
            cmd.Parameters.AddWithValue("@BundleDescription", bundle.Description);
            cmd.Parameters.AddWithValue("@_Name", bundle.Name);
            cmd.Parameters.AddWithValue("@img", bundle.img);


            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable ReadBundle()
        {
            string Q = "select * from Bundle";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }


        }
        public DataTable ReadSearchProject(string search)
        {
            string Q = "SELECT * FROM Product WHERE PName LIKE '%' + @search + '%' OR color LIKE '%' + @search + '%' OR category LIKE '%' + @search + '%' OR AdditionalNotes LIKE '%' + @search + '%'";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@search", search);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public List<string> getbest3products()
        {
            DataTable dt =new DataTable();
            List <string> products = new List<string>();
			string Q = "SELECT TOP 3 Max(SailedNum) AS TotalSailedNum, PName FROM Product GROUP BY PName ORDER BY TotalSailedNum DESC;";

			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);
				

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    products.Add(sdr["PName"].ToString());
                }
			}
			catch //(Exception ex)
			{
                //throw ex;
			}
			finally
			{
				Connection.Close();
			}
            return products;
		}
		public List<string> QuantityProduct()
		{
			DataTable dt = new DataTable();
			List<string> products = new List<string>();
			string Q = "SELECT distinct PName FROM Product";

			try
			{
				Connection.Open();
				SqlCommand cmd = new SqlCommand(Q, Connection);
				//cmd.CommandType= CommandType.StoredProcedure;

				SqlDataReader sdr = cmd.ExecuteReader();

				while (sdr.Read())
				{
					products.Add(sdr["PName"].ToString());
				}
			}
			catch //(Exception ex)
			{
				//throw ex;
			}
			finally
			{
				Connection.Close();
			}
			return products;
		}
		public DataTable ReadUser(string username)
        {

            string Q = "select * from _User where username = @username";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);

            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void updatepassword(string newpassword, string username)
        {
           
                string Q = " update _User  set userPassword = @newpassword where username=@username ";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@newpassword", newpassword);
            cmd.Parameters.AddWithValue("@username", username);



            try
            {
                Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
               
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable ReadClient(string username)
        {

            string Q = "select * from Client where username = @username";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);

            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void UsersAdress(Adress adress, string username)
        {
            string query = "insert into Adress values(@username,@zip,@gov,@city,@street,@no,@floor,@flat,@Not);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@zip", adress.Zipcode);
            cmd.Parameters.AddWithValue("@gov", adress.Gov);
            cmd.Parameters.AddWithValue("@city", adress.City);
            cmd.Parameters.AddWithValue("@street", adress.Street);
            cmd.Parameters.AddWithValue("@no", adress.Buildingno);
            cmd.Parameters.AddWithValue("@floor", adress.Floor);
            cmd.Parameters.AddWithValue("@flat", adress.Flat);
			cmd.Parameters.AddWithValue("@Not", adress.Notes);



			try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
			{

            }
            finally
            {
                Connection.Close();
            }

        }
		public int TotalItem(string id)   //***
        {
            string Q = "select sum(Quantity) from Cart where username=@username ";
            int c = 0;
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", id);
      
            try
            {
                Connection.Open();
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (int)result;
                }


            }
            catch (SqlException ex)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
         
        }
        public int TotalItemGuest(string id)   //***
        {
            string Q = "select sum(quantity) from CartGuest where id=@username ";
            int c = 0;
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", id);

            try
            {
                Connection.Open();
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (int)result;
                }


            }
            catch (SqlException ex)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }

        }
        public DataTable ReadAdress(string username)
        {

            string Q = " select * from Adress where username=@username";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);

            DataTable dt = new DataTable();
            try
            {
                Connection.Open();

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                return dt;
            }
            finally
            {
                Connection.Close();
            }
        }
		public DataTable ReadBudle(int BundleId)
		{

			string Q = " select * from Bundle where BundleId=@BundleId";
			SqlCommand cmd = new SqlCommand(Q, Connection);
			cmd.Parameters.AddWithValue("@BundleId", BundleId);

			DataTable dt = new DataTable();
			try
			{
				Connection.Open();

				dt.Load(cmd.ExecuteReader());
				return dt;
			}
			catch (SqlException ex)
			{
				return dt;
			}
			finally
			{
				Connection.Close();
			}
		}
		public DataTable ReadProduct(int PId)
		{

			string Q = "select * from Product where PId=@PId";
			SqlCommand cmd = new SqlCommand(Q, Connection);
			cmd.Parameters.AddWithValue("@PId", PId);

			DataTable dt = new DataTable();
			try
			{
				Connection.Open();

				dt.Load(cmd.ExecuteReader());
				return dt;
			}
			catch (SqlException ex)
			{
				return dt;
			}
			finally
			{
				Connection.Close();
			}
		}
		public DataTable ReadProduct_Imgs(int product_Id)
		{

			string Q = "select * from Product_Photoes where product_Id=@product_Id";
			SqlCommand cmd = new SqlCommand(Q, Connection);
			cmd.Parameters.AddWithValue("@product_Id", product_Id);

			DataTable dt = new DataTable();
			try
			{
				Connection.Open();

				dt.Load(cmd.ExecuteReader());
				return dt;
			}
			catch (SqlException ex)
			{
				return dt;
			}
			finally
			{
				Connection.Close();
			}
		}
		public int maxGuestID()
        {
            string query = "SELECT ISNULL(MIN(id), MAX(id)+1) FROM Guest WHERE id NOT IN (SELECT ID FROM CartGuest);";
            SqlCommand cmd = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void AddGuest(int num)
        {
            string query = "INSERT INTO Guest  VALUES (@username, GETDATE());";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@username", num);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                Connection.Close();
            }
        }
        public void DeleteoldGuest()
        {

            string query = "DELETE FROM CartGuest WHERE ID IN (SELECT id FROM Guest WHERE InsertionTime < DATEADD(MINUTE, -30, GETDATE())); DELETE FROM Guest WHERE InsertionTime < DATEADD(MINUTE, -30, GETDATE());     ";
            SqlCommand cmd = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
               
            }
            finally
            {
                Connection.Close();
            }
        }
        public int GetMaxIdCategory()
        {
            string query = "SELECT MAX(id) FROM categories";
            SqlCommand cmd = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (int)result;
                }
            }
            catch (SqlException ex)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void AddCategory(int c,string title)
        {
            string query = "INSERT INTO Categories  VALUES (@id, @title);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@id", c);
            cmd.Parameters.AddWithValue("@title", title);
            

            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
                Connection.Close();
            }
        }
		public void addpromocode(string c, int title)
		{
			string query = "INSERT INTO promocode  VALUES (@id, @title);";
			SqlCommand cmd = new SqlCommand(query, Connection);
			cmd.Parameters.AddWithValue("@id", c);
			cmd.Parameters.AddWithValue("@title", title);


			try
			{
				Connection.Open();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{

			}
			finally
			{
				Connection.Close();
			}
		}

	}

}
