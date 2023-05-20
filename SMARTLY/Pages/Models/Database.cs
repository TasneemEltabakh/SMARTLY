﻿using Microsoft.AspNetCore.Http;
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
            //Connection = new SqlConnection("Data Source=DESKTOP-710ECC4;Initial Catalog=SMARTLY;Integrated Security=True");
            // Connection =new SqlConnection( "Data Source=DESKTOP-AC88DP1\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True"); 
            // Connection = new SqlConnection("Data Source=DESKTOP-1BNDCN7\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True; Trusted_Connection=True");

            // Connection = new SqlConnection("Data Source=DESKTOP-AC88DP1\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True");
            Connection = new SqlConnection("Data Source=DESKTOP-AC88DP1\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True"); 
        }
        public void SignUpNewMember(User U, Client C)
        {
            string query = "insert into _User values (@USERNAME,@PASSWORD,@TYPE); insert into Client values (@USERNAME,@email,@phonenumber);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@USERNAME", U.UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", U.password);
            cmd.Parameters.AddWithValue("@TYPE", 3);

      
            cmd.Parameters.AddWithValue("@USERNAME", U.UserName);
            cmd.Parameters.AddWithValue("@email", C.email);
            cmd.Parameters.AddWithValue("@phonenumber", C.phonenumber);

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
            SqlCommand cmd= new SqlCommand(queury, Connection);
            try
            {
                Connection.Open();
                 dt.Load( cmd.ExecuteReader());
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
            string queury = "select OrderCode,Username,OrderDate,AmountToPay from anorder";
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
          
            string query = "insert into _User values (@USERNAME,@PASSWORD,@TYPE); insert into Agency values (@usernameA,@email,@Agencyname,@Location);";
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

        public void UpdateAllAgencies(Agency agency, string username)
        {
          
            string query= "update Agency set Agencyname = @name , email = @email , Location = @location where username = @username ";
            SqlCommand cmd= new SqlCommand(query, Connection);
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
            SqlCommand cmd= new SqlCommand(Query, Connection);
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
            cmd.Parameters.AddWithValue("@OrderCode" , OrderCode);

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
            SqlCommand cmd= new SqlCommand(q, Connection);
            
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
            //SqlCommand cmd = new SqlCommand(Q, Connection);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(Q, Connection);
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
        public void AddProductToCart(string username, string id, int Qu)   //***
        {
            string Q = "insert into cart values(@username, @id,@q)";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@q", Qu);


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
        public void UpdateCart(int id,int Qu)   //***
        {
            string Q = "update cart set quantity = @q where productid = @id";
            SqlCommand cmd = new SqlCommand(Q, Connection);
            
            cmd.Parameters.AddWithValue("@q", Qu);
            cmd.Parameters.AddWithValue("@id", id);


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
            string Q = "select p.PName,p.Pimage from Bundle_Product BP, Product p where BP.product_id=p.PId and BP.Bundle_ID= " + @Id;
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

		public void DeleteProduct(string PId)
		{
			string q = "DELETE FROM Bundle_Product WHERE product_id = @PId ; DELETE FROM FeedBack WHERE PId= @PId ; DELETE FROM OrderFor WHERE PId= @PId ; DELETE FROM Product WHERE PId = @PId ";

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
			catch(SqlException ex)
			{

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
        public void Deletefromcart(string id)
        {
            string Q = "delete from cart where Productid = @id";
      
            SqlCommand cmd = new SqlCommand(Q, Connection);
            cmd.Parameters.AddWithValue("@id", id);
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
            string q = "select  title from Categories c,Product p where c.id=p.PId and p.PId = @id ;";
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
            return c;
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
			string Q = "select u.username,p.PId,f.Rate from FeedBack f,Product p ,_User u where f.PId=p.PId and u.username=f.Username and p.PId =" +id;
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

            string query = "insert into Product values(@PId,@PName,@price,@Quantity,@color,@salePercentage,@category,@AdditionalNotes,@Pimage);";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@PId", product.PId);
            cmd.Parameters.AddWithValue("@PName", product.PName);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@color", product.color);
            cmd.Parameters.AddWithValue("@salePercentage", product.salePercentage);
            cmd.Parameters.AddWithValue("@category", product.category);
            cmd.Parameters.AddWithValue("@AdditionalNotes", product.AdditionalNotes);
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
        
        public int GetMaxProductId()
        {
            int max = -1;
            string Q = "Select Max(PId) From Product";
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

    }
}
