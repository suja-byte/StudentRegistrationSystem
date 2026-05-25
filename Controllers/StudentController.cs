using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            students.Add(student);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var student = students.FirstOrDefault(x => x.Email == id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var student = students.FirstOrDefault(x => x.Email == updatedStudent.Email);

            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Department = updatedStudent.Department;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var student = students.FirstOrDefault(x => x.Email == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}