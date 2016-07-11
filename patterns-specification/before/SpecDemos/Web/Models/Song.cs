using System;
using System.Collections.Generic;
using System.Web.Configuration;

namespace Web.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Length { get; set; }
        public int Year { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public List<Genre> Genres { get; set; }
        public int? Rating { get; set; }

        public Song()
        {
            Genres = new List<Genre>();
        }

        public bool IsPreferred()
        {
            return Rating.HasValue && Rating.Value >= 4;
        }

        public bool IsRecentFavorite()
        {
            if (DateTime.Now.Year - this.Year > 5) return false;

            return IsPreferred();
        }
    }
}