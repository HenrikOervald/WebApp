using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebAppFrontEnd.Models;

namespace WebAppFrontEnd.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly string BaseURL;
        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
            BaseURL = _configuration.GetConnectionString("BackendAPI");
        }

        [BindProperty]
        public User User { get; set; }

        public async Task OnGetAsync(string id)
        { 
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("users/"+ id);
                if (res.IsSuccessStatusCode)
                {
                    var userResult = res.Content.ReadAsStringAsync().Result;
                    User = JsonConvert.DeserializeObject<User>(userResult);
                }
                else
                {
                    throw new Exception("User your're trying to delete does not exist");
                }
                
            }
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List <User_flower> user_Flowers = new List<User_flower>();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);

                var response = await client.DeleteAsync("users/"+ id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return RedirectToPage("./Error");
                }
            }   
        }
    }
}
