using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeedbackAndFAQ.Controllers
{
    public class FeedbackController : Controller
    {

        public async Task<IActionResult> Index(int subjectID)
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
                    List<Feedback> feedbacks = await GetBookFromApi(subjectID);
                    return View("Index", feedbacks);
                }
                if (roleId == 2)
                {
                    List<Feedback> feedbacks = await GetBookFromApiSandA(subjectID, int.Parse(accountID));
                    return View("ListFeedbackStudent", feedbacks);
                }
                else
                {
                    return Redirect($"/Login");
                }

            }
        }

        public async Task<List<Feedback>> GetBookFromApi(int subjectID)
        {
            List<Feedback> books = new List<Feedback>();

            string link = "https://localhost:7198/api/Feedbacks";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + subjectID))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        books = JsonConvert.DeserializeObject<List<Feedback>>(data);
                    }
                }
            }
            return books;
        }

        public async Task<List<Feedback>> GetBookFromApiSandA(int subjectID, int accountId)
        {
            List<Feedback> books = new List<Feedback>();

            string link = "https://localhost:7198/api/Feedbacks";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + subjectID + "/" + accountId))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<Feedback>>(data)
                                            .Where(x => x.AccountId == accountId)
                                            .ToList();
                    }
                }
            }
            return books;
        }

        public async Task<IActionResult> Insert(string desc, int subjectID)
        {
            string accountID = HttpContext.Session.GetString("Account");
            string link = "https://localhost:7198/api/Feedbacks";
            Feedback feedback = new Feedback();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync
                (link + "?desc=" + desc + "&subjectID=" + subjectID + "&accountID=" + accountID, null))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        feedback = JsonConvert.DeserializeObject<Feedback>(data);
                    }
                }
            }
            List<Feedback> feedbacks = await GetBookFromApi(subjectID);
            return View("ListFeedbackStudent", feedbacks);
        }

        public async Task<IActionResult> AddFeedbackStudent()
        {
            string link1 = "https://localhost:7198/api/Subjects";
            List<Subject> subjects = new List<Subject>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link1))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        subjects = JsonConvert.DeserializeObject<List<Subject>>(data);
                    }
                }
            }
            ViewBag.Subject = subjects;
            return View("AddFeedbackStudent");
        }
    }
}
