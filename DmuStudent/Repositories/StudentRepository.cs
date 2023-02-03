using DmuStudent.Contracts;
using DmuStudent.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DmuStudent.Repositories
{
	public class StudentRepository : IStudentRepository
	{
        private ApplicationContext context;
        private DbSet<Student> studentEntity;
        public StudentRepository(ApplicationContext context)
        {
            this.context = context;
            studentEntity = context.Set<Student>();
        }


        public void SaveStudent(Student student)
        {
            context.Entry(student).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return studentEntity.AsEnumerable();
        }

        public Student GetStudent(long id)
        {
            return studentEntity.SingleOrDefault(s => s.Id == id);
        }
        public void DeleteStudent(long id)
        {
            Student student = GetStudent(id);
            studentEntity.Remove(student);
            context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            context.SaveChanges();
        }
    }
}
