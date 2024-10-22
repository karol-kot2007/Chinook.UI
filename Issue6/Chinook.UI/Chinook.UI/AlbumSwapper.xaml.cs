using System.Windows.Controls;
namespace Chinook.UI
{
  public partial class AlbumSwapper : UserControl
  {
    public event EventHandler OnPrev;
    public event EventHandler OnNext;
    public AlbumInfoModel ArtistName { get; set; }
    public AlbumSwapper()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
    private void Button_Prev(object sender, System.Windows.RoutedEventArgs e)
    {
      if (OnPrev != null)
      {
        OnPrev(this, e);
      }
    }
    private void Button_Next(object sender, System.Windows.RoutedEventArgs e)
    {
      if (OnNext != null)
      {
        OnNext(this, e);
      }
    }

    internal void SetArtistInfo(int currentAlb, int maxAlb, string name,string ArtistName,int maxArtist, int currentArtist)
    {

      CurrentArtist.Text = "Artist : " + name + " " + (maxAlb + 1) + " " + "/ " + currentAlb + " ";
      CurrentAlbum.Text ="Album : " + ArtistName + " " + (maxArtist + 1) + " " + "/ "+  currentArtist + " ";
     
    }

  }
}
