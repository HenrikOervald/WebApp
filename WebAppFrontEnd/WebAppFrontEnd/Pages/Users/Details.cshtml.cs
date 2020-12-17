using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebAppFrontEnd.Models;

namespace WebAppFrontEnd.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IConfiguration _confiuration;
        private readonly string BaseURL;

        public DetailsModel(IConfiguration configuration)
        {
            _confiuration = configuration;
            BaseURL = _confiuration.GetConnectionString("BackendAPI");
        }
        [BindProperty]
        public IOUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("IOUser/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var userResult = res.Content.ReadAsStringAsync().Result;
                    User = JsonConvert.DeserializeObject<IOUser>(userResult);
                }

             
                else
                {
                    throw new Exception("User your're trying to display does not exist");
                }

            }
            return Page();
        }
    }
}
