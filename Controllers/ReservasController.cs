using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Oasis.Models;
using Oasis.Models.ViewModels;

namespace Oasis.Controllers
{
    public class ReservasController : Controller
    {
        private readonly OasisContext _context;

        public ReservasController(OasisContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservas = _context.Reservas
                .Include(r => r.CodigoEstadoResNavigation)
                .Include(r => r.DocumentoClienteNavigation)
                    .ThenInclude(c => c.CodigoTipoDocNavigation)
                .ToList();

            return View(reservas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ReservaVM oReservaVM = new ReservaVM()
            {
                oReserva = new Reserva(),
                oListaEstados = _context.EstadoReservas.Select( reserva => new SelectListItem()
                {
                    Text = reserva.NombreEstadoRes,
                    Value = reserva.CodigoEstadoRes.ToString()
                }).ToList(),
                oListaMetodosPago = _context.MetodoPagos.Select(mtp => new SelectListItem()
                {
                    Text = mtp.NombreMetodoPago,
                    Value = mtp.CodigoMetodoPago.ToString()
                }).ToList(),
            };

            var paqueteDisponibles = _context.Paquetes.ToList();
            var serviciosDisponibles = _context.Servicios.ToList();

            ViewBag.Paquetes = paqueteDisponibles;
            ViewBag.Servicios = serviciosDisponibles;

            return View(oReservaVM);
        }

        [HttpPost]
        public IActionResult Create(ReservaVM oReservaVM, string paqueteSeleccionado, string serviciosSeleccionados)
        {
            _context.Reservas.Add(oReservaVM.oReserva);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

       public IActionResult ObtenerCostoPaquete(int paqueteId)
        {
            var CostoPaquete = _context.Paquetes
                .Where(p => p.CodigoPaquete == paqueteId)
                .FirstOrDefault();

            return Json(new
            {
                costo = CostoPaquete.Valor
            });
        }

        public IActionResult ObtenerCostoServicio(int servicioId)
        {
            var CostoServicio = _context.Servicios
                .Where(s => s.CodigoServicio == servicioId)
                .FirstOrDefault();

            return Json(new
            {
                costo = CostoServicio.Precio
            });
        }

    }
}
