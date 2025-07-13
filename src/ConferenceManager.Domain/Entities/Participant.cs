using ConferenceManager.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ConferenceManager.Participants
{
    public class Participant : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public TicketType TicketType { get; set; }

        public Participant(Guid id) : base(id) { }

        public Participant() { }
    }
}
