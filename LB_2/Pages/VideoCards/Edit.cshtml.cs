﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LB_2.Models.Context;
using LB_2.Models.Data;

namespace LB_2.Pages.VideoCards
{
    public class EditModel : PageModel
    {
        private readonly ComputerDbContext _context;

        public EditModel(ComputerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoCard VideoCard { get; set; } = new VideoCard();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/VideoCards/Index");
                return NotFound();
            }

            var videoCard = await _context.VideoCards.FirstOrDefaultAsync(m => m.Id == id);
            if (videoCard == null)
            {
                Response.Redirect("/VideoCards/Index");
                return NotFound();
            }
            VideoCard = videoCard;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (id == null)
            {
                Response.Redirect("/VideoCards/Index");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var videoCard = await _context.VideoCards.FirstOrDefaultAsync(m => m.Id == id);

            _context.Entry(videoCard).CurrentValues.SetValues(VideoCard);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

    }
}
