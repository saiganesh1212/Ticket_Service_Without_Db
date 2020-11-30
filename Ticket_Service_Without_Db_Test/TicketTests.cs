using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Ticket_Service_Without_Db.Controllers;
using Ticket_Service_Without_Db.Models;
using Ticket_Service_Without_Db.Repository;

namespace Ticket_Service_Without_Db_Test
{
    public class Tests
    {
        List<Ticket> tickets;
        Mock<ITicketBookingRepo> mock;
        [SetUp]
        public void Setup()
        {
            mock= new Mock<ITicketBookingRepo>();
            tickets=new List<Ticket>(){ new Ticket { TicketId = 1, Age = 25, PassengerName = "Dinesh", FlightId = 1, StartingLocation = "Pune", Destination = "Agra", DateOfJourney = new System.DateTime(2020, 11, 24) } ,
            new Ticket { TicketId = 2, Age = 22, PassengerName = "Anand", FlightId = 2, StartingLocation = "Delhi", Destination = "Mumbai", DateOfJourney = new System.DateTime(2020, 11, 24) },
            new Ticket { TicketId = 3, Age = 27, PassengerName = "Suri", FlightId = 4, StartingLocation = "Mumbai", Destination = "Pune", DateOfJourney = new System.DateTime(2020, 11, 24) }
            };
        }

        [Test]
        public void Get_All_Tickets_Test()
        {
            mock.Setup(x => x.Get_All_Tickets()).Returns(tickets);
            var controller = new TicketController(mock.Object);
            var res = controller.Get_All_Tickets() as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
            Assert.IsInstanceOf<List<Ticket>>(res.Value);
        }
        [Test]
        public void Book_Ticket_Success_Test()
        {
            mock.Setup(x => x.BookTicket(It.IsAny<Ticket>())).Returns(true);
            var controller = new TicketController(mock.Object);
            var res = controller.Book_Ticket(new Ticket() { TicketId=7,Age=35,PassengerName="Hari",StartingLocation="Rajamundry",Destination="Hyderabad",FlightId=4,DateOfJourney=new System.DateTime(2021,3,4)}) as StatusCodeResult;
            Assert.AreEqual(201, res.StatusCode);
        }
        [Test]
        public void Book_Ticket_Failure_Test()
        {
            mock.Setup(x => x.BookTicket(It.IsAny<Ticket>())).Returns(false);
            var controller = new TicketController(mock.Object);
            var res = controller.Book_Ticket(new Ticket() { TicketId = 7, Age = 35, PassengerName = "Hari", StartingLocation = "Rajamundry", Destination = "Hyderabad", FlightId = 4, DateOfJourney = new System.DateTime(2021, 3, 4) }) as NoContentResult;
            Assert.AreEqual(204, res.StatusCode);
        }

    }
}