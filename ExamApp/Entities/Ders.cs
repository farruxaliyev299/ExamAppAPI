using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExamApp.Entities;

public partial class Ders
{
    [Key, Required, MaxLength(3)]
    [Column( TypeName = "char(3)")]
    public string Kod { get; set; } = null!;

    [MaxLength(30)]
    [Column(TypeName = "varchar(30)")]
    public string? Ad { get; set; }

    [Range(1, 11)]
    [Column(TypeName = "numeric(2, 0)")]
    public decimal? Sinif { get; set; }

    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string? MuellimAd { get; set; }  

    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string? MuellimSoyad { get; set; }

    [BindNever, JsonIgnore]
    public ICollection<Imtahan>? Imtahanlar { get; set;}
}
