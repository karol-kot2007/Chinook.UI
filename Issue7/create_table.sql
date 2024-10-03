CREATE TABLE "album_rank" (
	"AlbumId"	INTEGER,
	"CustomerId"	INTEGER,
	"Rank"	INTEGER,
	FOREIGN KEY("AlbumId") REFERENCES "albums"("AlbumId"),
	FOREIGN KEY("CustomerId") REFERENCES "customers"("CustomerId")
)