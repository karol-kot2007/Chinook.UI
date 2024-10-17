using System.Windows.Controls;
namespace Chinook.UI
{
  public partial class AlbumSwapper : UserControl
  {
    public event EventHandler OnPrev;
    public event EventHandler OnNext;
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

    internal void setAlbumInfo(int currentAlb, int maxAlb)
    {
      
      CurrentAlbum.Text = "album " + (currentAlb+1) + "/"+maxAlb;
    }
  }
}
