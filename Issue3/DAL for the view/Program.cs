using Chinook.DAL;
using Microsoft.EntityFrameworkCore;

namespace Chinook.ConsoleApp
{
  public class Program
  {
    [STAThread]
    static void Main()
    {
      var cont = new ArtistContext();
      //1 load all tracks for a given artist / album using the EF context entities(LINQ)
      foreach (var art in cont.Tracks)
      {
        //1. load all tracks for a given artist / album using the EF context entities(LINQ)
        //Console.WriteLine(" genreID "+art.GenreId + " ,albumid " + art.AlbumId +  " ,tr id " + art.TrackId  +" ,bytes "+ art.Bytes + " ,price "+ art.UnitPrice + ",miliseconds "+art.Milliseconds+" ,Name is : "+art.Name + "composer is "+ art.Composer);
      }
      foreach (var art in cont.AlbumTracks)
      { //2. load all tracks for a given artist/album using the EF and the view created in the issue2
        Console.WriteLine(" artist name is: " + art.artistName + " albumName is: ");
      }
      //load all tracks for a given artist / album using the EF and the view created in the issue2
      //read AlbumTrack
    }

  }



}


