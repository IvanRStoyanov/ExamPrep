using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        private IMDBDbContext db = new IMDBDbContext();
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var films = db.Films.ToList();
            return View(films);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(film);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            var film = db.Films.Find(id);

            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            var filmEdit = db.Films.Find(id);
            if (filmEdit == null)
            {
                return HttpNotFound();
            }
            if (this.ModelState.IsValid)
            {
                filmEdit.Name = filmModel.Name;
                filmEdit.Director = filmModel.Director;
                filmEdit.Genre = filmModel.Genre;
                filmEdit.Year = filmModel.Year;
            
                db.SaveChanges();
                return Redirect("/");
            }
            return View("Edit", filmModel);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var film = db.Films.Find(id);
            if(film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            var film = db.Films.Find(id);
            if(film == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Films.Remove(film);
                db.SaveChanges();
                return Redirect("/");
            }
        }
    }
}