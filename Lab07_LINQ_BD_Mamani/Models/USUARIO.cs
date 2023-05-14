namespace Lab07_LINQ_BD_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int IDUSUARIO { get; set; }

        public int IDEMPLEADO { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(250)]
        public string CLAVE { get; set; }

        [Required]
        [StringLength(15)]
        public string NIVEL { get; set; }

        [StringLength(250)]
        public string AVATAR { get; set; }

        public int? ESTADO { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }
    }
}
