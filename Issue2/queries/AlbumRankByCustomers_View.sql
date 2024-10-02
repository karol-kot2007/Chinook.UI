--DROP VIEW AlbumRanksByCustomeaar
CREATE VIEW AlbumRanksByCustomeaar as 
SELECT 
  albums.AlbumId, 
  albumRank.CustomerId, 
  albumRank.albumName, 
  albumRank.Rank, 
  CustomerName 
from 
  albumRank 
  JOIN albums on albumRank.AlbumId = albums.AlbumId 
ORDER by 
  albumRank.AlbumId --albumRank
