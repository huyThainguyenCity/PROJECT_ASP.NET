using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeedbackAndFAQ.Controllers
{
    public class SubjectController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string accountID = HttpContext.Session.GetString("Account");
            if (accountID == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                List<SubjectAccount> subjects = await GetBookFromApi(int.Parse(accountID));
                return View(subjects);
            }
        }
        public async Task<List<SubjectAccount>> GetBookFromApi(int accountID)
        {
            List<SubjectAccount> books = new List<SubjectAccount>();

            string link = "https://localhost:7198/api/Subjects";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "?accountID=" + accountID))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<SubjectAccount>>(data);
                    }
                }
            }
            return books;
        }
    }
}
