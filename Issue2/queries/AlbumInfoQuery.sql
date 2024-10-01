SELECT 
  artists.name, 
  albums.Title, 
  artists.ArtistId, 
  albums.AlbumId, 
  tracks.TrackId, 
  tracks.name 
FROM 
  artists 
  JOIN albums on artists.ArtistId = albums.ArtistId, 
  tracks on albums.AlbumId = tracks.AlbumId 
ORDER by 
  artists.ArtistId, 
  albums.AlbumId, 
  tracks.TrackId

