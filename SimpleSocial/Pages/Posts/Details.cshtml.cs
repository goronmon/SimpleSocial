#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleSocial.Data;
using SimpleSocial.Models;

namespace SimpleSocial.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly SimpleSocial.Data.ApplicationDbContext _context;

        public DetailsModel(SimpleSocial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post
                .Include(p => p.User).FirstOrDefaultAsync(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
