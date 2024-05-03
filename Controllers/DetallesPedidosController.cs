using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UriShop.Data;
using UriShop.Models;

namespace UriShop.Controllers
{
    public class DetallesPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallesPedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetallePedidos.Include(d => d.Pedido).Include(d => d.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallesPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Pedido = await _context.DetallePedidos
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetallePedidoId == id);
            if (detalle_Pedido == null)
            {
                return NotFound();
            }

            return View(detalle_Pedido);
        }

        // GET: DetallesPedidos/Create
        public IActionResult Create()
        {
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "PedidoID", "Estado");
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ProductoId", "Codigo");
            return View();
        }

        // POST: DetallesPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetallePedidoId,PedidoID,ProductoID,Cantidad,Precio")] Detalle_Pedido detalle_Pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "PedidoID", "Estado", detalle_Pedido.PedidoID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ProductoId", "Codigo", detalle_Pedido.ProductoID);
            return View(detalle_Pedido);
        }

        // GET: DetallesPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Pedido = await _context.DetallePedidos.FindAsync(id);
            if (detalle_Pedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "PedidoID", "Estado", detalle_Pedido.PedidoID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ProductoId", "Codigo", detalle_Pedido.ProductoID);
            return View(detalle_Pedido);
        }

        // POST: DetallesPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetallePedidoId,PedidoID,ProductoID,Cantidad,Precio")] Detalle_Pedido detalle_Pedido)
        {
            if (id != detalle_Pedido.DetallePedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_PedidoExists(detalle_Pedido.DetallePedidoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedidos, "PedidoID", "Estado", detalle_Pedido.PedidoID);
            ViewData["ProductoID"] = new SelectList(_context.Productos, "ProductoId", "Codigo", detalle_Pedido.ProductoID);
            return View(detalle_Pedido);
        }

        // GET: DetallesPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Pedido = await _context.DetallePedidos
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetallePedidoId == id);
            if (detalle_Pedido == null)
            {
                return NotFound();
            }

            return View(detalle_Pedido);
        }

        // POST: DetallesPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle_Pedido = await _context.DetallePedidos.FindAsync(id);
            if (detalle_Pedido != null)
            {
                _context.DetallePedidos.Remove(detalle_Pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_PedidoExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.DetallePedidoId == id);
        }
    }
}
