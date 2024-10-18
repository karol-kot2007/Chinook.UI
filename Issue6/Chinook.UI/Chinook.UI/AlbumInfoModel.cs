using Chinook.DAL.Models;
namespace Chinook.UI
{
  public class AlbumInfoModel
  {
    public string AlbumName { get; set; }
    public int AlbumId { get; set; }
    public string? ArtistName { get; set; }
    public int ArtistId { get; set; }
    public List<Track> Tracks { get; set; }
  }
  public class AlbumInfo
  {
    public string Name { get; set; }
    public int Id { get; set; }
  }
  public class AristInfo
  {
    public string Name { get; set; }
    public int Id {get; set;}
  }
}
