using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlusArgent_v1._0.Controllers
{
    public class ParcelController : Controller
    {

        private readonly IParcelRepository _parcelRepository;

        public ParcelController(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }



        // GET: Parcel
        public ActionResult Index()
        {
            return View();
        }

        // GET: Parcel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parcel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parcel/Create
        [HttpPost]
        public ActionResult Create(Parcel parcel)
        {
            try
            {
             
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Parcel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parcel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parcel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parcel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

    }
}
