using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Project_ASP.NET.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ProjectPRN231_HuyDQContext _context;

        public QuestionRepository(ProjectPRN231_HuyDQContext context)
        {
            _context = context;
        }

        public void AddQuestion(string desc)
        {
            try
            {
                Question ques = new Question()
                {
                    Description = desc
                };
                _context.Questions.Add(ques);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
            }
        }

        public void AddQuestion(string desc, DateTime createDate)
        {
            try
            {
                Question question = new Question()
                {
                    Description = desc,                
                    CreateDate = createDate
                };
                _context.Questions.Add(question);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public List<Question> getAll()
        {
            List<Question> list = _context.Questions.ToList();
            return list;
        }
        public List<Question> getAllbySubject(int subjectID)
        {
            List<Question> listQuestion = _context.Questions
                .Include(u => u.Account)
                .Include(u => u.Subject)
                .Where(u => u.SubjectId == subjectID).ToList();
            return listQuestion;
        }

        public void UpdateAnswer(int questionID, string ans_desc, DateTime replyDate)
        {
            var questionToUpdate = _context.Questions.FirstOrDefault(q => q.QuenstionId == questionID);
            if (questionToUpdate != null)
            {
                // Bản ghi được tìm thấy, tiến hành cập nhật thuộc tính cụ thể
                questionToUpdate.AnswerDescription = ans_desc;
                questionToUpdate.ReplyDate = replyDate;

                // Thực hiện cập nhật trong cơ sở dữ liệu
                _context.SaveChanges();
            }

        }
    }
}
