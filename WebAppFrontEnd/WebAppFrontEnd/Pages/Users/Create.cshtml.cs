using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebAppFrontEnd.Models;

namespace WebAppFrontEnd.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _confiuration;
        private readonly string BaseURL;
        
        public CreateModel(IConfiguration configuration)
        {
            _confiuration = configuration;
            BaseURL = _confiuration.GetConnectionString("BackendAPI");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BaseURL + "users"),
                    Content = new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json")

                };

                var res = await client.SendAsync(request);
                if (res.IsSuccessStatusCode)
                {
                    var userResult = res.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Redirect("/Error");
                }
            }



            return RedirectToPage("./Index");
        }
    }
}
