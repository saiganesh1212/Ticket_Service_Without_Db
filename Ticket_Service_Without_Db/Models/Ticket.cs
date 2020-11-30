using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Service_Without_Db.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public string PassengerName { get; set; }
        [Required]
        [Range(10, 90)]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfJourney { get; set; }
        [Required]
        public string StartingLocation { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public int FlightId { get; set; }
    }
}
