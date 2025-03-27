using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Widgets2025.Models;

namespace Widgets2025.Pages.Widgets
{
    public class CreateModel : PageModel
    {
        private readonly Widgets2025.Models.WidgetContext _context;

        public CreateModel(Widgets2025.Models.WidgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Widget Widget { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Widgets.Add(Widget);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
