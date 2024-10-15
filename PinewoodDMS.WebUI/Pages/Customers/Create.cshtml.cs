using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodDMS.Models.Models;

namespace PinewoodDMS.WebUI.Pages.Customers
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public Customer? NewCustomer { get; set; }

        private readonly IConfiguration _configuration;
        public string APIUrl { get; set; } = string.Empty;


        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var client = new HttpClient())
            {
                APIUrl = _configuration["Endpoints:Api"] ?? string.Empty;
                client.BaseAddress = new Uri(APIUrl);
                //client.BaseAddress = new Uri("https://localhost:7190/api/");
                var response = await client.PostAsJsonAsync("Customer", NewCustomer);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }


    }
}
