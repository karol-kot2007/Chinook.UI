using System.Text;
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
      //Artist artist = new Artist();
      //{
      //  artist.Name = "Michael";
      //  artist.ArtistId = 1;
      //}
      ArtistContext context = new ArtistContext();
      var ar = context.GetArtists();
      this.DataContext = ar;
    }

    public void Button_Click(object sender, RoutedEventArgs e)
    {

    }
    class Artist
    {
      public Artist()
      {

      }
      public string Name { get; set; }
      public int ArtistId { get; set; }
    }
  }

}
