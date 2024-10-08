using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Linq;
using System.IO;
namespace Program
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
  public class Artist
  {
    public string Name { get; set; }
    public int ArtistId { get; set; }
  }
  public class ArtistContext : DbContext
  {

    //private static object chinook;
    // public DbSet<AlbumTrack> AlbumTracks1222 {  get; set; }  
    public DbSet<AlbumTrack> AlbumTracks1222 { get; set; }
    public DbSet<Artist> artists { get; set; }

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
      modelBuilder.Entity<AlbumTrack>().HasKey(x => x.ArtistId);
      modelBuilder.Entity<Artist>().HasKey(x => x.ArtistId);
      // modelBuilder.Entity<AlbumTrack>().HasKey(x => x.AlbumId);
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
      Console.WriteLine("Querying for a blog");
      var cont = new ArtistContext();
      var albT = new ArtistContext();

      foreach (var art in cont.AlbumTracks1222)
      {
       
        // Console.WriteLine(art.artistName + " " + art.AlbumId + " " + art.ArtistId + " " + art.AlbumId + " " + art.TrackId + " track Name " + art.TrackName);
      
      }
      foreach(var tr in cont.artists)
      { 
        Console.WriteLine(" track name "+tr.Name+" artist Id "+tr.ArtistId);
      }
      
    }
  }

}


