using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = @"server=DELL\SQLEXPRESS;Integrated security = true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }
        void FetchMoviesFromDatabase()
        {
            string strCmd = "Select* from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while(drMovies.Read())
                {
                    Console.WriteLine("Movie Id: " + drMovies[0].ToString());
                    Console.WriteLine("Movie Name: "+ drMovies[1]);
                    Console.WriteLine("Movie Duration: " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------------");
                }

            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
               
            }
            finally //will get executed if there is or there is no exception
            {
                con.Close();
            }
        }
        void FetchOneMovieFromDatabase()
        {
            string strCmd = "Select* from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                Console.WriteLine("Please enter the Id");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id: " + drMovies[0].ToString());
                    Console.WriteLine("Movie Name: " + drMovies[1]);
                    Console.WriteLine("Movie Duration: " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------------");
                }

            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);

            }
            finally //will get executed if there is or there is no exception
            {
                con.Close();
            }
        }
        void AddMovie()
        {
            //insert into tblMovie(name,duration) values('x-men',123.2)
            Console.WriteLine("Please enter the movie name");
            string mName = Console.ReadLine();
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "insert into tblMovie(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result>0)
                    Console.WriteLine("Movie inserted");
                else
                    Console.WriteLine("No not done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally //will get executed if there is or there is no exception
            {
                con.Close();
            }

        }
        void UpdateMovieDuration()
        {
            //update tblMovie set duration =@mduration where id=@mid
            Console.WriteLine("Please enter the Id");
            int id=Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set duration = @mduration where id = @mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid",id);
            cmd.Parameters.AddWithValue("@mduration", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Updated");
                else
                    Console.WriteLine("No not done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally //will get executed if there is or there is no exception
            {
                con.Close();
            }

        }
        void DeleteMovieFromDBUsingId()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            string strCmd = "Delete from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Deleted");
                else
                    Console.WriteLine("No not done");


            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);

            }
            finally //will get executed if there is or there is no exception
            {
                con.Close();
            }
        }
   
        void PrintMenu()
        {
            int choice;
            do 
            { 

            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Add the movies");
            Console.WriteLine("2. Read the entire movies");
            Console.WriteLine("3. Read the specific movie using id" );
            Console.WriteLine("4. Update the movie duration using id");
            Console.WriteLine("5. Delete the movie using id");
            Console.WriteLine("6. Exit");
            Console.WriteLine("----------------------------------");
            choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        FetchMoviesFromDatabase();
                        break;
                    case 3:
                        FetchOneMovieFromDatabase();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovieFromDBUsingId();
                        break;
                    case 6:
                        Console.WriteLine("Exiting....");
                        break;
                    default:
                        Console.WriteLine("invalid entry");
                        break;
                }
            } while (choice != 6);
        }
            
         static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Program program = new Program();
            //program.AddMovie();
            //program.FetchMoviesFromDatabase();
            //program.FetchOneMovieFromDatabase();
            // program.UpdateMovieDuration();
            //program.DeleteRowFromDBUsingId();
            program.PrintMenu();
            Console.ReadKey();
        }
    }
}
