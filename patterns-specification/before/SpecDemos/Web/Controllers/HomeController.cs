using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext = new AppDbContext();

        public ActionResult Index(List<int> selectedGenres = null, 
            List<string> selectedArtists = null, 
            string titleSearch = null,
            int minRating = 0)
        {
            var viewModel = new HomeViewModel();
            viewModel.Artists = _dbContext.Songs
                .Select(s => s.Artist).Distinct().ToList();
            viewModel.Genres = _dbContext.Genres.ToList();

            if (selectedArtists == null)
            { selectedArtists = new List<string>();}
            var liveSelectedArtists = _dbContext.Songs
                .Select(s => s.Artist)
                .Distinct()
                .Where(a => selectedArtists.Contains(a));

            if (selectedGenres == null)
            { selectedGenres = new List<int>();}
            var liveSelectedGenres = _dbContext.Genres
                .Where(g => selectedGenres.Contains(g.Id));

            var songs = _dbContext.Songs
                .Include("Genres")
                .Where(s => s.Genres
                        .Any(g => liveSelectedGenres
                                .Any(sg => sg.Id == g.Id)))
                .Where(s => liveSelectedArtists.Contains(s.Artist))
                .Where(s => s.Rating >= minRating);

            if (!String.IsNullOrEmpty(titleSearch))
            {
                songs = songs
                    .Where(s => s.Title.Contains(titleSearch));
            }
            viewModel.SelectedArtists = liveSelectedArtists.ToList();
            viewModel.SelectedGenres = liveSelectedGenres.ToList();
            viewModel.Songs = songs.ToList();
            return View(viewModel);
        }

        public ActionResult ResetDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Initialize(force: true);
            }
            return View();
        }
    }
}