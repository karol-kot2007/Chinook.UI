using Chinook.DAL;
using System.Windows;
using System.Windows.Controls;

namespace Chinook.UI
{

  public partial class AlbumInfoControl : UserControl
  {
   

    public Mode DisplayMode { get; set; }
    public ArtistContext ArtistId { get; private set; }
    public AlbumInfoControl()
    {
      InitializeComponent();

    }
    internal void Bind(AlbumInfoModel model, Mode mode,int currentAlb,int maxAlb)
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
  }

}
