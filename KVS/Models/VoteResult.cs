using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KVS.Models
{
    public class VoteResult
    {
        [Key]
        public int id { get; set; }
        public string AGRAZ_SHARMA_A17 { get; set; }
        public string ASHISH_GUPTA_A27 { get; set; }
        public string MOHSIN_KHAN_A3 { get; set; }
        public string PARWESH_RANJAN_DEEPAK_B13_14 { get; set; }
        public string RAM_KUMAR_B26 { get; set; }
        public string DHEERAJ_MISHRA_B21 { get; set; }
        public string ASHISH_TRIPATHI_C29 { get; set; }
        public string TARUN_KUMAR_C31 { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        public string Token { get; set; }
    }
}