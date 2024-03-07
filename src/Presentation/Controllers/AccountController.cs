using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Users;
using Presentation.Models;
using Microsoft.Ajax.Utilities;
using System.Web.Security;
using System.Data;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        IDatabaseService _databaseService;

        public AccountController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _databaseService.Users.Include(u => u.UserRoles.Select(ur => ur.Role)).FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "OWIN Provider", ClaimValueTypes.String));

                    if (user.UserRoles != null)
                        user.UserRoles.Select(ur => ur.Role.Name)
                            .ForEach(ur =>
                            claim.AddClaim(
                                new Claim(
                                    ClaimsIdentity.DefaultRoleClaimType,
                                    ur,
                                    ClaimValueTypes.String
                                    )
                                )
                            );

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}