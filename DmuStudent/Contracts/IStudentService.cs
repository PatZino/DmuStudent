using DmuStudent.DTO;
using DmuStudent.Models;
using System.Collections.Generic;

namespace DmuStudent.Contracts
{
	public interface IStudentService
	{
		void SaveStudent(StudentViewModel student);
		IEnumerable<StudentViewModel> GetAllStudents();
		Student GetStudent(long id);
		void DeleteStudent(long id);
		void UpdateStudent(StudentViewModel student, long? id);
	}
}
