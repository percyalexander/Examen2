using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace WebExamenDinet.Controllers
{
    public class MovimientoController : Controller
    {
        private IMovimientoNegocio _movNegocio;
        public MovimientoController(IMovimientoNegocio movNegocio)
        {
            _movNegocio = movNegocio;
        }
        // GET: Movimiento
        public async Task<ActionResult> Index(Movimiento mov)
        {
            var movimientos = await _movNegocio.ListarMovimiento(mov);
             
            return View(movimientos);
        }

        // GET: Movimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movimiento/Create
        public ActionResult Crear()
        {
            
            return View();
        }

        // POST: Movimiento/Create
        [HttpPost]
        public async Task<ActionResult> Buscar(Movimiento mov)
        {
            var movimientos = await _movNegocio.ListarMovimiento(mov);
            return PartialView("Index", movimientos);
        }
            [HttpPost]
        public async Task<ActionResult> Crear(Movimiento mov)
        {
            try
            {
                await _movNegocio.Crear(mov);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movimiento/Edit/5
        public async Task<ActionResult> Editar(string id)
        {
            var movimiento = await _movNegocio.ObtenerxCodigo(id);
            return View(movimiento);

        }

        // POST: Movimiento/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(int id, Movimiento mov)
        {
            try
            {

                await _movNegocio.Actualizar(mov);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movimiento/Delete/5
        public async Task<ActionResult> Eliminar(int? id)
        {
            var movimiento = await _movNegocio.ObtenerxCodigo(id.ToString());
            return View(movimiento);
        }

        // POST: Movimiento/Delete/5
        [HttpPost]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await _movNegocio.Eliminar(id.ToString());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
