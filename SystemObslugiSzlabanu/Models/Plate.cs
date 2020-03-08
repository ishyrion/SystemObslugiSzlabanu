using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemObslugiSzlabanu.Models
{
    public class Plate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Owner { get; set; }

        public string CarDescription { get; set; }

        public string OwnerDescription { get; set; }

        public string PhoneNumber { get; set; }
    }
}
