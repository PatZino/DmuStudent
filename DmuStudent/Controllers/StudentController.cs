using DmuStudent.Contracts;
using DmuStudent.DTO;
using DmuStudent.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DmuStudent.Controllers
{
	public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _studentService.GetAllStudents();
			return View(nameof(Index), model);
        }

        [HttpGet]
        public IActionResult AddEditStudent(long? id)
        {
            StudentViewModel model = new StudentViewModel();
            if (id.HasValue)
            {
                Student student = _studentService.GetStudent(id.Value); if (student != null)
                {
                    model.Id = student.Id;
                    model.FirstName = student.FirstName;
                    model.LastName = student.LastName;
                    model.EnrollmentNo = student.EnrollmentNo;
                    model.Email = student.Email;
                }
            }
            return PartialView("~/Views/Student/AddEditStudent.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditStudent(long? id, StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        _studentService.SaveStudent(model);
                    }
                    else
                    {
                        _studentService.UpdateStudent(model, id);
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
            Student student = _studentService.GetStudent(id);
            StudentViewModel model = new StudentViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            return PartialView("~/Views/Student/DeleteStudent.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteStudent(long id, StudentViewModel model)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
