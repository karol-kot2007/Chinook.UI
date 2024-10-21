using Chinook.DAL.Models;
namespace Chinook.UI
{
  public class AlbumInfo
  {
    public string AlbumName { get; set; }
    public int Id { get; set; }
  }
  public class ArtistInfo
  {
    public string ArtistName { get; set; }
    public int Id {get; set;}
  }
  public class AlbumInfoModel
  {
    public string AlbumName { get; set; }
    public int AlbumId { get; set; }
    public string? ArtistName { get; set; }
    public int ArtistId { get; set; }
    public AlbumInfo AlbumInfo { get; set; }  
    public ArtistInfo ArtistInfo { get; set; }
    public List<Track> Tracks{ get; set; }

  }
}
