using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_ASP.NET.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ProjectPRN231_HuyDQContext _context;

        public FeedbackRepository(ProjectPRN231_HuyDQContext context)
        {
            _context = context;
        }

        public void AddFeedback(string desc, int subjectID, int accountID)
        {
            try
            {
                Feedback feedback = new Feedback()
                {
                    Description = desc,
                    SubjectId = subjectID,
                    AccountId = accountID,
                    CreateDate = DateTime.Now
                };
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public List<Feedback> getAll()
        {
            List<Feedback> list = _context.Feedbacks.ToList();
            return list;
        }

        public List<Feedback> getAllbySubject(int subjectID)
        {
            List<Feedback> listfeedback = _context.Feedbacks
                            .Include(u => u.Account)
                            .Include(u => u.Subject)
                            .Where(u => u.SubjectId == subjectID).ToList();
            return listfeedback;
        }

        public List<Feedback> getAllbySubjectOfStudent(int subjectID, int accountID)
        {
            List<Feedback> listfeedback = _context.Feedbacks
                                       .Include(u => u.Account)
                                       .Include(u => u.Subject)
                                       .Where(u => u.SubjectId == subjectID && u.AccountId == accountID).ToList();
            return listfeedback;
        }
    }
}
