using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KVS.Models
{
    public class CustomVote
    {
        [Key]
        public int id { get; set; }
        public bool AGRAZ_SHARMA_A17 { get; set; }
        public bool ASHISH_GUPTA_A27 { get; set; }
        public bool MOHSIN_KHAN_A3 { get; set; }
        public bool PARWESH_RANJAN_DEEPAK_B13_14 { get; set; }
        public bool RAM_KUMAR_B26 { get; set; }
        public bool DHEERAJ_MISHRA_B21 { get; set; }
        public bool ASHISH_TRIPATHI_C29 { get; set; }
        public bool TARUN_KUMAR_C31 { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        public string Token { get; set; }
    }
}