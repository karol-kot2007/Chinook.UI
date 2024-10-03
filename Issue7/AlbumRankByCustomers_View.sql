--DROP VIEW AlbumRanksByCustomer
--CREATE VIEW AlbumRanksByCustomer as 
SELECT 
  albums.AlbumId, 
  album_rank.CustomerId,
  album_rank.AlbumId,
  customers.FirstName,
  customers.LastName,
  albums.Title,
  album_rank.Rank
  
 
   
from 
  album_rank 
  JOIN albums on album_Rank.AlbumId = albums.AlbumId 
  JOIN customers on album_rank.CustomerId=customers.customerId
ORDER by 
  album_Rank.AlbumId
  
 -- album_rank.Rank
