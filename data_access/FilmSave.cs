using System.Data.Common;
using Newtonsoft.Json;

class FilmSave
{
    public List<Film> Films = new() { };

    public static string PathName = "Movies.json";



    public static List<Film> ReadFilms()
    {
        if (File.Exists(PathName))
        {
            StreamReader reader = new(PathName);
            string filefromjson = reader.ReadToEnd();
            List<Film> films = JsonConvert.DeserializeObject<List<Film>>(filefromjson)!;
            reader.Close();
            return films;
        }
        else return new List<Film> { };
    }

    public void ReadJsonFile()
    {
        if (File.Exists(PathName))
        {
            StreamReader reader = new(PathName);
            string filefromjson = reader.ReadToEnd();
            List<Film> films = JsonConvert.DeserializeObject<List<Film>>(filefromjson)!;
            reader.Close();
            foreach (Film film in films)
            {
                Console.WriteLine();
                Console.WriteLine("Movie Information:");
                Console.WriteLine($"Title: {film.Title}");
                Console.WriteLine($"Genres: {string.Join(", ", film.Genres!)}");
                Console.WriteLine($"§Director: {film.Director}");
                Console.WriteLine($"Release Year: {film.ReleaseYear}");
                Console.WriteLine($"Film RunTime: {film.FilmRunTime} minutes");
                Console.WriteLine($"Film Price: Euro {film.FilmPrice}");
                Console.WriteLine($"Film Rating: {film.FilmRating}");
                Console.WriteLine();
            }
        }
    }

    public static void printfilmInfo(Film film)
    {
        Console.WriteLine();
        Console.WriteLine("Movie Information:");
        Console.WriteLine($"Title: {film.Title}");
        Console.WriteLine($"Genres: {string.Join(", ", film.Genres!)}");
        Console.WriteLine($"§Director: {film.Director}");
        Console.WriteLine($"Release Year: {film.ReleaseYear}");
        Console.WriteLine($"Film RunTime: {film.FilmRunTime} minutes");
        Console.WriteLine($"Film Price: Euro {film.FilmPrice}");
        Console.WriteLine($"Film Rating: {film.FilmRating}");
        Console.WriteLine();
    }

    public void AddToJson(Film filmToAdd)
    {
        List<Film> films = ReadFilms();
        films.Add(filmToAdd);
        StreamWriter writer = new(PathName);
        string list_to_json = JsonConvert.SerializeObject(films, Formatting.Indented);
        writer.Write(list_to_json);
        writer.Close();
    }

    public void AppendToJason(Film filmToAdd)
    {
        List<Film> films = ReadFilms();
        foreach (Film film in films)
        {

        }
        films.Add(filmToAdd);
        StreamWriter writer = new(PathName);
        string list_to_json = JsonConvert.SerializeObject(films, Formatting.Indented);
        writer.Write(list_to_json);
        writer.Close();
    }

    public static void AddCustomerToFilm(Film filmtoaddto, Customer customertoadd)
    {
        List<Film> films = ReadFilms();
        System.Console.WriteLine(filmtoaddto.Title);

        foreach (Film film in films)
        {
            System.Console.WriteLine(film.Title == filmtoaddto.Title);
            if (film.Title == filmtoaddto.Title)
            {
                System.Console.WriteLine(true);
                film.CinemaAudience.Add($"Customer ID {customertoadd.ID} Customer Name {customertoadd.Name}");
            }
        }
        StreamWriter writer = new(PathName);
        string list_to_json = JsonConvert.SerializeObject(films, Formatting.Indented);
        writer.Write(list_to_json);
        writer.Close();
    }
}