using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
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
            //Connection =new SqlConnection( "Data Source=DESKTOP-AC88DP1\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True"); 
           
            Connection = new SqlConnection("Data Source=DESKTOP-1BNDCN7\\SQLEXPRESS;Initial Catalog=SMARTLY;Integrated Security=True ;TrustServerCertificate=True");
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
    }
}
