using CustomeAuth.Entites;
using CustomeAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CustomeAuth.Controllers
{
    public class AccountController1 : Controller
    {
        //TO SAVE THE DATA 
        private readonly AppDbContext _context;

        public AccountController1(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_context.UsersAccounts.ToList());
        }

        public IActionResult Registeration() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registeration(RigistrationviewModel model)
        { 
            if(ModelState.IsValid)
            {
                UserAccount userAccount = new UserAccount();
                userAccount.Email = model.Email;
                userAccount.FirstName = model.FirstName;
                userAccount.LastName = model.LastName;
                userAccount.Password = model.Password;
                userAccount.UserName = model.UserName;

                try
                {
                    _context.UsersAccounts.Add(userAccount);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{userAccount.FirstName}{userAccount.LastName} registerd succesfuly";

                }
                catch (DbUpdateException ex )
                {
                    ModelState.AddModelError("", "please enter a uniqe Email or Password");
                    return View(model);
                    
                }
                return View();
            
            }
            return View();
        
        }

        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _context.UsersAccounts.Where(x => x.UserName == model.UserNameOrEmail||x.Email == model.UserNameOrEmail && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    //success,create cookies

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Name",user.FirstName),
                        new Claim(ClaimTypes.Role,"User")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    
                    return RedirectToAction("SecurePage");
                }
                else
                {
                    ModelState.AddModelError("", "User Name Or Password Is Incorrect");
                }
                }
            return View();

        }

        public IActionResult Logout() 
        {
        
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction ("Index");
        
        }



        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name= HttpContext.User.Identity.Name;
            return View();
        }






    }
}
