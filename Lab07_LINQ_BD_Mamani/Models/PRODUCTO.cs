namespace Lab07_LINQ_BD_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Linq;
    using System.Data.Entity;
    using System.Linq;


    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        [Key]
        public int IDPRODUCTO { get; set; }

        public int IDCATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPCION { get; set; }

        public int PRECIO { get; set; }

        public int STOCK { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }


        //
        public List<PRODUCTO> listar()
        {
            var objproducto = new List<PRODUCTO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    objproducto = db.PRODUCTO.ToList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
            return objproducto;
        }
        public List<PRODUCTO> consultarProducto(string busqueda)
        {
            var objproducto = new List<PRODUCTO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    objproducto = db.PRODUCTO.Where(p => p.NOMBRE.Contains(busqueda)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objproducto;
        }
        public List<PRODUCTO> listarProductoPorPrecio()
        {
            var objproducto = new List<PRODUCTO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    objproducto = db.PRODUCTO.Where(x => x.PRECIO > 200).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objproducto;
        }
        public List<PRODUCTO> buscarProductoPorCategoria(string busqueda)
        {
            var objproducto = new List<PRODUCTO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    objproducto = (from p in db.PRODUCTO
                                   join c in db.CATEGORIA on p.IDCATEGORIA equals c.IDCATEGORIA
                                   where c.NOMBRE.ToString().Contains(busqueda) || p.NOMBRE.ToString().Contains(busqueda)
                                   select new
                                   {
                                       Producto = p,
                                       Categoria = c
                                   }).ToList()
                                     .Select(x => new PRODUCTO
                                     {
                                         IDPRODUCTO = x.Producto.IDPRODUCTO,
                                         NOMBRE = x.Producto.NOMBRE,
                                         CATEGORIA = new CATEGORIA { NOMBRE = x.Categoria.NOMBRE },
                                         DESCRIPCION = x.Producto.DESCRIPCION,
                                         PRECIO = x.Producto.PRECIO,
                                         STOCK = x.Producto.STOCK,
                                         ESTADO = x.Producto.ESTADO
                                     })
                                     .ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return objproducto;
        }
        public List<PRODUCTO> buscarProductoPorCategoria2(string busqueda,int typeNum)
        {
            var objproducto = new List<PRODUCTO>();
            try
            {
                    using (var db = new ModeloVentas())
                {
                    objproducto = (from p in db.PRODUCTO
                                   join c in db.CATEGORIA on p.IDCATEGORIA equals c.IDCATEGORIA
                                   where (p.NOMBRE.ToString().Contains(busqueda) && typeNum == 0) || (c.NOMBRE.ToString().Contains(busqueda) && typeNum == 1) || (p.DESCRIPCION.ToString().Contains(busqueda) && typeNum == 2) || (p.ESTADO.ToString().Equals(busqueda) && typeNum == 3)
                                   select new
                                   {
                                       Producto = p,
                                       Categoria = c
                                   }).ToList()
                                     .Select(x => new PRODUCTO
                                     {
                                         IDPRODUCTO = x.Producto.IDPRODUCTO,
                                         NOMBRE = x.Producto.NOMBRE,
                                         CATEGORIA = new CATEGORIA { NOMBRE = x.Categoria.NOMBRE },
                                         DESCRIPCION = x.Producto.DESCRIPCION,
                                         PRECIO = x.Producto.PRECIO,
                                         STOCK = x.Producto.STOCK,
                                         ESTADO = x.Producto.ESTADO
                                     })
                                     .ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return objproducto;
        }
        public List<PRODUCTO> listarProductoPorCategoria()
        {
            var objproducto = new List<PRODUCTO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    objproducto = (from p in db.PRODUCTO
                                   join c in db.CATEGORIA on p.IDCATEGORIA equals c.IDCATEGORIA
                                   select new
                                   {
                                       Producto = p,
                                       Categoria = c
                                   }).ToList()
                                     .Select(x => new PRODUCTO
                                     {
                                         IDPRODUCTO = x.Producto.IDPRODUCTO,
                                         NOMBRE = x.Producto.NOMBRE,
                                         CATEGORIA = new CATEGORIA { NOMBRE = x.Categoria.NOMBRE },
                                         DESCRIPCION = x.Producto.DESCRIPCION,
                                         PRECIO = x.Producto.PRECIO,
                                         STOCK = x.Producto.STOCK,
                                         ESTADO = x.Producto.ESTADO
                                     })
                                     .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar productos por categoría: " + ex.Message);
                throw;
            }

            return objproducto;
        }
    }
}
