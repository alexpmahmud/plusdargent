using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlusArgent_v1._0.Controllers
{
    public class CategoryController : Controller
    {



        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        // GET: Category
        public ActionResult Index()
        {
            User user = (User)Session["User"];

            var categories = _categoryRepository.GetByUser(user.IdUser);
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = _categoryRepository.GetById(id);
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new Category());
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {

                User user = (User)Session["User"];
                category.IdUser = user.IdUser;

                _categoryRepository.Add(category);
                _categoryRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _categoryRepository.GetById(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                User user = (User)Session["User"];
                category.IdUser = user.IdUser;

                _categoryRepository.Update(category);
                _categoryRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível salvar as mudanças. Tente Novamente.";
            }
            Category category = _categoryRepository.GetById(id);
            return View(category);

        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryRepository.Remove(id);
                _categoryRepository.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
