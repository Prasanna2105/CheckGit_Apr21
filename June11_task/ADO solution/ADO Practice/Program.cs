using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ADO_Practice
{
    class Program
    {
       
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values('Harry Potter',3,950)", con);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into tbl_Books values('Two States', 1, 650)";
            //cmd.Connection = con;
            string qry = "insert into tbl_Books values(@Title, @AuthorID, @Price)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Title", "Davinci Code");
            cmd.Parameters.AddWithValue("@AuthorID", 7);
            cmd.Parameters.AddWithValue("@Price", 400);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void SelectBooks()
        {

            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Books", con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["BooKID"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());

            con.Close();
            Console.ReadLine();
        }

        public void UpdateBooks()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update tbl_Books set Price=@Price where BookID=@BookID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Price", 560);
            cmd.Parameters.AddWithValue("@BookID", 1000);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteBooks()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete from tbl_Books where BookID=@BookID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BookID", 1009);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SelectAuthors()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            string qry = "select * from tbl_author";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(reader["AuthorID"] + " " + reader["AuthorName"]);
            con.Close();
        }
        public void InsertAuthors()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Insert into tbl_author(AuthorName) values(@AuthorName)";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@AuthorName", "AntonCheckov");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateAuthors()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update tbl_author set AuthorName=@AuthorName where AuthorID=@AuthorID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@AuthorName", "Charles Darwin");
            cmd.Parameters.AddWithValue("@AuthorID", 3);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAuthors()
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete from tbl_author where AuthorID=@AuthorID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@AuthorID", 3);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void InsertBooksSP(string title, int aid, double price)
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@Title";
            //p1.SqlDbType = SqlDbType.VarChar;
            //p1.Value = title;
            //cmd.Parameters.Add(p1);
            //SqlParameter p2 = new SqlParameter();
            //p2.ParameterName = "@AuthorID";
            //p2.SqlDbType = SqlDbType.Int;
            //p2.Value = aid;
            //cmd.Parameters.Add(p2);
            //SqlParameter p3 = new SqlParameter();
            //p3.ParameterName = "@Price";
            //p3.SqlDbType = SqlDbType.Money;
            //p3.Value = price;
            //cmd.Parameters.Add(p3);
            //con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateBooksSP(int id, double price)
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteBooksSP(int id)
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void InsertAuthorsSP(string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = AuthorName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateAuthorsSP(int id, string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_UpdateAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = AuthorName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAuthorsSP(int id)
        {
            SqlConnection con = new SqlConnection("data source = dell\\sqlexpress; database = BooksDb; integrated security=true");
            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            ////obj.BookSP("Angels & Demons", 7, 550);
            //obj.BookSP("Sivakamiyin Sabatham", 2, 970);
            //// obj.InsertBooks();

            //Program obj = new Program();
            //obj.UpdateBooksPrice();
            //obj.UpdateBooksPrice();
            //obj.SelectBooks();
            //obj.InsertBooks();
            //obj.UpdateBooks();
            //obj.DeleteBooks();

            //obj.SelectAuthors();
            //obj.InsertAuthors();
            //obj.UpdateAuthors();
            //obj.DeleteAuthors();
            
            //obj.InsertBooksSP("Sivakamiyin Sabatham",2,970);
            //obj.UpdateBooksSP(1000,430);
            //obj.DeleteBooksSP(1012);

            //obj.InsertAuthorsSP("Anton Checkov");
            obj.UpdateAuthorsSP(4,"Robin Singh");
            //obj.DeleteAuthorsSP(9);
        }
    }
}
