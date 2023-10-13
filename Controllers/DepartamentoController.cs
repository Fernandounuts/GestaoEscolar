using GestaoEscolar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Controllers;

public class DepartamentoController : Controller
{
	private readonly AppDbContext _context;

	public DepartamentoController(AppDbContext context)
		{
		_context = context;
	}

	public async Task<IActionResult> Index() {
		return View(await _context.Departamentos.OrderBy(d => d.Nome).ToListAsync());
	}
}