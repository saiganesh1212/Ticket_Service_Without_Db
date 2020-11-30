using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Service_Without_Db.Models;

namespace Ticket_Service_Without_Db.Repository
{
    public class TicketBookingRepo:ITicketBookingRepo
    {
        private static List<Ticket> _tickets = new List<Ticket>() { new Ticket { TicketId = 1, Age = 22, PassengerName = "Ganesh", FlightId = 1, StartingLocation = "Pune", Destination = "Agra", DateOfJourney = new System.DateTime(2020, 11, 24) } ,
            new Ticket { TicketId = 2, Age = 24, PassengerName = "Suresh", FlightId = 2, StartingLocation = "Delhi", Destination = "Mumbai", DateOfJourney = new System.DateTime(2020, 11, 24) },
            new Ticket { TicketId = 3, Age = 25, PassengerName = "Suri", FlightId = 5, StartingLocation = "Mumbai", Destination = "Pune", DateOfJourney = new System.DateTime(2020, 11, 24) }
        };

        

        public bool BookTicket(Ticket ticket)
        {
            try
            {
                ticket.TicketId = _tickets.Count + 1;
                _tickets.Add(ticket);
               
                return true;

            }
            catch
            {
                return false;
            }





            /*
            int availability = await _repo.AvailableCount(ticket.FlightId);
                if ( availability> 0)
                {
                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();
                await _repo.Reduce(ticket.FlightId);
                    
                    return true;
                }
                else
                {
                    return false;
                }
                
             */

        }


        public IEnumerable<Ticket> Get_All_Tickets()
        {

            
            return _tickets;

        }
    }
}
