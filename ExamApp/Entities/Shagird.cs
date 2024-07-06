using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExamApp.Entities;

public partial class Shagird
{
    [Key, Column(TypeName = "numeric(5, 0)")]
    [Range(1,99999, ErrorMessage = "Nömrə 5 rəqəmdən artıq ola bilməz!")]
    public decimal Nomre { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string? Ad { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string? Soyad { get; set; }

    [Column(TypeName = "numeric(2, 0)")]
    [Range(1, 11, ErrorMessage = "Sinif 1 ilə 11 arasında ola bilər!")]
    public decimal? Sinif { get; set; }

    [BindNever, JsonIgnore]
    public ICollection<Imtahan>? Imtahanlar { get; set; }
}
