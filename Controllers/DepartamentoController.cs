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

  // GET: Departamento/Update
  public async Task<IActionResult> Edit(long? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var depto = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoId == id);
    if (depto == null)
    {
      return NotFound();
    }

    return View(depto);
  }

  public bool DepartamentoExists(long? id)
  {
    return _context.Departamentos.Any(e => e.DepartamentoId == id);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(Departamento departamento)
  {
    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(departamento);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (!DepartamentoExists(departamento.DepartamentoId))
        {
          return NotFound();
        }
      }
      return RedirectToAction(nameof(Index));
    }
    return View(departamento);
  }

  // GET:/ Detalhes
  public async Task<IActionResult> Details(long? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var depto = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoId == id);

    if (depto == null)
    {
      return NotFound();
    }
    return View(depto);
  }

  // GEt: Departamento/Delete
  public async Task<IActionResult> Delete(long? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var depto = await _context.Departamentos.SingleOrDefaultAsync(d => d.DepartamentoId == id);

    if (depto == null)
    {
      return NotFound();
    }

    return View(depto);
  }

  [HttpPost, HttpDelete]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeletConfirmed(long? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var depto = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoId == id);

    if (depto == null)
    {
      return NotFound();
    }
    _context.Departamentos.Remove(depto);
    await _context.SaveChangesAsync();

    TempData["Message"] = $"Departamento {depto.Nome.ToUpper()} foi removido";
    
    return RedirectToAction(nameof(Index));
  }
}
