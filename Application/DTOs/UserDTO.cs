using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs;

public class UserDTO
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome is mandatory")]
    [MinLength(4)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is mandatory")]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Age is mandatory")]
    [Range(0, 120, ErrorMessage = "Age between 0 and 120 years")]
    public int Age { get; set; }
}