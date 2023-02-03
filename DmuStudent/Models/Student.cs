using System.ComponentModel.DataAnnotations;

namespace DmuStudent.Models
{
	public class Student : BaseEntity
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string EnrollmentNo { get; set; }
	}
}
