using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleERP.Data;
using SimpleERP.Models;
using SimpleERP.ViewModels;

namespace SimpleERP.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuario.ToListAsync();

            var vms = usuarios.Select(u => new UsuarioViewModel
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Telefone = u.Telefone
            }).ToList();

            return View(vms);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var vm = new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone
            };

            return View(vm);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View(new UsuarioViewModel());
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(UsuarioViewModel vm)
        {
            // Se quiser, pode limpar quaisquer caracteres não numéricos:
            if (!string.IsNullOrWhiteSpace(vm.Telefone))
                vm.Telefone = new string(vm.Telefone.Where(char.IsDigit).ToArray());

            if (!ModelState.IsValid)
                return View(vm);

            // mapear para entidade
            var usuario = new Usuario
            {
                Nome = vm.Nome,
                Email = vm.Email,
                Telefone = vm.Telefone
            };

            // valida a entidade baseada nos DataAnnotations da model
            if (!TryValidateModel(usuario))
                return View(vm);

            _context.Usuario.Add(usuario);  
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var vm = new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone
            };

            return View(vm);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioViewModel vm)
        {
            if (id != vm.Id)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(vm.Telefone))
                vm.Telefone = new string(vm.Telefone.Where(char.IsDigit).ToArray());

            if (!ModelState.IsValid)
                return View(vm);

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Nome = vm.Nome;
            usuario.Email = vm.Email;
            usuario.Telefone = vm.Telefone;

            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            var vm = new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone
            };

            return View(vm);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
    