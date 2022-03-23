using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignUp.Models
{
    public class TimeSlot
    {
        //[Key]
        //[Required]
        //public int TimeSlotID { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int Month { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Day must be between 1 and 31")]
        public int Day { get; set; }

        [Required]
        [Range(8, 20, ErrorMessage = "Time must be between 8am and 8pm")]
        public int Hour { get; set; }
    }
}
