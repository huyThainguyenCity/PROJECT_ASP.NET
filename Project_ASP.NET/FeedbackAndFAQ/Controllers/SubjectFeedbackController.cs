using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeedbackAndFAQ.Controllers
{
    public class SubjectFeedbackController : Controller
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
                    ViewBag.Layout = "_Layout";
                    return View(subjects);
                }
                if (roleId == 2)
                {
                    List<SubjectAccount> subjects = await GetBookFromApi(int.Parse(accountID));
                    ViewBag.Layout = "_Layout";
                    return View("FeedbackStudent", subjects);
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
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + accountID))
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
