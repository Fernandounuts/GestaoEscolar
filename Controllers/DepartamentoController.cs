using GestaoEscolar.Data;
using GestaoEscolar.Models;
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

  public async Task<IActionResult> Index()
  {
    return View(await _context.Departamentos.OrderBy(d => d.Nome).ToListAsync());
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Departamento departamento)
  {
    try
    {
      if (ModelState.IsValid)
      {
        _context.Add(departamento);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
    }
    catch (DbUpdateException)
    {
      ModelState.AddModelError("Erro", "Não foi possivel inserir os dados");
    }
    return View(departamento);
  }

  public async Task<IActionResult> Edit(long? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var depto = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoID == id);
    if (depto == null)
    {
      return NotFound();
    }

    return View(depto);
  }
}
