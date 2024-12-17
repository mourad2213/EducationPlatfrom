using Microsoft.AspNetCore.Identity;
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
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(Loginviewmodel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    Console.WriteLine("Login successful for user: " + model.Email);

                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        Console.WriteLine($"User's account type: {user.AccountType}");
                        switch (user.AccountType)
                        {
                            case AccountType.Learner:
                                return RedirectToAction("LearnerProfile", "LearnerController");
                            case AccountType.Admin:
                                return RedirectToAction("Index", "Admin");
                            case AccountType.Instructor:
                                return RedirectToAction("Index", "Instructor");
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Login failed: {result.ToString()}");
                    if (result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Account is not allowed to login (e.g., email not confirmed).");
                    else if (result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Account is locked out.");
                    else
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else
            {
                Console.WriteLine("ModelState is invalid.");
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
                    AccountType = model.AccountType,

                    EmailConfirmed = true
                };
                // Create the user in the database and hash the password automatically
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Create corresponding Learner, Instructor, or Admin entry based on AccountType
                    switch (model.AccountType)
                    {
                        case AccountType.Learner:
                            var learner = new Learner
                            {
                                LearnerName = model.Fullname,
                                LearnerGender = model.Gender,
                                CountryOfOrigin = model.CountryOfOrigin,

                                //birthdate
                                // Set other Learner-specific properties here
                            };
                            _context.Learners.Add(learner);
                            break;

                        case AccountType.Instructor:
                            var instructor = new Instructor
                            {
                                InstructorName = model.Fullname,
                                //accountemail
                                // Set other Instructor-specific properties here
                            };
                            _context.Instructors.Add(instructor);
                            break;

                            /*case AccountType.Admin:
                                var admin = new Admin
                                {
                                    UserId = user.Id
                                    // Set other Admin-specific properties here
                                };
                                _context.Admins.Add(admin);
                                break;*/
                    }

                    // Save the changes to the database
                    await _context.SaveChangesAsync();

                    // Redirect to login page
                    return RedirectToAction("Login", "AccountController1");
                }
                else
                {
                    // Add errors to ModelState if the registration failed
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        // Action to display account details
        public async Task<IActionResult> Account()
        {
            // Get the current logged-in user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Create a view model to pass user details to the view
            var model = new AccountViewModel
            {
                Fullname = user.Fullname,
                Email = user.Email,
                AccountType = user.AccountType,
                
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditAccount(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Get the current logged-in user
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Update user details
                user.Fullname = model.Fullname;
                

                // Save the updated user information to the database
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Optionally, you can add a success message here
                    TempData["SuccessMessage"] = "Your account has been updated.";
                    return RedirectToAction("Account");
                }
                else
                {
                    // Handle errors (e.g., display validation messages)
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("Account", model);
        }

    }

}
