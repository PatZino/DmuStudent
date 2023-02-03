using DmuStudent.Models;
using System.Collections.Generic;

namespace DmuStudent.Contracts
{
	public interface IStudentRepository
    {
        void SaveStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(long id);
        void DeleteStudent(long id);
        void UpdateStudent(Student student);
    }
}
