using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ASP.NET.Repository;

namespace Project_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly ProjectPRN231_HuyDQContext _context;
        private readonly IFeedbackRepository _us;

        public FeedbacksController(ProjectPRN231_HuyDQContext context, IFeedbackRepository us)
        {
            _context = context;
            _us = us;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedBack()
        {
            if (_us.getAll == null)
            {
                return NotFound();
            }
            return _us.getAll();
        }

        [HttpGet("{subjectID}")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedback(int subjectID)
        {
            if (_us.getAllbySubject == null)
            {
                return NotFound();
            }
            return _us.getAllbySubject(subjectID);
        }

        [HttpGet("{subjectID}/{accountID}")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedbackBySubjectAndAccountId(int subjectID, int accountID)
        {
            if (_us.getAllbySubjectOfStudent == null)
            {
                return NotFound();
            }
            return _us.getAllbySubjectOfStudent(subjectID, accountID);
        }

        [HttpPost]
        public IActionResult AddFeedback(string desc, int subjectID, int accountID)
        {
            try
            {
                _us.AddFeedback(desc, subjectID, accountID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]

        public IActionResult DeleteFeedback(int feedbackID)
        {
            try
            {
                _us.DeleteFeedback(feedbackID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
