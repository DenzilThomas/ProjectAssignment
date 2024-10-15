using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodDMS.Models.Models;

namespace PinewoodDMS.WebUI.Pages.Customers
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public Customer? Customer { get; set; }

        private readonly IConfiguration _configuration;
        public string APIUrl { get; set; } = string.Empty;

        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            using (var client = new HttpClient())
            {
                APIUrl = _configuration["Endpoints:Api"] ?? string.Empty;
                client.BaseAddress = new Uri(APIUrl);
               // client.BaseAddress = new Uri("https://localhost:7190/api/");
                var response = await client.GetAsync($"Customer/{id}");
                if (response.IsSuccessStatusCode)
                {

                    Customer = await response.Content.ReadFromJsonAsync<Customer>();
                    if (Customer == null)
                    {
                        return NotFound();
                    }
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            using (var client = new HttpClient())
            {
                APIUrl = _configuration["Endpoints:Api"] ?? string.Empty;
                client.BaseAddress = new Uri(APIUrl);
               // client.BaseAddress = new Uri("https://localhost:7190/api/");
                var response = await client.DeleteAsync($"Customer/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }

    }
}