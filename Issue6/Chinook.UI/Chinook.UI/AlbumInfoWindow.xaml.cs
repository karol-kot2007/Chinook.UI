using Chinook.DAL;
using Chinook.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
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
    public Track trackId { get; set; }
    public AlbumTrack trackName { get; set; }
    public Mode DisplayMode { get; set; }

    public AlbumInfoWindow()
    {

      InitializeComponent();

      AlbumInfoControl.AlbumSwapper.OnNext += AlbumInfoControl_OnNext;
      AlbumInfoControl.AlbumSwapper.OnPrev += AlbumInfoControl_onPrev;
      AlbumInfoControl.ArtistSwapper.OnNext += ArtistInfoControl_OnNext;
      AlbumInfoControl.ArtistSwapper.OnPrev += ArtistInfoControl_onPrev;
    }

    public void AlbumInfoControl_onPrev(object? sender, EventArgs e)
    {
      Debug.WriteLine("btn clicked Prev " + MaxAlbumIndex + " " + CurrentAlbumIndex);
      CurrentAlbumIndex--;

      SetModel();
    }

    public void ArtistInfoControl_onPrev(object? sender, EventArgs e)
    {
      CurrentArtistIndex--;
      SetModel();
    }
    public void ArtistInfoControl_OnNext(object? sender, EventArgs e)
    {
      CurrentArtistIndex++;
      SetModel();
    }
    public void AlbumInfoControl_OnNext(object? sender, EventArgs e)
    {
      CurrentAlbumIndex++;

      SetModel();
    }

    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
    }


    private void SetModel(AlbumInfoModel model)
    {
      DataContext = model;
      AlbumInfoControl.Bind(model, DisplayMode);
      if (DisplayMode == Mode.View)
      {
        CancelBtn.Visibility = Visibility.Collapsed;
        OkBtn.Visibility = Visibility.Collapsed;
      }
      if (DisplayMode == Mode.Edit)
      {
        CloseBtn.Visibility = Visibility.Collapsed;
      }
      AlbumInfoModel = model;
    }
    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
          .Entity<AlbumTracks>(
              eb =>
              {
                eb.HasNoKey();
                eb.ToView("AlbumTracks");
                eb.Property(v => v.artistName).HasColumnName("artistName");
              });
    }
    private AlbumInfoModel BuildModelFromView(ArtistContext context)
    {
      MaxArtistIndex = context.AlbumTracks.Count();
      var model = new AlbumInfoModel();

      if (CurrentAlbumIndex > MaxAlbumIndex)
      {
        CurrentAlbumIndex--;

        return model;
      }
      else if (CurrentAlbumIndex < 0)
      {
        CurrentAlbumIndex++;

        return model;
      }
      else if (CurrentArtistIndex < 0)
      {
        CurrentArtistIndex++;
      }
      else if (CurrentArtistIndex > context.Artists.Count())
      {
        CurrentArtistIndex--;
      }
      var artist = context.AlbumTracks.First();
      model.ArtistInfo.Name = artist.artistName;//
      model.ArtistInfo.Id = artist.artistId;
      model.ArtistInfo.Max = context.Artists.Count();
      model.ArtistInfo.Current = CurrentArtistIndex;
      var tracks = context.Tracks.First();
      model.TrackInfo.Id = tracks.TrackId;
      model.TrackInfo.Name = tracks.Name;
      var albums = context.AlbumTracks.Where(a => a.artistId == model.ArtistInfo.Id).ToList();
      //MaxAlbumIndex = albums.Count;

      var album = albums[CurrentAlbumIndex];
      model.AlbumInfo.Id = album.artistId;
      model.AlbumInfo.Name = album.trackName;
      model.AlbumInfo.Max = MaxAlbumIndex;
      model.AlbumInfo.Current = CurrentAlbumIndex;
      model.Tracks = context.Tracks.Where(i => i.AlbumId == album.albumId).ToList();
      return model;
    }

    private AlbumInfoModel BuildModel(ArtistContext context)
    {
      MaxArtistIndex = context.Artists.Count();
      var model = new AlbumInfoModel();

      //TODO changing props starting with Current... shall be only in button handlers AlbumInfoControl_OnNext...
      //To simplify app add a class member: ArtistContext context and use it where you need to have context e.g. in AlbumInfoControl_OnNext 

      //if (CurrentArtistIndex < 0)
      //{
      //  CurrentArtistIndex++;
      //}
      //else if (CurrentArtistIndex > 275)
      //{
      //  CurrentArtistIndex--;
      //}

      //if (CurrentAlbumIndex == 2)//TODO use context to know that limit
      //{
      //  CurrentAlbumIndex--;
      //  //  CurrentArtistIndex--;
      //  return model;
      //}
      //else if (CurrentAlbumIndex < 0)
      //{
      //  CurrentAlbumIndex++;

      //  return model;
      //}

      var artist = context.Artists.First();  //TODO use context.Artists.ElementAt(CurrentArtistIndex)
      model.ArtistInfo.Name = artist.Name;//
      model.ArtistInfo.Id = artist.ArtistId;
      model.ArtistInfo.Max = MaxArtistIndex;
      model.ArtistInfo.Current = CurrentArtistIndex;

      var albums = context.Albums.Where(a => a.ArtistId == model.ArtistInfo.Id).ToList();
      MaxAlbumIndex = albums.Count;
      var album = albums[CurrentAlbumIndex];
      model.AlbumInfo.Id = album.AlbumId;
      model.AlbumInfo.Name = album.Title;
      model.AlbumInfo.Max = MaxAlbumIndex;
      model.AlbumInfo.Current = CurrentAlbumIndex;


      //   var album = albums[CurrentAlbumIndex];
      model.Tracks = context.Tracks.Where(i => i.AlbumId == album.AlbumId).ToList();
      return model;
    }
    private void CloseBtn_Click(object sender, RoutedEventArgs e)
    {

      Close();
    }
    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
      var artistContext = new ArtistContext();
      var albumContext = new AlbumInfoWindow();
      var artist = artistContext.Artists.Where(i => i.ArtistId == AlbumInfoModel.ArtistInfo.Id).Single();
      var album = artistContext.Albums.Where(a => a.AlbumId == AlbumInfoModel.AlbumInfo.Id).Single();
      artist.Name = AlbumInfoControl.ArtistName.Text;
      album.Title = AlbumInfoControl.AlbumName.Text;
      artistContext.SaveChanges();
      Close();
    }
    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
      Close();

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


      //var model = BuildModelFromView(context);
      var model = BuildModel(context);
      if (model.ArtistInfo.Name == null)
        return;
      SetModel(model);
    }

    //dodac  private void
  }
}
