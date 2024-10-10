using Chinook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.UI
{
  public class AlbumInfoModel
  {

    public string AlbumName { get; set; }
    public int AlbumId { get; set; }
    public string ArtistName { get; set; }
    public int ArtistId { get; set; }
    public List<Track> Tracks { get; set; }
  }
}
