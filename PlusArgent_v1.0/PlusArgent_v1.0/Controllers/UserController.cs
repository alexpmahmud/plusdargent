using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using PlusArgent_v1._0.Utils;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace PlusArgent_v1._0.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userRepository.GetAll();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id) {
            User user = _userRepository.GetById(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    //verify if Email exist
                    User userbd = _userRepository.GetByEmail(user.Email);
                    if (userbd != null)
                    {
                        ModelState.AddModelError("", TextMessages.MseEmailFound);
                        return View(user);
                    }
                    
                    if (user.File != null)
                    {

                        string RandomName;
                        string extension = System.IO.Path.GetExtension(user.File.FileName);
                        string path = Server.MapPath("~/Uploads/");

                        //code for verify if folder exist (execute only once)
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                       
                        if (extension.ToLower() == ".jpg")
                        {
                            RandomName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg";
                            user.File.SaveAs(path + Path.GetFileName(RandomName));
                            user.Photo = RandomName;
                        }
                        else
                        {
                            ModelState.AddModelError("", TextMessages.MseFileError);
                            return View(user);
                        }
                    }

                    _userRepository.Add(user);
                    _userRepository.SaveChanges();

                    return RedirectToAction("Login", "User");

                }
            }
            catch
            {
                ModelState.AddModelError("",TextMessages.MseError);
            }

            return View(user);
        }

        // GET: User/Edit
        public ActionResult Edit(int id)
        {
            User user = _userRepository.GetById(id);
            user.ConfirmPassword = user.Password;
            user.EmailOld = user.Email;
            return View(user);
        }

        // POST: User/Edit
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                    if (user.EmailOld != user.Email)
                    {
                        User userbd = _userRepository.GetByEmail(user.Email);
                        if (userbd != null)
                        {
                            ModelState.AddModelError("", TextMessages.MseEmailFound);
                            return View(user);
                        }
                    }


                    if (user.File != null)
                    {
                        string extension = System.IO.Path.GetExtension(user.File.FileName);


                        if (extension.ToLower() == ".jpg")
                        {
                            string RandomName;
                            RandomName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg";

                            string path = Server.MapPath("~/Uploads/");
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            user.File.SaveAs(path + Path.GetFileName(RandomName));


                            if (user.Photo != null)
                            {
                                string fullPath = Request.MapPath("~/Uploads/" + user.Photo);
                                if (System.IO.File.Exists(fullPath))
                                {
                                    System.IO.File.Delete(fullPath);
                                }
                            }

                            user.Photo = RandomName;
                        }
                        else
                        {
                            ModelState.AddModelError("", TextMessages.MseFileError);
                            return View(user);
                        }
                    }
                                    
                    _userRepository.Update(user);
                    _userRepository.SaveChanges();

                    User userSession = (User)Session["User"];

                    if (userSession.IdUser == user.IdUser) {
                        Session["User"] = user;
                    }
                        


                    //TO_DO Redirect to Dashboard
                    return RedirectToAction("Index");
                    
                }

            }
            catch
            {
                ModelState.AddModelError("",TextMessages.MseError);
            }

            return View(user);
        }

        // GET: User/Detele
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível salvar as mudanças. Tente Novamente.";
            }
            User user = _userRepository.GetById(id);
            return View(user);
        }


        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                User user = _userRepository.GetById(id);

                if (user.Photo != null)
                {
                    string fullPath = Request.MapPath("~/Uploads/" + user.Photo);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }


                _userRepository.Remove(id);
                _userRepository.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View(new User());
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {

                User userbd = _userRepository.GetLogin(user.Email, user.Password);
                if (userbd == null) {
                    ModelState.AddModelError("",TextMessages.MseLogin);
                    return View(user);
                }
                
                Session["User"] = userbd;

                //TO_DO (redirect to dashboard)
                return RedirectToAction("Index");

            }
            catch
            {
                ModelState.AddModelError("", TextMessages.MseError);
                return View(user);
            }
            
        }

        //GET: User/Recovery
        public ActionResult Recovery()
        {
            return View(new User());
        }

        //POST: User/Recovery
        [HttpPost]
        public ActionResult Recovery(User user)
        {
            try
            {
                User userbd = _userRepository.GetByEmail(user.Email);

                if (userbd == null)
                {
                    ModelState.AddModelError("", TextMessages.MseError);
                    return View(user);
                }

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("rumoaquebec@gmail.com", "Plus d'Argent"); ;
                mailMessage.To.Add(userbd.Email);
                mailMessage.Subject = TextMail.RecoveryTitle;
                mailMessage.Body = TextMail.RecoveryBody + userbd.Password + "<BR>"+TextMail.Signature;
                mailMessage.IsBodyHtml = true;

                new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("rumoaquebec@gmail.com", "@morlind0")
                }.Send(mailMessage);


                return RedirectToAction("Login","User");

            }
            catch
            {
                ModelState.AddModelError("", TextMessages.MseError);
                return View(user);
            }

        }

        //POST: User/LogOut
        public ActionResult LogOut(User user)
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

    }
}