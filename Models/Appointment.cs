using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignUp.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentID { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        [Range(1,15, ErrorMessage = "Groups must be between 1 and 15 individuals")]
        public int GroupSize { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(8,20, ErrorMessage = "Time Must be between 8am and 8pm")]
        public int Time { get; set; }


        public string GetTime(int t)
        {

            if(t > 12)
            {
                t -= 12;
                return t.ToString() + ":00 PM";
            }
            else
            {
                return t.ToString() + ":00 AM";
            }
        }
    }
}
