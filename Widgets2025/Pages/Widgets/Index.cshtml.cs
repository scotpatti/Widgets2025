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
    public class IndexModel : PageModel
    {
        private readonly Widgets2025.Models.WidgetContext _context;

        public IndexModel(Widgets2025.Models.WidgetContext context)
        {
            _context = context;
        }

        public IList<Widget> Widget { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Widget = await _context.Widgets.ToListAsync();
        }
    }
}
