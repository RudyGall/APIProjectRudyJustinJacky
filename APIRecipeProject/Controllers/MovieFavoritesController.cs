using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APIRecipeProject.Models;

namespace APIRecipeProject.Controllers
{
    public class MovieFavoritesController : Controller
    {
        private RecipeEntities db = new RecipeEntities();

        // GET: MovieFavorites
        public ActionResult Index()
        {
            return View(db.MovieFavorites.ToList());
        }

        // GET: MovieFavorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFavorite movieFavorite = db.MovieFavorites.Find(id);
            if (movieFavorite == null)
            {
                return HttpNotFound();
            }
            return View(movieFavorite);
        }

        // GET: MovieFavorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieFavorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Year,Rated,Genre,Metascore,imdbRating,BoxOffice")] MovieFavorite movieFavorite)
        {
            if (ModelState.IsValid)
            {
                db.MovieFavorites.Add(movieFavorite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieFavorite);
        }

        // GET: MovieFavorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFavorite movieFavorite = db.MovieFavorites.Find(id);
            if (movieFavorite == null)
            {
                return HttpNotFound();
            }
            return View(movieFavorite);
        }

        // POST: MovieFavorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,Rated,Genre,Metascore,imdbRating,BoxOffice")] MovieFavorite movieFavorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieFavorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieFavorite);
        }

        // GET: MovieFavorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFavorite movieFavorite = db.MovieFavorites.Find(id);
            if (movieFavorite == null)
            {
                return HttpNotFound();
            }
            return View(movieFavorite);
        }

        // POST: MovieFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieFavorite movieFavorite = db.MovieFavorites.Find(id);
            db.MovieFavorites.Remove(movieFavorite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
