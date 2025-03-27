using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Widgets2025.Models;

namespace Widgets2025.Pages.Widgets
{
    public class DetailsModel : PageModel
    {
        private readonly Widgets2025.Models.WidgetContext _context;

        public DetailsModel(Widgets2025.Models.WidgetContext context)
        {
            _context = context;
        }

        public Widget Widget { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var widget = await _context.Widgets.FirstOrDefaultAsync(m => m.WidgetId == id);
            if (widget == null)
            {
                return NotFound();
            }
            else
            {
                Widget = widget;
            }
            return Page();
        }
    }
}
