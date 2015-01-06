using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Users.Infrastructure;
using Users.Models;

namespace Users.Controllers
{
    public class RoleAdminController : Controller
    {
        // GET: RoleAdmin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var result = await RoleManager.CreateAsync(new AppRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await RoleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] {"Role not found"});
            }
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        private AppRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); }
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}