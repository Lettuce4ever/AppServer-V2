using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppServerGal.Models;

public partial class Card
{
    [Key]
    [Column("CardID")]
    public int CardId { get; set; }

    public byte[]? CardImage { get; set; }

    [StringLength(300)]
    public string? CardDescription { get; set; }

    [StringLength(300)]
    public string? Rules { get; set; }
}
