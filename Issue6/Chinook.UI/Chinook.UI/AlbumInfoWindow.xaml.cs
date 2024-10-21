using Chinook.DAL;
using Chinook.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Chinook.UI
{//prev i warunkibrzegowe
  public partial class AlbumInfoWindow : Window
  {
    public int CurrentAlbumIndex { get; set; }
    public int CurrentArtistIndex { get; set; }
    public int MaxAlbumIndex { get; set; }
    public int MaxArtistIndex { get; set; }
    public AlbumInfoModel AlbumInfoModel { get; set; }
    public ArtistInfo ArtistInfo { get; set; }
    public AlbumInfo AlbumInfo { get; set; }
    public Mode DisplayMode { get; set; }

    public AlbumInfoWindow()
    {

      InitializeComponent();
      AlbumInfoControl.AlbumSwapper.OnNext += AlbumInfoControl_OnNext;
      AlbumInfoControl.AlbumSwapper.OnPrev += AlbumInfoControl_onPrev;
    }

    public void AlbumInfoControl_onPrev(object? sender, EventArgs e)
    {


      //if (CurrentAlbumIndex <1)
      //{
      //  System.Environment.Exit(0);
      //}
      //else
      //{
      Debug.WriteLine("btn clicked Prev " + MaxAlbumIndex + " " + CurrentAlbumIndex);
      CurrentAlbumIndex--;
      //}

      SetModel();
    }

    public void AlbumInfoControl_OnNext(object? sender, EventArgs e)
    {



      CurrentAlbumIndex++;


      //if(CurrentAlbumIndex ==3)
      //{
      //  System.Environment.Exit(0);
      //}
      SetModel();
    }

    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
    }


    private void SetModel(AlbumInfoModel model, int currentAlb, int maxAlb,int maxArtist,int currentArtist)
    {
      DataContext = model;
      
      AlbumInfoControl.Bind(model, DisplayMode, maxAlb, currentAlb,maxArtist,currentArtist);
      if (DisplayMode == Mode.View)
      {
        CancelBtn.Visibility = Visibility.Collapsed;
      }
      if (DisplayMode == Mode.Edit)
      {
        CloseBtn.Visibility = Visibility.Collapsed;
      }
      AlbumInfoModel = model;
    }

    private AlbumInfoModel BuildModel(ArtistContext context, List<DAL.Models.Artist> artists)
    {

      var model = new AlbumInfoModel();
      if (CurrentAlbumIndex == 2)
      {
        CurrentAlbumIndex--;
        return model;
      }
      else if (CurrentAlbumIndex < 0)
      {
        CurrentAlbumIndex++;
        return model;
      }
      var artist = artists.First();
      model.ArtistName = artist.Name;
      model.ArtistId = artist.ArtistId;
      var albums = context.Albums.Where(a => a.ArtistId == model.ArtistId).ToList();
      MaxAlbumIndex = albums.Count;
      MaxArtistIndex=artists.Count; 

      var album = albums[CurrentAlbumIndex];
      model.Tracks = context.Tracks.Where(i => i.AlbumId == album.AlbumId).ToList();
      //   CurrentAlbumIndex
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
      var artist = artistContext.Artists.Where(i => i.ArtistId == AlbumInfoModel.ArtistId).Single();
      var album = artistContext.Albums.Where(a => a.AlbumId == AlbumInfoModel.AlbumId).Single();
      artist.Name = AlbumInfoControl.ArtistName.Text;
      album.Title = AlbumInfoControl.AlbumName.Text;
      artistContext.SaveChanges();
      Close();
    }
    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
      SetModel();
    }
    private void PlayBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    internal void Show(Mode mode)
    {
      DisplayMode = mode;

      SetModel();

      ShowDialog();
    }

    private void SetModel()
    {
      ArtistContext context = new ArtistContext();

      var ar = context.GetArtists();
      var model = BuildModel(context, ar);
      if (model.ArtistName == null)
        return
          ;
      SetModel(model, CurrentAlbumIndex, MaxAlbumIndex,MaxArtistIndex,CurrentArtistIndex);
    }
    //dodac  private void
  }
}
