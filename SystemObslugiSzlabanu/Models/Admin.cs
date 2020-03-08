using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemObslugiSzlabanu.Models
{
    public class Admin
    {
        [Key]
        public int Id { get;}

        [Required]
        public string Name { get; }
    }
}
