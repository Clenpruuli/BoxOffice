using System;
using System.Collections.Generic;
using System.IO;

namespace BoxOffice
{
    class Program
    {
        class Movie
        {
            int id;
            string title;
            long lifeTimeGross;

            public Movie(int _id, string _title, long _lifeTimeGross)
            {
                id = _id;
                title = _title;
                lifeTimeGross = _lifeTimeGross;
            }

            public int Id { get { return id; } }
            public string Title { get { return title; } }
            public long LifeTimeGross { get { return lifeTimeGross; } }

        }

        class MovieList
        {
            List<Movie> movies;
            long totalLifeTimeGross;

            public MovieList()
            {
                movies = new List<Movie>();
                totalLifeTimeGross = 0;
            }

            public void AddMoviesToList(int id, string title, long gross)
            {
                Movie newMovie = new Movie(id, title, gross);
                movies.Add(newMovie);
            }

            public void PrintAllMovie()
            {
                foreach(Movie movie in movies)
                {
                    Console.WriteLine($"{movie.Id}. {movie.Title} has earned {movie.LifeTimeGross}");
                }
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"BoxOffice.txt";
            string fullfilePath = Path.Combine(filePath, fileName);

            //create an array of records from file
            string[] linesFromLines = File.ReadAllLines(fullfilePath);

            MovieList myMovies = new MovieList();

            //create a list of movies to store the movies objects from file.
            foreach(string line in linesFromLines)
            {
                //split the line to get the movie data
                string[] tempArray = line.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                int movieId = int.Parse(tempArray[0]);
                string movieTitle = tempArray[1];
                string totalGrossTemp = tempArray[2].Substring(1);
                Console.WriteLine(totalGrossTemp);
                long movieGross = long.Parse(totalGrossTemp);
                //add a movie to list
                myMovies.AddMoviesToList(movieId, movieTitle, movieGross);
            }

            myMovies.PrintAllMovie();
        }
    }
}
