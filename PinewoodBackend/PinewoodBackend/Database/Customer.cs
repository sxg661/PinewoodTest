using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinewoodBackend.Database
{
    public class Customer
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column(TypeName = "varchar(200)")]
		public string FirstName { get; set; }

		[Column(TypeName = "varchar(200)")]
		public string LastName { get; set; }

		[Column(TypeName = "Date")]
		public DateTime DateOfBirth { get; set; }
    }
}
