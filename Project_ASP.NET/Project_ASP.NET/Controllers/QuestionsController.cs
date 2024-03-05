using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_ASP.NET.Repository;

namespace Project_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ProjectPRN231_HuyDQContext _context;
        private readonly IQuestionRepository _us;

        public QuestionsController(ProjectPRN231_HuyDQContext context, IQuestionRepository us)
        {
            _context = context;
            _us = us;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestion()
        {
            if (_us.getAll == null)
            {
                return NotFound();
            }
            return _us.getAll();
        }

        [HttpGet("{subjectID}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestion(int subjectID)
        {
            if (_us.getAllbySubject == null)
            {
                return NotFound();
            }
            return _us.getAllbySubject(subjectID);
        }

        [HttpGet("{subjectID}/{accountID}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestionBySubjectAndAccountId(int subjectID, int accountID)
        {
            if (_us.getAllbySubjectOfStudent == null)
            {
                return NotFound();
            }
            return _us.getAllbySubjectOfStudent(subjectID, accountID);
        }

        [HttpGet("listQues/{questionID}")]
        public async Task<ActionResult<Question>> GetQuestionByID(int questionID)
        {
            var questions = _us.GetQuestionByID(questionID);
            return questions;
        }

        [HttpPost]
        public IActionResult AddQuestion(string desc,int subjectID, DateTime createDate)
        {
            try
            {
                _us.AddQuestion(desc,subjectID,createDate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateAnswer(int questionID, int subjectID, string ans_desc)
        {
            try
            {
                _us.UpdateAnswer(questionID,subjectID,ans_desc);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
