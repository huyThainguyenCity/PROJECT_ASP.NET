using BusinessObject.Models;

namespace Project_ASP.NET.Repository
{
    public interface IQuestionRepository
    {
        public List<Question> getAll();

        public List<Question> getAllbySubject(int subjectID);

        public List<Question> getAllbySubjectOfStudent(int subjectID, int accountID);

        public void AddQuestion(string desc,int subjectID, int accountID);

        public void UpdateAnswer(int questionID, int subjectID, string ans_desc);

        public Question GetQuestionByID(int questionID);

    }
}
