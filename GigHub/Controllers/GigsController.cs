using GigHub.Models;
using GigHub.ViewModels;
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

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = myContext.Genres.ToList()
            };

            return View(viewModel);
        }

        private readonly ApplicationDbContext myContext;
    }
}