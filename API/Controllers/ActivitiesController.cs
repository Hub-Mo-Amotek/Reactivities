using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using DomainActivity = Domain.Activity;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // api/activities
        public async Task<ActionResult<List<DomainActivity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // api/activities/id
        public async Task<ActionResult<DomainActivity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}