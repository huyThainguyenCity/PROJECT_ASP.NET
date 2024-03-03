using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeedbackAndFAQ.Controllers
{
    public class QuestionController : Controller
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
                List<Question> subjects = await GetBookFromApi(int.Parse(accountID));
                return View(subjects);
            }
        }

        public async Task<List<Question>> GetBookFromApi(int subjectID)
        {
            List<Question> books = new List<Question>();

            string link = "https://localhost:7198/api/Questions";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + subjectID))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<Question>>(data);
                    }
                }
            }
            return books;
        }
    }
}
