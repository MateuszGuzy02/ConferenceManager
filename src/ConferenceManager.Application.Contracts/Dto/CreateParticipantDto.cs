using ConferenceManager.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceManager.Dto
{
    public class CreateParticipantDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email must be a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^(\+48)?\s?\d{9}$", ErrorMessage = "Phone number must be 9 digits with optional +48 prefix.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Ticket type is required.")]
        public TicketType TicketType { get; set; }
    }
}
