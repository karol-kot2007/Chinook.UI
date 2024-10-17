using Chinook.DAL;
using Chinook.DAL.Models;
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
    private static AlbumInfoModel BuildModel(ArtistContext context, List<DAL.Models.Artist> artists)
    {
      var model = new AlbumInfoModel();
      model.ArtistName = artists.First().Name;
      model.ArtistId = artists.First().ArtistId;
      var album = context.Albums.Where(a => a.ArtistId == model.ArtistId).First();
      model.Tracks = context.Tracks.Where(i => i.AlbumId == album.AlbumId).ToList();
      model.AlbumId = album.AlbumId;
      model.AlbumName = album.Title;
      return model;
    }
    private void CloseBtn_Click(object sender, RoutedEventArgs e)
    {

      Close();
    }
    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 
      var artistContext = new ArtistContext();
      var albumContext = new AlbumInfoWindow();
      //     var albumcontext = new alb
      var artist = artistContext.Artists.Where(i => i.ArtistId == AlbumInfoModel.ArtistId).Single();
      var album = artistContext.Albums.Where(a => a.AlbumId==AlbumInfoModel.AlbumId).Single();  
      //var album=albumcontext.Albums.Where(i => i.AlbumId == AlbumInfoModel.AlbumId).Single();
      artist.Name = AlbumInfoControl.ArtistName.Text;
      album.Title = AlbumInfoControl.AlbumName.Text;
      artistContext.SaveChanges();

      Close();
      //zrobic visibilty w zalesznosci od 

    }
    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 

    }

    internal void Show(Mode mode)
    {
      DisplayMode = mode;

      ArtistContext context = new ArtistContext();
      
      var ar = context.GetArtists();
      var model = BuildModel(context, ar);
      ShowWithData(model);
    }
    //dodac  private void
  }
}
