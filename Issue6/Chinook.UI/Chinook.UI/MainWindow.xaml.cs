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
      //System.Collections.IList list = ar;
      //var r = context.AlbumTracks;

      AlbumInfoModel model = BuildModel(context, ar);
      //this.DataContext = model;
      var wnd = new AlbumInfoWindow();
      wnd.SetData(model);
      wnd.ShowDialog();

    }

    private static AlbumInfoModel BuildModel(ArtistContext context, List<DAL.Models.Artist> ar)
    {
      var model = new AlbumInfoModel();
      model.ArtistName = ar.First().Name;
      model.ArtistId = ar.First().ArtistId;
      var album = context.Albums.Where(a => a.ArtistId == model.ArtistId).First();
      model.Tracks = context.Tracks.Where(i => i.AlbumId == album.AlbumId).ToList();
      return model;
    }

    private void Button_Edit_Click(object sender, RoutedEventArgs e)
    {
       
    }
    
  }

}
