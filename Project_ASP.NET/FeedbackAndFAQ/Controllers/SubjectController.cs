using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace FeedbackAndFAQ.Controllers
{
    public class SubjectController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string accountID = HttpContext.Session.GetString("Account");
            int? roleId = HttpContext.Session.GetInt32("Role");
            if (accountID == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                if (roleId == 1)
                {
                    List<SubjectAccount> subjects = await GetBookFromApi(int.Parse(accountID));
                    return View(subjects);
                }
                if (roleId == 2)
                {
                    List<SubjectAccount> subjects = await GetBookFromApi(int.Parse(accountID));
                    return View("QuestionStudent",subjects);
                }
                else
                {
                    return Redirect($"/Login");
                }
                
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
