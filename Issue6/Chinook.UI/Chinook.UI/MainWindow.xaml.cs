﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chinook.DAL;
using Chinook.DAL.Models;
namespace Chinook.UI
{
 public enum Mode
  {
    View, Edit
  }
  public partial class MainWindow : Window
  {
    
  

    public MainWindow()
    {
      InitializeComponent();
      Artist artist = new Artist();
      {
        //artist.NName = "Michael";
        //artist.ArtistId = 1;
      }


    }


   
    // System.Collections.IList list = ar;

    class Artist
    {
      public Artist()
      {

      }
      public string Name { get; set; }
      public int ArtistId { get; set; }
    }

    private void Button_View_Click(object sender, RoutedEventArgs e)
    {

      ArtistContext context = new ArtistContext();
      var ar = context.GetArtists();
      AlbumInfoModel model = BuildModel(context, ar);
   
      var wnd = new AlbumInfoWindow();
      wnd.DisplayMode=Mode.View;
      wnd.ShowWithData(model);
      

    }

    private static AlbumInfoModel BuildModel(ArtistContext context, List<DAL.Models.Artist> artists)
    {
      var model = new AlbumInfoModel();
      model.ArtistName = artists.First().Name;
      model.ArtistId = artists.First().ArtistId;
      var album = context.Albums.Where(a => a.ArtistId == model.ArtistId).First();
      model.Tracks = context.Tracks.Where(i => i.AlbumId == album.AlbumId).ToList();
      model.AlbumId = album.AlbumId;
      model.AlbumName = album.Title;
 
      Mode v=Mode.View;
      return model;
    }

    private void Button_Edit_Click(object sender, RoutedEventArgs e)
    {
      ArtistContext context = new ArtistContext();
      var ar = context.GetArtists();
    
      AlbumInfoModel model = BuildModel(context, ar);
     
      var wnd = new AlbumInfoWindow();
      wnd.DisplayMode=Mode.Edit; 
      wnd.ShowWithData(model);
 
    
    }
    
  }

}
