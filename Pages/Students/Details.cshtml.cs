using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CampusAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly CampusAdmin.Data.CampusAdminContext _context;

        public DetailsModel(CampusAdmin.Data.CampusAdminContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()                
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
