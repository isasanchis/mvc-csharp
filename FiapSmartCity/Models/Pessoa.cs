using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome:")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório!")]
        [StringLength(50, ErrorMessage = "O endereço deve ter no máximo 50 caracteres.")]
        [Display(Name = "Endereço:")]
        public String Endereco { get; set; }
    }
}
