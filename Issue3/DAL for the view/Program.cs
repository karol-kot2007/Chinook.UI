using Microsoft.EntityFrameworkCore;

namespace Chinook.ConsoleApp
{
  public class AlbumTrack
  {
    public int ArtistId { get; set; }
    public string artistName { get; set; }
    public int AlbumId { get; set; }
    public int TrackId { get; set; }
    public string AlbumName { get; set; }
    public string TrackName { get; set; }
  }

  public class Track
  {
    public int GenreId { get; set; }
    public int MediaTypeId { get; set; }
    public int AlbumId { get; set; }
    public int TrackId { get; set; }
    public string Name { get; set; }
    //public string Composer { get; set; }
    public int Milliseconds { get; set; }
    public int Bytes { get; set; }
    public float UnitPrice { get; set; }

  }

  public class Artist
  {
    public string Name { get; set; }
    public int ArtistId { get; set; }
  }
  public class ArtistContext : DbContext
  {

    //private static object chinook;
    // public DbSet<AlbumTrack> AlbumTracks1222 {  get; set; }  
    public DbSet<Track> tracks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<AlbumTrack> AlbumTracks1222 { get; set; }
    public static string chinookPath = "chinook.db";
    public string DbPath { get; }

    public ArtistContext()
    {
      //var folder = Environment.SpecialFolder.LocalApplicationData;
      //var path = Environment.GetFolderPath(folder);
      //DbPath = System.IO.Path.Join(path, "chinook.db");
      DbPath = chinookPath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

      options.UseSqlite($"Data Source={chinookPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Track>().HasKey(x => x.TrackId);
      modelBuilder.Entity<Artist>().HasKey(x => x.ArtistId);
      modelBuilder.Entity<AlbumTrack>().HasKey(x => x.AlbumId);
      //  modelBuilder.Entity<AlbumTrack>().HasKey(x => x.ArtistId);
    }
    //public void Main(string[] args)
    //{
    //  Console.WriteLine("h");
    //  //Console.WriteLine($"Database path: {chinookPath}.");
    //  // Console.WriteLine("Querying for a blog");
    //  //  var Artist = chinook; 
    //  //.OrderBy(a => a.ArtistId)
    //  //  .First();
    //}
    [STAThread]
    static void Main()
    {
      Console.WriteLine($"Database path: {chinookPath}.");
    //  Console.WriteLine("Querying for a blog");
      var cont = new ArtistContext();

      foreach (var art in cont.tracks)
      {
        //1. load all tracks for a given artist / album using the EF context entities(LINQ)
        //Console.WriteLine(" genreID "+art.GenreId + " ,albumid " + art.AlbumId +  " ,tr id " + art.TrackId  +" ,bytes "+ art.Bytes + " ,price "+ art.UnitPrice + ",miliseconds "+art.Milliseconds+" ,Name is : "+art.Name);
       

      }
      foreach(var art in cont.AlbumTracks1222)
      { //2. load all tracks for a given artist/album using the EF and the view created in the issue2
        //Console.WriteLine(" artist name is: "+art.artistName+ " albumName is: " + art.AlbumName+ " ArtistId is: " + art.ArtistId+ " albumId is: " + art.AlbumId+" trackId is: " + art.TrackId+ " trackName is: "  + art.TrackName);
      }
        //foreach (var tr in cont.Artists)
      //{
      // Console.WriteLine(" track name " + tr.Name + " artist Id " + tr.ArtistId);
      //}

    }
  }

}


