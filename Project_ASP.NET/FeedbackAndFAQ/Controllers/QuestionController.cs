using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeedbackAndFAQ.Controllers
{
    public class QuestionController : Controller
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
                    List<Question> questions = await GetBookFromApi(subjectID);
                    return View("Index", questions);
                }
                if (roleId == 2)
                {
                    List<Question> questions = await GetBookFromApiSandA(subjectID, int.Parse(accountID));
                    return View("ListQuestionStudent", questions);
                }
                else
                {
                    return Redirect($"/Login");
                }
                
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

        public async Task<List<Question>> GetBookFromApiSandA(int subjectID, int accountId)
        {
            List<Question> books = new List<Question>();

            string link = "https://localhost:7198/api/Questions";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + subjectID + "/" + accountId))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<Question>>(data)
                                            .Where(x => x.AccountId == accountId)
                                            .ToList();
                    }
                }
            }
            return books;
        }

        public async Task<IActionResult> Update(int questionID, int subjectID, string ans_desc)
        {
            string link = "https://localhost:7198/api/Questions";
            Question question = new Question();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync
                (link + "?questionID=" + questionID + "&subjectID=" + subjectID + "&ans_desc=" + ans_desc, null))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        question = JsonConvert.DeserializeObject<Question>(data);
                    }
                }
            }
            List<Question> questions = await GetBookFromApi(subjectID);
            ViewBag.Question = question;
            return View("Index", questions);
        }

        public async Task<IActionResult> GetQuestionByID(int questionID)
        {
            string link = "https://localhost:7198/api/Questions/listQues";
            Question question = new Question();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + questionID))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        question = JsonConvert.DeserializeObject<Question>(data);
                    }
                }
            }
            return View("Answer", question);
        }
    }
}
