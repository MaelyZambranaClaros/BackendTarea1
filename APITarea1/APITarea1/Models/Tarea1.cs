using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APITarea1.Models
{
    public enum CategoryType
    {
        Cbba=10,
        Scz=20,
        Oruro=30,
        LPZ=40,
        Sucre=50
    }
    public class Tarea1
    {
        [Key]
        public int ZambranaID { get; set; }

        [Required(ErrorMessage ="You must enter tis field {0}")]
        [StringLength(24,ErrorMessage ="The field must contain between {2} and {1} characters",MinimumLength =2)]
        [Display(Name ="Nombre Completo")]
        public string FrinedofZambrana { get; set; }
        
        [Required(ErrorMessage ="You must enter this field {0}")]
        public CategoryType Place { get; set; }
        
        [DataType(DataType.EmailAddress,ErrorMessage ="Email adress is not valid")]
        public string Email { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        [Display(Name ="Cumpleanos")]
        public DateTime Birthdate { get; set; }

    }
}