using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs.Client
{
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }

    }

    public class ClientUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
    public class ClientDto
    {
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
