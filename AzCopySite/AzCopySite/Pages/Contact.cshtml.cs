using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzCopySite.Pages;

public class ContactModel : PageModel
{
    public string Message { get; set; } = "Your contact page.";

    public void OnGet()
    {
    }
}
