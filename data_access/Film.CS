using System.Text.Json.Serialization;

public class Film
{
    public string Title;
    public List<string> Genres;
    public string Director;
    public int ReleaseYear;
    public int FilmRunTime;
    public double FilmPrice = 0;
    public double FilmRating = 5;
    public List<string> CinemaAudience;


    [JsonConstructor]
    public Film(string title, int runtime, double price, double filmrating, List<string> genres = null!, string director = "unknown", List<string> cinemaAudience = null!)
    {
        this.Genres = new List<string>() { };
        if (genres is not null) this.Genres = genres;
        this.Title = title;
        this.FilmRunTime = runtime;
        this.FilmPrice = price;
        this.FilmRating = filmrating;
        this.Director = director;
        this.CinemaAudience = cinemaAudience;
    }

    public void Add_genre(string genre)
    {
        this.Genres.Add(genre);
    }

    public void AddCinemaAudience(Customer customer)
    {

        CinemaAudience.Add("Customer ID " + customer.ID + " Customer Name " + customer.Name);
    }


}