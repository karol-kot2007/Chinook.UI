using Chinook.DAL;
using Microsoft.EntityFrameworkCore;

namespace Chinook.ConsoleApp
{
  

 

  
  public class ArtistContext : DbContext
  {

    
    public DbSet<Track> tracks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<AlbumTrack> AlbumTracks1222 { get; set; }
    public static string chinookPath = "chinook.db";
    public string DbPath { get; }

    public ArtistContext()
    {
      
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
   
    }
    
    [STAThread]
    static void Main()
    {
      Console.WriteLine($"Database path: {chinookPath}.");
    
      var cont = new ArtistContext();

      foreach (var art in cont.tracks)
      {
        //1. load all tracks for a given artist / album using the EF context entities(LINQ)
        Console.WriteLine(" genreID "+art.GenreId + " ,albumid " + art.AlbumId +  " ,tr id " + art.TrackId  +" ,bytes "+ art.Bytes + " ,price "+ art.UnitPrice + ",miliseconds "+art.Milliseconds+" ,Name is : "+art.Name + "composer is "+ art.Composer);
       

      }
      foreach(var art in cont.AlbumTracks1222)
      { //2. load all tracks for a given artist/album using the EF and the view created in the issue2
        //Console.WriteLine(" artist name is: "+art.artistName+ " albumName is: " + art.AlbumName+ " ArtistId is: " + art.ArtistId+ " albumId is: " + art.AlbumId+" trackId is: " + art.TrackId+ " trackName is: "  + art.TrackName);
      }
      

    }
  }

}


