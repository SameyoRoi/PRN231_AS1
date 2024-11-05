using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PE_SE173338_PE.DTO;

namespace PE_SE173338_PE.Pages.JeweryPage
{
    public class IndexModel : PageModel
    {
        public IList<SilverJewelryDTO> SilverJewelry { get; set; } = new List<SilverJewelryDTO>();
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; } = default!;

        public string Message { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Get Message from Temp Data
                if (TempData["Message"] != null)
                {
                    Message = TempData["Message"].ToString();
                }

                var token = HttpContext.Session.GetString("Token");

                if (string.IsNullOrEmpty(token))
                {
                    return RedirectToPage("/Index");
                }

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Build the URL for the API call
                    var apiUrl = "https://localhost:7113/api/AllS";
                    if (!string.IsNullOrEmpty(SearchName))
                    {
                        // Append the search parameter to the URL
                        apiUrl += $"?searchName={Uri.EscapeDataString(SearchName)}";
                    }

                    var response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        SilverJewelry = JsonConvert.DeserializeObject<List<SilverJewelryDTO>>(content);
                        return Page();
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
                }
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }
}
