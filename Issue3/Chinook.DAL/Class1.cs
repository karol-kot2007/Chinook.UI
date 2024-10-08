

namespace Chinook.DAL
{
    public class Class1
    {
    }
  public class AlbumTrack
  {
    public int ArtistId { get; set; }
    public string artistName { get; set; }
    public int AlbumId { get; set; }
    public int TrackId { get; set; }
    public string AlbumName { get; set; }
    public string TrackName { get; set; }
  }
  public class Track
  {
    public int GenreId { get; set; }
    public int MediaTypeId { get; set; }
    public int AlbumId { get; set; }
    public int TrackId { get; set; }
    public string Name { get; set; }
    public string Composer { get; set; }
    public int Milliseconds { get; set; }
    public int Bytes { get; set; }
    public float UnitPrice { get; set; }

  }
  public class Artist
  {
    public string Name { get; set; }
    public int ArtistId { get; set; }
  }

}
