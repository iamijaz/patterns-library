using System;
using System.Data.Entity;
using System.Linq;
using Web.Models;
using WebGrease.Css.Extensions;

namespace Web.Infrastructure
{
    public class AppDbContextInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        private readonly Random _random = new Random();
        protected override void Seed(AppDbContext dbContext)
        {
            // Albums
            dbContext.Albums.Add(new Album { Artist = "311", Title = "Greatest Hits '93-'03", Year = 2004 });
            dbContext.Albums.Add(new Album { Artist = "A Perfect Circle", Title = "10,000 Days", Year = 2006 });
            dbContext.Albums.Add(new Album { Artist = "Daft Punk", Title = "Tron Legacy", Year = 2010 });
            dbContext.Albums.Add(new Album { Artist = "Deadmau5", Title = "4x4=12", Year = 2011 });
            dbContext.Albums.Add(new Album { Artist = "Franklin Brothers", Title = "Lifeboat To Nowhere", Year = 2011 });
            dbContext.Albums.Add(new Album { Artist = "Metallica", Title = "...And Justice for All", Year = 1990 });
            dbContext.Albums.Add(new Album { Artist = "Modest Mouse", Title = "Good News For People Who Love Bad News", Year = 2004 });
            dbContext.Albums.Add(new Album { Artist = "Rage Against the Machine", Title = "Rage Against the Machine", Year = 1992 });
            dbContext.Albums.Add(new Album { Artist = "Rage Against the Machine", Title = "Evil Empire", Year = 1996 });
            dbContext.Albums.Add(new Album { Artist = "Tool", Title = "10,000 Days", Year = 2006 });
            dbContext.SaveChanges();

            // Genres
            dbContext.Genres.Add(new Genre { Name = "Alternative" });
            dbContext.Genres.Add(new Genre { Name = "Alt Rock" });
            dbContext.Genres.Add(new Genre { Name = "Jazz" });
            dbContext.Genres.Add(new Genre { Name = "Metal" });
            dbContext.Genres.Add(new Genre { Name = "Progressive" });
            dbContext.Genres.Add(new Genre { Name = "Rap" });
            dbContext.Genres.Add(new Genre { Name = "Rock" });
            dbContext.Genres.Add(new Genre { Name = "Techno" });
            dbContext.SaveChanges();

            // Songs
            dbContext.Songs.Add(new Song { Artist = "311", AlbumId = 1, Title = "Amber", Year = 2004, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "A Perfect Circle", AlbumId = 2, Title = "The Noose", Year = 2003, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "A Perfect Circle", AlbumId = 2, Title = "Blue", Year = 2003, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "A Perfect Circle", AlbumId = 2, Title = "Pet", Year = 2003, Rating = 3, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "The Game Has Changed", Year = 2010, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "End Of Line", Year = 2010, Rating = 3, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "C.L.U", Year = 2010, Rating = 3, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Daft Punk", AlbumId = 3, Title = "Tron Legacy (End Titles)", Year = 2010, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Deadmau5", AlbumId = 4, Title = "Some Chords", Year = 2013, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Franklin Brothers", AlbumId = 5, Title = "She Won", Year = 2011, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Metallica", AlbumId = 6, Title = "Blackened", Year = 1990, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Metallica", AlbumId = 6, Title = "...And Justice for All", Year = 1990, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Metallica", AlbumId = 6, Title = "One", Year = 1990, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Modest Mouse", AlbumId = 7, Title = "One", Year = 1990, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Rage Against the Machine", AlbumId = 8, Title = "Killing in the Name", Year = 1992, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Rage Against the Machine", AlbumId = 9, Title = "Bulls on Parade", Year = 1996, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "The Pot", Year = 2006, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "Rosetta Stoned", Year = 2006, Rating = 5, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "Wings for Marie (Pt 1)", Year = 2006, Rating = 4, Length = RandomSongLength() });
            dbContext.Songs.Add(new Song { Artist = "Tool", AlbumId = 10, Title = "10,000 Days (Wings Pt 2)", Year = 2006, Rating = 5, Length = RandomSongLength() });
            dbContext.SaveChanges();

            // Add Genres to Songs
            var alternativeGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Alternative");
            var altRockGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Alt Rock");
            var jazzGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Jazz");
            var metalGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Metal");
            var progressiveGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Progressive");
            var rapGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Rap");
            var rockGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Rock");
            var technoGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Techno");

            dbContext.Songs
                .Where(s => s.Artist == "311")
                .ForEach(s => s.Genres.Add(alternativeGenre));

            dbContext.Songs
                .Where(s => s.Artist == "A Perfect Circle")
                .ForEach(s => s.Genres.Add(progressiveGenre));

            dbContext.Songs
                .Where(s => s.Artist == "Daft Punk" || s.Artist == "DeadMau5")
                .ForEach(s => s.Genres.Add(technoGenre));

            dbContext.Songs
                .Where(s => s.Artist == "Franklin Brothers")
                .ForEach(s => s.Genres.Add(jazzGenre));

            dbContext.Songs
                .Where(s => s.Artist == "Metallica")
                .ForEach(s => s.Genres.Add(metalGenre));

            dbContext.Songs
                .Where(s => s.Artist == "Modest Mouse")
                .ForEach(s => s.Genres.Add(altRockGenre));

            dbContext.Songs
                .Where(s => s.Artist == "Rage Against the Machine")
                .ForEach(s =>
                {
                    s.Genres.Add(metalGenre);
                    s.Genres.Add(rapGenre);
                });

            dbContext.Songs
                .Where(s => s.Artist == "Tool")
                .ForEach(s =>
                {
                    s.Genres.Add(metalGenre);
                    s.Genres.Add(progressiveGenre);
                });


            dbContext.SaveChanges();

            base.Seed(dbContext);
        }

        private TimeSpan RandomSongLength()
        {
            int minutes = _random.Next(7) + 1;
            int seconds = _random.Next(60);

            return new TimeSpan(0, 0, minutes, seconds);
        }
    }
}