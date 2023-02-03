using AutoMapper;
using DmuStudent.Contracts;
using DmuStudent.DTO;
using DmuStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmuStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Index()
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
			return View(nameof(Index), model);
        }

        [HttpGet]
        public IActionResult AddEditStudent(long? id)
        {
            StudentViewModel model = new StudentViewModel();
            if (id.HasValue)
            {
                Student student = _studentRepository.GetStudent(id.Value); if (student != null)
                {
                    model.Id = student.Id;
                    model.FirstName = student.FirstName;
                    model.LastName = student.LastName;
                    model.EnrollmentNo = student.EnrollmentNo;
                    model.Email = student.Email;
                }
            }
            return PartialView("~/Views/Student/_AddEditStudent.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditStudent(long? id, StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Student student = isNew ? new Student
                    {
                        AddedDate = DateTime.UtcNow
                    } : _studentRepository.GetStudent(id.Value);
                    student.FirstName = model.FirstName;
                    student.LastName = model.LastName;
                    student.EnrollmentNo = model.EnrollmentNo;
                    student.Email = model.Email;
                    student.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    student.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        _studentRepository.SaveStudent(student);
                    }
                    else
                    {
                        _studentRepository.UpdateStudent(student);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteStudent(long id)
        {
            Student student = _studentRepository.GetStudent(id);
            StudentViewModel model = new StudentViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            return PartialView("~/Views/Student/_DeleteStudent.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteStudent(long id, StudentViewModel model)
        {
            _studentRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
