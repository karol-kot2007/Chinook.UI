CREATE TABLE "albumRank" 
(
	"AlbumId"	INTEGER,
	"AlbumName"	INTEGER,
	"CustomerId"	INTEGER,
	"CustomerName"	INTEGER,
	"Rank"	INTEGER,
	FOREIGN KEY("AlbumId") REFERENCES "albums" ([albumId]),
	FOREIGN KEY("CustomerId") REFERENCES "customers"([customerId])
)
--FOREIGN KEY ([ArtistId]) REFERENCES "artists" ([ArtistId]) 