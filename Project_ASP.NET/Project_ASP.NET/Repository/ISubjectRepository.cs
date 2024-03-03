﻿using BusinessObject.Models;

namespace Project_ASP.NET.Repository
{
    public interface ISubjectRepository
    {
        List<SubjectAccount> GetList(int accountID);
        public void DeleteSụbject(int id);
        public void UpdateSubject(string subjectName);
        public void AddSubject(string subjectName);
    }
}