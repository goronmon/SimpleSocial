#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleSocial.Data;
using SimpleSocial.Models;

namespace SimpleSocial.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly SimpleSocial.Data.ApplicationDbContext _context;

        public CreateModel(SimpleSocial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // var currentUser = _context.Set<User>();
            // Post.User = currentUser.FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post.CreateDate = DateTime.Now;
            Post.LastModifiedDate = DateTime.Now;

            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
