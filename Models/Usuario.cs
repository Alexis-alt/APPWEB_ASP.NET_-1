using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Usuario
    {
        //Estamos trabajando con el paradigma FirstCode en EntityFramewok
        //DataAnnotationes 

        [Key]
        public int Id { get; set; }


        //Podemos colocar mensajes de error desde aquí

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        //Usamos este dataAnnotation para nombrar un atribututo que usa acento
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }





    }
}
