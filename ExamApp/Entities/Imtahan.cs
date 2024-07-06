using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExamApp.Entities;

public partial class Imtahan
{
    [Key, Column(TypeName = "numeric(14, 0)")]
    public decimal Nomre { get; set; }

    [Required, MaxLength(3)]
    [Column(TypeName = "char(3)")]
    public string? DersKod { get; set; }

    [Column(TypeName = "numeric(5, 0)")]
    public decimal? ShagirdNomre { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Tarix { get; set; }

    [Range(1,9, ErrorMessage ="Qiymet 1 ilə 9 arasında ola bilər")]
    [Column(TypeName = "numeric(1, 0)")]
    public decimal? Qiymet { get; set; }

    [BindNever, JsonIgnore]
    public Ders? Ders { get; set; }

    [BindNever, JsonIgnore]
    public Shagird? Shagird { get; set; }
}
