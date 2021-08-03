using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Domain;
using Reactivities.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Reactivities.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() // activities
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid Id)
        {
            return await _context.Activities.FindAsync(Id);
        }
    }
}