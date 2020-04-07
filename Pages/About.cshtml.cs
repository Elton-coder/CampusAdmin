using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CampusAdmin.Models.CampusViewModels;
using CampusAdmin.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusAdmin
{
    public class AboutModel : PageModel
    {
        private readonly CampusAdminContext _context;
        public AboutModel(CampusAdminContext context)
        {
            _context = context;
        }
        public IList<EnrollmentDateGroup> Student { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
            from student in _context.Students
            group student by student.EnrollmentDate into dateGroup
            select new EnrollmentDateGroup()
            {
                EnrollmentDate = dateGroup.Key,
                StudentCount = dateGroup.Count()
            };
            Student = await data.AsNoTracking().ToListAsync();
        }
    }
}