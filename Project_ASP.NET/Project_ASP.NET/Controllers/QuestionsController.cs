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

        [HttpPost]
        public IActionResult AddQuestion(string desc, DateTime createDate)
        {
            try
            {
                _us.AddQuestion(desc, createDate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateAnswer(int questionID, string ans_desc, DateTime replyDate)
        {
            try
            {
                _us.UpdateAnswer(questionID, ans_desc,replyDate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
