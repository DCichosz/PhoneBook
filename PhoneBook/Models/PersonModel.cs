using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
	public class PersonModel
	{
		[Required]
		public int ID { get; set; }

		[Required]
        [DisplayName("First Name")]
		[MaxLength(32)]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
        [MaxLength(64)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(25)]
		public string Phone { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		public DateTime? Created { get; set; }

		public DateTime? Updated { get; set; }


		public PersonModel(int id, string firstName, string lastName, string phone, string email, DateTime? created, DateTime? updated)
		{
			ID = id;
			FirstName = firstName;
			LastName = lastName;
			Phone = phone;
			Email = email;
			Created = created;
			Updated = updated;
		}

		public PersonModel()
		{
			Created = DateTime.Now;
			Updated = DateTime.Now;
		}
	}
}
