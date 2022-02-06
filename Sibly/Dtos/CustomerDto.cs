using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Sibly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }


        [Required]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }
    }
}