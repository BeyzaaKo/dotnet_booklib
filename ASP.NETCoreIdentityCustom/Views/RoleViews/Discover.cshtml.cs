using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YourNamespace.Pages.RoleViews
{
    public class DiscoverModel : PageModel
    {
        public void OnGet()
        {
            // Sayfa yüklendiğinde yapılacak işlemler (opsiyonel)
        }

        public IActionResult OnGetDetails()
        {
            // View details butonuna tıklandığında yapılacak işlemler
            // Yönlendirme yap
            return RedirectToPage("/book/details");
        }
    }
}
