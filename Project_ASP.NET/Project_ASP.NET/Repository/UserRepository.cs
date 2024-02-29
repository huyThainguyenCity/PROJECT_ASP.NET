﻿using BusinessObject.Models;

namespace Project_ASP.NET.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectPRN231_HuyDQContext _context;

        public UserRepository(ProjectPRN231_HuyDQContext context)
        {
            _context = context;
        }
        public bool GetUser(string username, string password)
        {
            Account user = _context.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}