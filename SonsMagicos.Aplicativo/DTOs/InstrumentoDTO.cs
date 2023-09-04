using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonsMagicos.Aplicacao.DTOs;

public enum TipoInstrumentoDTO
{
    CORDA = 1,
    SOPRO = 2,
    PERCUSSAO = 3
}
public class InstrumentoDTO
{

    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome é necessário")]
    [MinLength(3, ErrorMessage = "No mínimo 3 caracteres")]
    [MaxLength(20, ErrorMessage = "No máximo 60 caracteres")]
    [DisplayName("Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Tipo é necessário")]
    [Range(1, 3, ErrorMessage = "O Tipo é inválido")]
    [DisplayName("Tipo")]
    public TipoInstrumentoDTO Tipo { get; set; }

    [Required(ErrorMessage = "O Preco é necessário")]
    [Column(TypeName = "decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Preco")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "A Propriedade é necessária")]
    [MaxLength(120, ErrorMessage = "Máximo de 120 caracteres")]
    [DisplayName("Propriedade")]
    public string Propriedade { get; set; }
}
