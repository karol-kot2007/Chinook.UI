using Chinook.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows;

namespace Chinook.UI
{
  public partial class AlbumInfoWindow : Window
  {
    public AlbumInfoModel AlbumInfoModel { get; set; }
    public Mode DisplayMode { get; set; }
    public AlbumInfoWindow()
    {
      InitializeComponent();
    }
    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
    }
    internal void ShowWithData(AlbumInfoModel model)
    {
      DataContext = model;
      AlbumInfoControl.Bind(model, DisplayMode);
      if (DisplayMode == Mode.View)
      {
        CancelBtn.Visibility = Visibility.Collapsed;

      }
      if (DisplayMode == Mode.Edit)
      {

        CloseBtn.Visibility = Visibility.Collapsed; 
      }
      AlbumInfoModel = model;
      ShowDialog();
    }

    private void CloseBtn_Click(object sender, RoutedEventArgs e)
    {
      
      Close();
    }
    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 
      var artistContext = new ArtistContext();

      var artist = artistContext.Artists.Where(i => i.ArtistId == AlbumInfoModel.ArtistId).Single();
      artist.Name = AlbumInfoModel.ArtistName;
      artistContext.SaveChanges();

      Close();
      //zrobic visibilty w zalesznosci od 

    }
    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 

    }
    //dodac  private void
  }
}
