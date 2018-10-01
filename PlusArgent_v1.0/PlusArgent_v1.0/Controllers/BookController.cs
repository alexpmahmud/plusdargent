using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using PlusArgent_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlusArgent_v1._0.Controllers
{
    public class BookController : Controller
    {


        private readonly IAccountRepository     _accountRepository;
        private readonly IBookRepository        _bookRepository;
        private readonly ICategoryRepository    _categoryRepository;
        private readonly IParcelRepository      _parcelRepository;

        public BookController(IAccountRepository  accountRepository, 
                              IBookRepository     bookRepository, 
                              ICategoryRepository categoryRepository,
                              IParcelRepository   parcelRepository)
        {
            _accountRepository = accountRepository;
            _bookRepository     = bookRepository;
            _categoryRepository = categoryRepository;
            _parcelRepository   = parcelRepository;
        }



        // GET: Book
        public ActionResult Index()
        {
            //TO_DO
            User user = (User)Session["User"];
            //var books = _bookRepository.GetByUser(user.IdUser);
            //return View(books);
            var books = _bookRepository.GetListMonth(10);
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = _bookRepository.GetById(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            User user = (User)Session["User"];

            var listCategories = _categoryRepository.GetByUser(user.IdUser);
            var listAccounts = _accountRepository.GetByUser(user.IdUser);


            ViewBag.listCategories = new SelectList(listCategories, "IdCategory", "Description", "Selecione uma categoria");
            ViewBag.listAccounts = new SelectList(listAccounts, "IdAccount", "Description", "Selecione uma conta");


            //{RepeatPeriod = Book.BookRepeatPeriod.Unique}

            Book book = new Book();
            book.Date = System.DateTime.Now;
            book.Repeat = 0;

            return View(book);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (book.Type == null)
                {
                    book.Type = book.TypeHidden;
                }

                if((book.Repeat == 1) && (book.RepeatPeriod == Book.BookRepeatPeriod.NoRepeat))
                {
                    ModelState.AddModelError("", "Repeat Period is necessary");
                }


                if (ModelState.IsValid == false)
                {
                    User user = (User)Session["User"];

                    var listCategories = _categoryRepository.GetByUser(user.IdUser);
                    var listAccounts = _accountRepository.GetByUser(user.IdUser);

                    ViewBag.listCategories = new SelectList(listCategories, "IdCategory", "Description", "Selecione uma categoria");
                    ViewBag.listAccounts = new SelectList(listAccounts, "IdAccount", "Description", "Selecione uma conta");


                    return View(book);
                }


                _bookRepository.Add(book);
                _bookRepository.SaveChanges();

                if (book.NParcels > 0)
                {


                    Parcel parcel = new Parcel();
                    parcel.IdBook = book.IdBook;

                    for(int i =1 ; i <= book.NParcels; i++) { 
                        parcel.ParcelNumber = i;
                        _parcelRepository.Add(parcel);
                        _parcelRepository.SaveChanges();
                    }

                    

                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {

            User user = (User)Session["User"];

            var listCategories = _categoryRepository.GetByUser(user.IdUser);
            var listAccounts = _accountRepository.GetByUser(user.IdUser);


            ViewBag.listCategories = new SelectList(listCategories, "IdCategory", "Description", "Selecione uma categoria");
            ViewBag.listAccounts = new SelectList(listAccounts, "IdAccount", "Description", "Selecione uma conta");

            Book book = _bookRepository.GetById(id);
            book.IdAccountHidden    = book.IdAccount;
            book.RepeatPeriodHidden = book.RepeatPeriod;
            

            if (book.RepeatPeriod != Book.BookRepeatPeriod.NoRepeat)
            {
                book.Repeat = 1;
            }

            var parcels = _parcelRepository.GetByBook(book.IdBook);
            book.NParcels = parcels.Count();
            book.NParcelsHidden = book.NParcels;
            book.isPay = parcels.Where(c => c.PayDay != null).Count();
            
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {

                if (book.Type == null)
                {
                    book.Type = book.TypeHidden;
                }



                if (book.isPay > 0) {
                    book.IdAccount = book.IdAccountHidden;
                    book.RepeatPeriod = book.RepeatPeriodHidden;
                }
                else {
                    
                    if ((book.Repeat == 1) && (book.RepeatPeriod == Book.BookRepeatPeriod.NoRepeat))
                    {
                        ModelState.AddModelError("", "Repeat Period is necessary");
                    }

                }

                if (ModelState.IsValid == false)
                {
                    User user = (User)Session["User"];

                    var listCategories = _categoryRepository.GetByUser(user.IdUser);
                    var listAccounts = _accountRepository.GetByUser(user.IdUser);

                    ViewBag.listCategories = new SelectList(listCategories, "IdCategory", "Description", "Selecione uma categoria");
                    ViewBag.listAccounts = new SelectList(listAccounts, "IdAccount", "Description", "Selecione uma conta");


                    return View(book);
                }


                _bookRepository.Update(book);
                _bookRepository.SaveChanges();
                
                if(book.isPay == 0)
                {
                    if (book.NParcels > 0)
                    {

                        var parcels = _parcelRepository.GetByBook(book.IdBook).ToList();
                        foreach(Parcel pc in parcels)
                        {
                            _parcelRepository.Remove(pc.IdParcel);
                        }
                        _parcelRepository.SaveChanges();

                        Parcel parcel = new Parcel();
                        parcel.IdBook = book.IdBook;
                        for (int i = 1; i <= book.NParcels; i++)
                        {
                            parcel.ParcelNumber = i;
                            _parcelRepository.Add(parcel);
                            _parcelRepository.SaveChanges();
                        }
                    }
                }




               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente Novamente.");
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível salvar as mudanças. Tente Novamente.";
            }
            Book book = _bookRepository.GetById(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _bookRepository.Remove(id);
                _bookRepository.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }



    }
}
