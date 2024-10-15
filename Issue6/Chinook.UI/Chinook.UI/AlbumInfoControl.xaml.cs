using System.Windows;
using System.Windows.Controls;

namespace Chinook.UI
{
  
  public partial class AlbumInfoControl : UserControl
  {
    public AlbumInfoControl()
    {
      InitializeComponent();

    
    }

  

    internal void Bind(AlbumInfoModel model, Mode mode)
    {

      GridAlbum.ItemsSource = model.Tracks;
      Button button = new Button();
      button.Visibility = System.Windows.Visibility.Hidden;

    }

    private void dgUsers_AddingNewItem(object sender, AddingNewItemEventArgs e)
    {


    }

    private void Close_Button(object sender, RoutedEventArgs e)
    {
      System.Environment.Exit(0);
    }

    private void ok_Button(object sender, RoutedEventArgs e)
    {

    }
  }

}
