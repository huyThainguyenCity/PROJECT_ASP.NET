using BusinessObject.Models;

namespace Project_ASP.NET.Repository
{
    public interface IQuestionRepository
    {
        public List<Question> getAll();

        public List<Question> getAllbySubject(int subjectID);

        public void AddQuestion(string desc, DateTime createDate);

        public void UpdateAnswer(int questionID, string ans_desc, DateTime replyDate);

    }
}
