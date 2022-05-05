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
    public class IndexModel : PageModel
    {
        private readonly SimpleSocial.Data.ApplicationDbContext _context;

        public IndexModel(SimpleSocial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post
                .Include(p => p.User).ToListAsync();
        }
    }
}
