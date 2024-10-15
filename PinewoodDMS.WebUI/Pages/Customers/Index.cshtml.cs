using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodDMS.Models.Models;

namespace PinewoodDMS.WebUI.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public List<Customer>? Customers { get; set; }
        private readonly IConfiguration _configuration;
        public string APIUrl { get; set; } = string.Empty;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                APIUrl = _configuration["Endpoints:Api"]?? string.Empty;
                client.BaseAddress = new Uri(APIUrl);
                var response = await client.GetAsync("Customer");
                if (response.IsSuccessStatusCode)
                {
                    Customers = await response.Content.ReadFromJsonAsync<List<Customer>>();

                }
            }
        }
    }
}
