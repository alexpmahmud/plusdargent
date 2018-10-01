using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlusArgent_v1._0.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        // GET: Account
        public ActionResult Index()
        {
            User user = (User)Session["User"];
            
            var accounts = _accountRepository.GetByUser(user.IdUser);
            return View(accounts);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            Account account = _accountRepository.GetById(id);
            return View(account);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View(new Account());
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(Account account)
        {
            try
            {
             
                User user = (User)Session["User"];
                account.IdUser = user.IdUser;

                _accountRepository.Add(account);
                _accountRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            Account account = _accountRepository.GetById(id);
            return View(account);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(Account account)
        {
            try
            {
                User user = (User)Session["User"];
                account.IdUser = user.IdUser;

                _accountRepository.Update(account);
                _accountRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível salvar as mudanças. Tente Novamente.";
            }
            Account account = _accountRepository.GetById(id);
            return View(account);
            
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _accountRepository.Remove(id);
                _accountRepository.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetTypeAccount(int id)
        {
            var account = _accountRepository.GetById(id);

            return Json(account.Type, JsonRequestBehavior.AllowGet);
        }

    }
}
