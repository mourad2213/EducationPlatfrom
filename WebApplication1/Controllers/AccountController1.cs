using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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

                    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                    if (user != null)
                    {
                        Console.WriteLine($"User's account type: {user.AccountType}");
                        switch (user.AccountType)
                        {
                            case AccountType.Learner:
                                Console.WriteLine("Redirecting to LearnerProfile");
                                return RedirectToAction("LearnerProfile", "Learner");
                            case AccountType.Admin:
                                Console.WriteLine("Redirecting to Admin Index");
                                return RedirectToAction("Index", "Admin");
                            case AccountType.Instructor:
                                Console.WriteLine("Redirecting to Instructors Index");
                                return RedirectToAction("InstructorDashboard", "Instructor");
                            default:
                                Console.WriteLine("Redirecting to Home Index");
                                return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"Login failed: {result}");
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
            // Conditional validation for Instructor account type
            if (model.AccountType == AccountType.Instructor)
            {
                if (string.IsNullOrEmpty(model.ExpertiseAreas))
                {
                    ModelState.AddModelError("ExpertiseAreas", "Expertise areas are required for instructors");
                }
                if (string.IsNullOrEmpty(model.Qualifications))
                {
                    ModelState.AddModelError("Qualifications", "Qualifications are required for instructors");
                }
            }
            else
            {
                // Remove model state errors for fields that shouldn't be validated
                ModelState.Remove(nameof(model.ExpertiseAreas));
                ModelState.Remove(nameof(model.Qualifications));
                ModelState.Remove(nameof(model.AdditionalEmails));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("Model is valid");

                    var user = new UserAcccount
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Fullname = model.Fullname,
                        ExperienceLevel = model.ExperienceLevel,
                        AccountType = model.AccountType,
                        CountryOfOrigin = model.CountryOfOrigin,
                        Gender = model.Gender,
                        Birthday = model.Birthday,
                        PhoneNumber = model.PhoneNumber,
                        PhoneNumber2 = model.PhoneNumber2,
                        NormalizedEmail = model.Email.ToUpper(),
                        EmailConfirmed = true,
                        Password = model.Password,
                    };

                    // Create the user in the database and hash the password automatically
                    Console.WriteLine("Creating user...");
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        Console.WriteLine("User created successfully");

                        // Create corresponding Learner, Instructor, or Admin entry based on AccountType
                        switch (model.AccountType)
                        {
                            case AccountType.Learner:
                                Console.WriteLine("Creating learner...");
                                var learner = new Learner
                                {
                                    LearnerName = model.Fullname,
                                    LearnerGender = model.Gender,
                                    LearnerAge = DateTime.Now.Year - model.Birthday.Year,
                                    CountryOfOrigin = model.CountryOfOrigin,
                                    UserId = user.Id
                                };
                                _context.Learners.Add(learner);
                                break;

                            case AccountType.Instructor:
                                Console.WriteLine("Creating instructor...");
                                var instructor = new Instructor
                                {
                                    InstructorName = model.Fullname,
                                    UserId = user.Id,
                                    ExpertiseAreas = model.ExpertiseAreas,
                                    Qualifications = model.Qualifications
                                };
                                _context.Instructors.Add(instructor);

                                // Save the instructor to get the InstructorId
                                await _context.SaveChangesAsync();

                                // Add primary email address for the instructor


                                break;

                            case AccountType.Admin:
                                Console.WriteLine("Creating admin...");
                                var admin = new Admin
                                {
                                    // Set other Admin-specific properties here
                                };
                                //_context.Admins.Add(admin);
                                break;
                        }

                        // Save the changes to the database
                        Console.WriteLine("Saving changes to the database...");
                        await _context.SaveChangesAsync();

                        // Redirect to login page
                        Console.WriteLine("Redirecting to login page...");
                        return RedirectToAction("Login", "AccountController1");
                    }
                    else
                    {
                        Console.WriteLine("User creation failed");
                        // Add errors to ModelState if the registration failed
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                            Console.WriteLine($"Error: {error.Description}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework such as Serilog)
                    ModelState.AddModelError(string.Empty, $"An error occurred while processing your request: {ex.Message}");
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Model is not valid");
                // Log validation errors for debugging (consider using a logging framework)
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.ErrorMessage);
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
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
