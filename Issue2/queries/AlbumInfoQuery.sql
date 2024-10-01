SELECT 
  artists.name as ArtistName, 
  albums.Title as AlbumName, 
  artists.ArtistId as ArtistId , 
  albums.AlbumId as AlbumId, 
  tracks.TrackId as TrackId, 
  tracks.name as TrackName
FROM 
  artists 
  JOIN albums on artists.ArtistId = albums.ArtistId 
  JOIN tracks on albums.AlbumId = tracks.AlbumId 
ORDER by 
  artists.ArtistId, 
  albums.AlbumId, 
  tracks.TrackId