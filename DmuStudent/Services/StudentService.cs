using DmuStudent.Contracts;
using DmuStudent.DTO;
using DmuStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DmuStudent.Services
{
	public class StudentService : IStudentService
	{
		private IStudentRepository _studentRepository;

		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public void DeleteStudent(long id)
		{
			_studentRepository.DeleteStudent(id);
		}

		public IEnumerable<StudentViewModel> GetAllStudents()
		{
			var getStudents = _studentRepository.GetAllStudents();
			IEnumerable<StudentViewModel> model = _studentRepository.GetAllStudents().Select(s => new StudentViewModel
			{
				Id = s.Id,
				FirstName = s.FirstName,
				LastName = s.LastName,
				EnrollmentNo = s.EnrollmentNo,
				Email = s.Email
			});

			return model;
		}

		public Student GetStudent(long id)
		{
			var student = _studentRepository.GetStudent(id);
			return student;
		}

		public void SaveStudent(StudentViewModel model)
		{
			Student student = new Student();
			
			student.FirstName = model.FirstName;
			student.LastName = model.LastName;
			student.EnrollmentNo = model.EnrollmentNo;
			student.Email = model.Email;
			student.ModifiedDate = DateTime.UtcNow;
			student.AddedDate = DateTime.UtcNow;

			_studentRepository.SaveStudent(student);

		}

		public void UpdateStudent(StudentViewModel model, long? id)
		{
			Student student = _studentRepository.GetStudent(id.Value);

			student.FirstName = model.FirstName;
			student.LastName = model.LastName;
			student.EnrollmentNo = model.EnrollmentNo;
			student.Email = model.Email;
			student.ModifiedDate = DateTime.UtcNow;

			_studentRepository.UpdateStudent(student);
		}
	}
}
