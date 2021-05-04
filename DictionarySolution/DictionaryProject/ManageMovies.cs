using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryProject
{
    class ManageMovies
    {

        //List<Movie> movies;
        Dictionary<int, Movies> DictionaryMovie;
        public ManageMovies()
        {
            DictionaryMovie = new Dictionary<int, Movies>();
        }
        private int GenerateId()
        {
            if (DictionaryMovie.Count == 0)
                return 1;
            int id = DictionaryMovie[DictionaryMovie.Count - 1].Id;
            id++;
            return id;
        }
        public Movies CreateMovie()
        {
            Movies movie = new Movies();
            movie.Id = GenerateId();
            movie.TakeMovieDetails();
            return movie;
        }
        public int GetMovieIndexById(int id)
        {
            List<KeyValuePair<int, Movies>> mlist = DictionaryMovie.ToList();
            return mlist.FindIndex(m => m.Key == id);//Lambda Expression
        }
        public Movies UpdateMovieName(int id, string name)
        {
            Movies movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                DictionaryMovie[idx].Name = name;
                movie = DictionaryMovie[idx];
            }
            return movie;
        }
        public void PrintMovieById()
        {
            Console.WriteLine("Please enter the movie Id to be printed");
            int id = Convert.ToInt32(Console.ReadLine());
            int idx = GetMovieIndexById(id);
            if (idx >= 0)
                PrintMovie(DictionaryMovie[idx]);
            else
                Console.WriteLine("No such movie");
        }

        private void DeleteMovie()
        {
            Console.WriteLine("Please enter the movie id to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                DictionaryMovie.Remove(GetMovieIndexById(id));
            }
            catch (Exception e)
            {

                Console.WriteLine("Oops something went wrong. please try again");
            }
        }

        public Movies UpdateMovieDuration(int id, double duration)
        {
            Movies movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                DictionaryMovie[idx].Duration = duration;
                movie = DictionaryMovie[idx];
            }
            return movie;
        }

        private void PrintMovieById(int id)
        {
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                PrintMovie(DictionaryMovie[idx]);
            }
            else
                Console.WriteLine("No such Movie");
        }

        public void PrintAllMovies()
        {
            if (DictionaryMovie.Count == 0)
            {
                Console.WriteLine("No movies Present");
            }
            else
            {
                foreach (var item in DictionaryMovie.Keys)
                {
                    PrintMovie(DictionaryMovie[item]);
                }
            }
        }
        void AddMovies()
        {
            int choice = 0;
            do
            {
                Movies movie = CreateMovie();
                DictionaryMovie.Add(movie.Id, movie);
                Console.WriteLine("Do you wish to addanother movie?? if yes enter any number other than 0, to exit enter 0");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException format)
                {
                    Console.WriteLine("Not a correct input");
                }
            } while (choice != 0);
        }
        public void SortMovies()
        {
            if (DictionaryMovie.Count != 0)
            {
                DictionaryMovie.OrderBy(i => i.Key);
            }
            else
            {
                Console.WriteLine("No elemets to sort");
            }


            Console.WriteLine("No movies to be sorted");
        }
        public void PrintMovie(Movies movie)
        {
            Console.WriteLine("..........................");
            Console.WriteLine(movie);
            Console.WriteLine("...........................");
        }
        void UpdateMovie()
        {
            Console.WriteLine("Please enter the movie id For updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to update name or duation or both");
            string choice = Console.ReadLine();
            string name;
            double duration;
            switch (choice)
            {
                case "name":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    break;
                case "duration":
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid Entry for duration please try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;

                case "both":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid Entry for duration please try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Add a list of movies");
                Console.WriteLine("3. Update the movie");
                Console.WriteLine("4. delete the movie");
                Console.WriteLine("5. Print the movie by id");
                Console.WriteLine("6. Print all the movie");
                Console.WriteLine("7. Sort movies");
                Console.WriteLine("8. Exit the application");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Movies movie = CreateMovie();
                        DictionaryMovie.Add(movie.Id, movie);
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        UpdateMovie();
                        break;
                    case 4:
                        DeleteMovie();
                        break;
                    case 5:
                        PrintMovieById();
                        break;
                    case 6:
                        PrintAllMovies();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 8);
        }

        public static void Main(string[] a)
        {
            new ManageMovies().PrintMenu();
            Console.ReadKey();
        }

    }
}