using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Service_Without_Db.Models;
using Ticket_Service_Without_Db.Repository;

namespace Ticket_Service_Without_Db.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketBookingRepo _bookingRepo;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TicketController));
        public TicketController(ITicketBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;

        }
        [HttpGet]
        public IActionResult Get_All_Tickets()
        {
            try
            {
                _log4net.Info("Getting all tickets");
                var result = _bookingRepo.Get_All_Tickets();
                return Ok(result);
            }
            catch
            {
                _log4net.Info("Error in getting all tickets");
                return new NoContentResult();
            }
        }
        [HttpPost("book")]
        public IActionResult Book_Ticket([FromBody] Ticket ticket)
        {
            
            try
            {
                bool res = _bookingRepo.BookTicket(ticket);
                if (res)
                {
                    _log4net.Info("Ticket Booked Successfully with passenger name " + ticket.PassengerName);
                    return StatusCode(201);
                }
                else
                {
                    return new NoContentResult();
                }

            }
            catch
            {
                _log4net.Info("Error in saving ticket details of passenger name" + ticket.PassengerName);
                return new NoContentResult();
            }

        }
    }
}