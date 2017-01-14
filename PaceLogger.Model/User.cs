using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaceLogger.Model {
    public class User {

        [Key]
        public int Id { get; set; }  

        [Required]      
        [MaxLength(30), MinLength(5)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

    }
}
