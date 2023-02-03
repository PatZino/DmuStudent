using System;
using System.ComponentModel.DataAnnotations;

namespace DmuStudent.DTO
{
	public class StudentViewModel
	{
		public Int64 Id { get; set; }
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[Display(Name = "Enrollment No")]
		public string EnrollmentNo { get; set; }
	}
}
