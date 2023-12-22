﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LB_2.Models.Context;
using LB_2.Models.Data;

namespace LB_2.Pages.Units
{
    public class DetailsModel : PageModel
    {
        private readonly ComputerDbContext _context;

        public DetailsModel(ComputerDbContext context)
        {
            _context = context;
        }

        public Unit Unit { get; set; } = new Unit();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.FirstOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }
            else
            {
                Unit = unit;
            }
            return Page();
        }
    }
}
