using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab07_LINQ_BD_Mamani.Models;

namespace Lab07_LINQ_BD_Mamani.Controllers
{
    public class ProductoController : Controller
    {
        private PRODUCTO clsproducto = new PRODUCTO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            return View(clsproducto.listar());
        }
        public ActionResult ConsultarProducto(string busqueda)
        {
            if (!string.IsNullOrEmpty(busqueda))
            {
                return View(clsproducto.consultarProducto(busqueda).ToList());
            }
            return View(clsproducto.listar());
        }
        public ActionResult ListarProductoporPrecio()
        {
            return View(clsproducto.listarProductoPorPrecio().ToList());
        }
        public ActionResult listarProductoPorCategoria()
        {
            return View(clsproducto.listarProductoPorCategoria());
        }
        public ActionResult buscarProductoPorCategoria(string busqueda)
        {
            if (!string.IsNullOrEmpty(busqueda))
            {
                return View(clsproducto.buscarProductoPorCategoria(busqueda).ToList());
            }
            return View(clsproducto.listarProductoPorCategoria());
        }
        public ActionResult buscarProductoPorCategoria2(string busqueda,string type)
        {
            if (!string.IsNullOrEmpty(busqueda) && !string.IsNullOrEmpty(type))
            {
                return View(clsproducto.buscarProductoPorCategoria2(Convert.ToInt32(type)==3? ((busqueda.ToLower() == "activo") ? "A" : "I") : busqueda, Convert.ToInt32(type)).ToList());
            }
            return View(clsproducto.listarProductoPorCategoria());
        }
    }
}