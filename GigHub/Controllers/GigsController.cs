using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        public GigsController()
        {
            myContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = myContext.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse($"{viewModel.Date}, {viewModel.Time}"),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            myContext.Gigs.Add(gig);
            myContext.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        private readonly ApplicationDbContext myContext;
    }
}