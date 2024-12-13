using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RoleSelectionModel : PageModel
{
    public IActionResult OnPost(string role)
    {
        if (string.IsNullOrEmpty(role))
        {
            ModelState.AddModelError("", "Please select a role to proceed.");
            return Page();
        }

        // Redirect to the appropriate registration page based on the selected role
        return role switch
        {
            "Learner" => RedirectToPage("/Account/RegisterLearner"),
            "Instructor" => RedirectToPage("/Account/RegisterInstructor"),
            "Admin" => RedirectToPage("/Account/RegisterAdmin"),
            _ => Page() // Reload the selection page in case of an unexpected role
        };
    }
}