using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzCopySite.Pages;

public class AboutModel : PageModel
{
    public string Message { get; set; } = "Your application description page.";

    public void OnGet()
    {
    }
}
