using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Widgets2025.Models;

namespace Widgets2025.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly WidgetContext _context;

    public List<Customer> Customers { get; set; }
    public IndexModel(ILogger<IndexModel> logger, WidgetContext context)
    {
        _logger = logger;
        _context = context;
        Customers = _context.Customers.ToList();
    }

    public void OnGet()
    {

    }
}
