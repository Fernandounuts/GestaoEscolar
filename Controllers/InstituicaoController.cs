using GestaoEscolar.Data;
using GestaoEscolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Controllers;

public class InstituicaoController : Controller
{
    private readonly AppDbContext _context;

    public InstituicaoController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Instituicao instituicao)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("Erro", "Não foi possível inserir seus dados");
        }

        return View(instituicao);
    }

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoId == id);

        if (instituicao == null)
        {
            return NotFound();
        }

        return View(instituicao);
    }

    public bool InstituicaoExists(long? id)
    {
        return _context.Instituicoes.Any(i => i.InstituicaoId == id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Instituicao instituicao)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(instituicao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!InstituicaoExists(instituicao.InstituicaoId))
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(instituicao);
    }

    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var instituicao = await _context.Instituicoes.
            SingleOrDefaultAsync(i => i.InstituicaoId == id);

        if (instituicao == null)
        {
            return NotFound();
        }

        return View(instituicao);
    }

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var instituicao = await _context.Instituicoes.
            SingleOrDefaultAsync(i => i.InstituicaoId == id);

        if (instituicao == null)
        {
            return NotFound();
        }

        return View(instituicao);
    }

    [HttpPost, HttpDelete]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inst = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoId == id);

        if (inst == null)
        {
            return NotFound();
        }

        TempData["Message"] = $"Instituição {inst.Nome} foi apagada";

        return RedirectToAction(nameof(Index));
    }
}