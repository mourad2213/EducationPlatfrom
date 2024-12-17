﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly UserManager<UserAcccount> _userManager;
        private readonly SignInManager<UserAcccount> _signInManager;
        private readonly MilestoneContext _context;


        public AccountController1(UserManager<UserAcccount> userManager, SignInManager<UserAcccount> signInManager, MilestoneContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Loginviewmodel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        // Redirect based on account type
                        switch (user.AccountType)
                        {
                            case AccountType.Learner:
                                return RedirectToAction("Index", "Learner");
                            case AccountType.Admin:
                                return RedirectToAction("Index", "Admin");
                            case AccountType.Instructor:
                                return RedirectToAction("Index", "Instructor");
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Registeration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registeration(Registeraionmodel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserAcccount
                {
                    Email = model.Email,
                    UserName = model.Email, // Assuming username is the same as email
                    Fullname = model.Fullname,
                    ExperienceLevel = model.ExperienceLevel,
                    AccountType = model.AccountType
                };

                // Hash the password before saving the user
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

                // Add the user to the context and save changes
                _context.UserAcccounts.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "AccountController1");
            }
            return View(model);
        }

        /*
         * using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly UserManager<UserAcccount> _userManager;
        private readonly SignInManager<UserAcccount> _signInManager;
        private readonly MilestoneContext _context;

        public AccountController1(UserManager<UserAcccount> userManager, SignInManager<UserAcccount> signInManager, MilestoneContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Loginviewmodel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        // Redirect based on account type
                        switch (user.AccountType)
                        {
                            case AccountType.Learner:
                                return RedirectToAction("Index", "Learner");
                            case AccountType.Admin:
                                return RedirectToAction("Index", "Admin");
                            case AccountType.Instructor:
                                return RedirectToAction("Index", "Instructor");
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Registeration()
        {
            return View();
        }

        [HttpPost]
  [HttpPost]
public async Task<IActionResult> Registeration(Registeraionmodel model)
{
    if (ModelState.IsValid)
    {
        var user = new UserAcccount
        {
            Email = model.Email,
            UserName = model.Email, // Assuming username is the same as email
            Fullname = model.Fullname,
            ExperienceLevel = model.ExperienceLevel,
            AccountType = model.AccountType
        };

        // Hash the password before saving the user
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

        // Add the user to the context and save changes
        _context.UserAcccounts.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Login", "AccountController1");
    }
    return View(model);
}

    }
}

         */
    }
}
