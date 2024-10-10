﻿using Chinook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chinook.UI
{
  /// <summary>
  /// Interaction logic for AlbumInfoWindow.xaml
  /// </summary>
  public partial class AlbumInfoWindow : Window
  {
    public AlbumInfoWindow()
    {
      InitializeComponent();
    }

    internal void SetData(List<Artist> ar)
    {
      DataContext = ar;
    }
  }
}
