using Garage.Filters;
using Garage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    [LoginAuthorize]
    public class ProfileSettingsController : Controller
    {
        GarageDB2Entities db = new GarageDB2Entities();
        //
        // GET: /ProfileSettings/
        public ActionResult Settings(string message = null)
        {
            ViewBag.message = null;
            ViewBag.MsgColor = "red";
            var loggedInUsers = (Users)Session["User"];

            ProfileSettings settingsUsers = new ProfileSettings();

            settingsUsers.Id = loggedInUsers.Id;
            settingsUsers.FirstName = loggedInUsers.FirstName;
            settingsUsers.LastName = loggedInUsers.LastName;
            settingsUsers.Username = loggedInUsers.Username;
            settingsUsers.Email = loggedInUsers.Email;

            if (message != null)
            {
                if (message == "Current Password is Incorrect")
                {
                    ViewBag.Message = "Current Password is Incorrect";
                    return View(settingsUsers);
                }
                if (message == "Password do not macht")
                {
                    ViewBag.Message = "New Password and Confirm Password do not macht";
                    return View(settingsUsers);
                }
                else
                {
                    ViewBag.MsgColor = "green";
                    ViewBag.Message = "Change Confirmed";
                    return View(settingsUsers);
                }
            }

            return View(settingsUsers);
        }

        [HttpPost]

        public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            Users users = (Users)Session["User"];
            if (users.Password != oldPassword)
            {
                return RedirectToAction("Settings", new { message = "Current Password Incorrect" });
            }
            if (newPassword != confirmPassword)
            {
                return RedirectToAction("Settings", new { message = "Paswords do not macht" });
            }

            Users dbUsers = db.Users.Find(users.Id);
            dbUsers.Password = newPassword;
            dbUsers.ConfirmPassword = newPassword;
            db.Entry(dbUsers).State = EntityState.Modified;
            db.SaveChanges();
            Session["User"] = dbUsers;
            return RedirectToAction("Settings", new { message = "Change Confirmed" });
        }

        public ActionResult ChangeEmail(string oldPassword, string newMail)
        {
            Users user = (Users)Session["User"];
            if (user.Password != oldPassword)
            {
                return RedirectToAction("Settings", new { message = "Current Password Incorrect" });
            }

            Users dbUser = db.Users.Find(user.Id);
            dbUser.Email = newMail;
            dbUser.ConfirmPassword = user.Password;
            db.Entry(dbUser).State = EntityState.Modified;
            db.SaveChanges();
            Session["User"] = dbUser;
            return RedirectToAction("Settings", new { message = "Change Confirmed" });
        }
	}
}