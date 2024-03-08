using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_ASP.NET.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ProjectPRN231_HuyDQContext _context;

        public SubjectRepository(ProjectPRN231_HuyDQContext context)
        {
            _context = context;
        }
        public void AddSubject(string subjectName)
        {
            throw new NotImplementedException();
        }

        public void DeleteSụbject(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetListAll()
        {
            var subjects = _context.Subjects.ToList();
            return subjects;
        }

        public List<SubjectAccount> GetList(int accountID)
        {
            List<SubjectAccount> subjects = _context.SubjectAccounts
                .Include(u => u.Account)
                .Include(u => u.Subject)
                .Where(u => u.AccountId == accountID).ToList();

            //List<Subject> sub = new List<Subject>();
            //foreach (SubjectAccount subject in subjects)
            //{
            //    var subs = _context.Subjects.FirstOrDefault(u => u.SubjectId == subject.SubjectId);
            //    sub.Add(subs);
            //}
            return subjects;
        }

        public void UpdateSubject(string subjectName)
        {
            throw new NotImplementedException();
        }
    }
}
