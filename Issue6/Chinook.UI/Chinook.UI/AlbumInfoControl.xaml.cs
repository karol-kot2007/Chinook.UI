using Chinook.DAL;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using Chinook.DAL.Models;
using System.Windows.Media;
namespace Chinook.UI
{
  public partial class AlbumInfoControl : UserControl
  {
    public MediaPlayer Player { get; set; }
    public Mode DisplayMode { get; set; }
    public ArtistContext ArtistId { get;  set; }
    public Track LocalPath { get;  set; }
    
    public AlbumInfoControl()
    {
      InitializeComponent();
      Player = new MediaPlayer();
    }
    internal void Bind(AlbumInfoModel model, Mode mode, int currentAlb, int maxAlb)
    {
      GridAlbum.ItemsSource = model.Tracks;
      DisplayMode = mode;
      ArtistName.IsReadOnly = DisplayMode != Mode.Edit;
      AlbumName.IsReadOnly = DisplayMode != Mode.Edit;
      AlbumSwapper.setAlbumInfo(currentAlb, maxAlb);
    }

    private void dgUsers_AddingNewItem(object sender, AddingNewItemEventArgs e)
    {
   
    }

    private void Close_Button(object sender, RoutedEventArgs e)
    {
      System.Environment.Exit(0);
    }

    private void ok_Button(object sender, RoutedEventArgs e, ArtistContext ArtistId)
    {

    }

    private void PlayBtn_Click(object sender, RoutedEventArgs e)
    {
      //locql path zakodowac
      Track LocalPath = new Track();

      var obj = ((FrameworkElement)sender).DataContext as Track;
      int k = 0;
      k++;
      PlaySound();
    }

    
    private void PlaySound()
    {
      Uri uri = new Uri(@"C:\Users\Karol\Documents\songs\Michael Jackson - Smooth Criminal (Official Video).mp3");

      Player.Open(uri);
      Player.Play();
    }
    private void GridAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
  }

}
