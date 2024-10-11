﻿using Chinook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Chinook.UI.MainWindow;

namespace Chinook.UI
{
  /// <summary>
  /// Interaction logic for AlbumInfoControl.xaml
  /// </summary>
  public partial class AlbumInfoControl : UserControl
  {
    public AlbumInfoControl()
    {
      InitializeComponent();

      //
    }

    public void Bind(Chinook.DAL.Models.AlbumTrack albumTracks)
    {

    }

    internal void Bind(AlbumInfoModel model)
    {
      GridAlbum.ItemsSource = model.Tracks;
    }

    private void dgUsers_AddingNewItem(object sender, AddingNewItemEventArgs e)
    {


    }
  }

} 
