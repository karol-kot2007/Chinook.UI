﻿using Chinook.DAL.Models;
using System;
using System.Data.Entity;
using System.Security;

namespace Chinook.DAL { 
//{ 
//  public class ArtistContext : DbContext
//  {
//    public DbSet<Track> Tracks { get; set; }
//    public DbSet<Artist> Artists { get; set; }
//    public DbSet<AlbumTrack> AlbumTracks { get; set; }
//    public static string chinookPath = "chinook.db";
//    public string DbPath { get; }
//    public ArtistContext()
//    {
//      DbPath = chinookPath;

      

//    }

//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//      modelBuilder.Entity<Track>().HasKey(x => x.TrackId);
//      modelBuilder.Entity<Artist>().HasKey(x => x.ArtistId);
//      //modelBuilder.Entity<AlbumTrack>().HasNoKey();
//      base.OnModelCreating(modelBuilder);
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder options)
//    {
//      options.UseSqlite($"Data Source={chinookPath}");
//    }

//    //protected override void OnModelCreating(ModelBuilder modelBuilder)
//    //{
//    //  modelBuilder.Entity<Track>().HasKey(x => x.TrackId);
//    //  modelBuilder.Entity<Artist>().HasKey(x => x.ArtistId);
//    //  modelBuilder.Entity<AlbumTrack>().HasNoKey();
//    //}


//    [STAThread]
//    public static void Main()
//    {
//      Console.WriteLine($"Database path: {chinookPath}.");
//      var cont = new ArtistContext();
//      //1 load all tracks for a given artist / album using the EF context entities(LINQ)
//      foreach (var art in cont.Tracks)
//      {
//        //1. load all tracks for a given artist / album using the EF context entities(LINQ)
//        //Console.WriteLine(" genreID "+art.GenreId + " ,albumid " + art.AlbumId +  " ,tr id " + art.TrackId  +" ,bytes "+ art.Bytes + " ,price "+ art.UnitPrice + ",miliseconds "+art.Milliseconds+" ,Name is : "+art.Name + "composer is "+ art.Composer);
//      }
//      foreach (var art in cont.AlbumTracks)
//      { //2. load all tracks for a given artist/album using the EF and the view created in the issue2
//        Console.WriteLine(" artist name is: " + art.artistName + " albumName is: " + art.albumName/* + " artist id " + art.artistId + "albumId" + art.albumId + "TrackId" + art.trackId + "trackN" + art.trackName*/);
//      }
//      //load all tracks for a given artist / album using the EF and the view created in the issue2
//      //read AlbumTrack
    }

//  }
//}