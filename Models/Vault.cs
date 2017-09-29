using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Keep> Keeps { get; set; } = new List<Keep>();
        
        [Required]
        public string UserId { get; set; }
    }
}