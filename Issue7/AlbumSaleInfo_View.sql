--DROP VIEW AlbumSaleInfo
CREATE VIEW AlbumSaleInfo  as
SELECT 
  --albums.AlbumId, 
  album_sales.AlbumId,
 -- album_sales.AlbumSaleId,
  album_sales.DiscountPercentage as Discount ,
  album_sales.StartDate,
  album_sales.EndDate,
  albums.Title
 
 
  
 
   
from 
  album_sales
  JOIN albums on album_sales.AlbumId = albums.AlbumId 
 
ORDER by 
  album_sales.AlbumId