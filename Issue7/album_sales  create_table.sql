CREATE TABLE "album_sales" (
	"AlbumSaleId"	INTEGER,
	"AlbumId"	INTEGER,
	"StartDate"	INTEGER,
	"EndDate"	INTEGER,
	"DiscountPercentage"	INTEGER,
	CONSTRAINT "Album_Sale_ID" PRIMARY KEY("AlbumSaleId"),
	CONSTRAINT "Album_ID" FOREIGN KEY("AlbumId") REFERENCES "albums"
)