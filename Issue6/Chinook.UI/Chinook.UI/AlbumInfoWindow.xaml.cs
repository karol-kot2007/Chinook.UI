using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows;

namespace Chinook.UI
{
  
  public partial class AlbumInfoWindow : Window
  {
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
      AlbumInfoControl.Bind(model,DisplayMode);
      if(DisplayMode==Mode.View)
      {
        CancelBtn.Visibility = Visibility.Collapsed;
      }



      ShowDialog();
    }

    private void CloseBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 
      Close();
    }
    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 
      
    }
    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
      //zrobic visibilty w zalesznosci od 

    }
    //dodac  private void

  }
}
