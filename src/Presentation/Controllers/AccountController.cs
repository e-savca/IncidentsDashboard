using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Presentation.Models;
using Microsoft.Ajax.Utilities;
using System.Data;
using MediatR;
using Application.User.Queries.GetUserByUsernameAndPassword;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _mediator.Send(new GetUserByUsernameAndPasswordQuery {
                    Username = model.Username,
                    Password = model.Password
                });

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
                            claim.AddClaim(new Claim(
                                    ClaimsIdentity.DefaultRoleClaimType, ur, ClaimValueTypes.String
                                    )
                                )
                            );

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Default");
                }
            }
            return PartialView(model);
        }

        public ActionResult SignOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("SignIn", "Account");
            //return RedirectToAction("SignIn");
        }
    }
}