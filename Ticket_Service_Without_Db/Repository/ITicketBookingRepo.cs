using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Service_Without_Db.Models;

namespace Ticket_Service_Without_Db.Repository
{
    public interface ITicketBookingRepo
    {
        public IEnumerable<Ticket> Get_All_Tickets();
        public bool BookTicket(Ticket ticket);
    }
}
