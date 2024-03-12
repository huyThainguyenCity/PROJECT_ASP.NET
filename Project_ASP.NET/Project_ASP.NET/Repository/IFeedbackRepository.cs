using BusinessObject.Models;

namespace Project_ASP.NET.Repository
{
    public interface IFeedbackRepository
    {
        public List<Feedback> getAll();

        public List<Feedback> getAllbySubject(int subjectID);

        public List<Feedback> getAllbySubjectOfStudent(int subjectID, int accountID);

        public void AddFeedback(string desc, int subjectID, int accountID);

        //public void UpdateAnswer(int questionID, int subjectID, string ans_desc);

        //public Question GetQuestionByID(int questionID);

        public void DeleteFeedback(int feedbackID);
    }
}
