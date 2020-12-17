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
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly string BaseURL;
        [BindProperty]
        public List<User> User { get; set; }
        [BindProperty]
        public List<User_flower> UserFlowers { get; set; }

        public IndexModel( IConfiguration configuration )
        {
           
            _configuration = configuration;
            BaseURL = _configuration.GetConnectionString("BackendAPI");
        }

        public async Task OnGetAsync()
        {
            
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resUser = await client.GetAsync("users");
                if (resUser.IsSuccessStatusCode)
                {
                    var userResult = resUser.Content.ReadAsStringAsync().Result;

                    User =  JsonConvert.DeserializeObject<List<User>>(userResult);
                   
                }
                else
                {
                    Redirect("/Error");
                }
            }
        }
    }
}
