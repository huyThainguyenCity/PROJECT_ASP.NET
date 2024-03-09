using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ASP.NET.Repository;

namespace Project_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ProjectPRN231_HuyDQContext _context;
        private readonly ISubjectRepository _us;

        public SubjectsController(ProjectPRN231_HuyDQContext context, ISubjectRepository us)
        {
            _context = context;
            _us = us;
        }

        [HttpGet("{accountID}")]
        public ActionResult<List<SubjectAccount>> GetSubject(int accountID)
        {
            if (_us.GetList(accountID) == null)
            {
                return NotFound();
            }
            return _us.GetList(accountID);
        }

        [HttpGet]
        public ActionResult<List<Subject>> GetListAllSubject()
        {
            if (_us.GetListAllSubject == null)
            {
                return NotFound();
            }
            return _us.GetListAllSubject();
        }
    }
}
