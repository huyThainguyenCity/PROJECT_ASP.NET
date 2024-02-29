﻿using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeedbackAndFAQ.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUser(string email, string pass)
        {
            string link = "https://localhost:7198/api/Users";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + email + "/" + pass))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var resoult = JsonConvert.DeserializeObject<Account>(jsonResult);
                        return Redirect($"/Home");
                    }
                    else
                    {
                        ViewData["Error"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.";
                        return View("Index");
                    }
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string email, string pass, int role)
        {
            string link = "https://localhost:7198/api/Users";

            try
            {
                // Nếu email chưa tồn tại, thực hiện đăng ký
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.PostAsJsonAsync($"{link}/{email}/{pass}/{role}", email))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            ViewData["SignUp"] = "Đăng Ký Tài Khoản Thành Công";
                            return Redirect($"/Home");
                        }
                        else
                        {
                            ViewData["Error"] = "Vui Lòng Kiểm Tra Lại Thông Tin Đăng Nhập";
                            return View("Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Có lỗi xảy ra khi thực hiện đăng ký.";
                return View("Index");
            }
        }
    }
}