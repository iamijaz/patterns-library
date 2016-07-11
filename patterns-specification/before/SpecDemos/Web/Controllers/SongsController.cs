using System.Linq;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.Interfaces;

namespace Web.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepository _songRepository;

        public SongsController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public SongsController() : this(new SongRepository(new AppDbContext()))
        {
        }

        public ActionResult Index()
        {
            return View(_songRepository.List());
        }
        public ActionResult ByArtist(string artist)
        {
            ViewBag.Artist = artist;
            
            return View(_songRepository.List().Where(s => s.Artist.ToLower() == artist.ToLower()));
        }
        public ActionResult ByAlbum(int albumId)
        {
            var songs = _songRepository.List().Where(s => s.AlbumId == albumId);
            if (songs.Any())
            {
                ViewBag.Album = songs.FirstOrDefault().Album.Title;
            }
            return View(songs);
        }
        public ActionResult ByYear(int year)
        {
            ViewBag.Year = year;
            return View(_songRepository.List().Where(s => s.Year == year));
        }
        public ActionResult MinRating(int rating)
        {
            ViewBag.MinRating = rating;
            return View(_songRepository.List().Where(s => s.Rating >= rating));
        }

        public ActionResult RecentFavorites()
        {
            return View(_songRepository.List().Where(s => s.IsRecentFavorite()));
        }
    }
}