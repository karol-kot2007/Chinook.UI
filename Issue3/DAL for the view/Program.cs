﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Linq;
using System.IO;
namespace Program
{
  public class Artists
  {
    public int ArtistId { get; set; }
    public string Name { get; set; }
  }

  public class ArtistContext : DbContext
  {

    //private static object chinook;

    public DbSet<Artists> Artist { get; set; }

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
      
        
      foreach (var  art in cont.Artist)
      {
        Console.WriteLine(art.Name);
      }
    }
  }

}


