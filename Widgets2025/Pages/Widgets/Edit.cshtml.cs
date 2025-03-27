using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Widgets2025.Models;

namespace Widgets2025.Pages.Widgets
{
    public class EditModel : PageModel
    {
        private readonly Widgets2025.Models.WidgetContext _context;

        public EditModel(Widgets2025.Models.WidgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Widget Widget { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var widget =  await _context.Widgets.FirstOrDefaultAsync(m => m.WidgetId == id);
            if (widget == null)
            {
                return NotFound();
            }
            Widget = widget;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Widget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WidgetExists(Widget.WidgetId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WidgetExists(int id)
        {
            return _context.Widgets.Any(e => e.WidgetId == id);
        }
    }
}
