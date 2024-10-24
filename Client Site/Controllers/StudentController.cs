using CRUDAppUsingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CRUDAppUsingAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "http://localhost:5019/api/StudentAPI/";
        private HttpClient client = new HttpClient();
        private object encoding;

        [HttpGet]
        public IActionResult Index()
        {
            //List of student object create
            List<Student> students = new List<Student>();
            //Convert string url to http response
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode) 
            {
                //Get JSON result from response and convert it into string
                string result = response.Content.ReadAsStringAsync().Result;
                //Convert JSON string to List of student
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content?.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult _Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Messege"] = "Student Deleted ";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            //Convert student data to Json and pass through string
            string data = JsonConvert.SerializeObject(student);
            //Convert Jason data to Formated text
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Messege"] = "Student Added ";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url+student.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Messege"] = "Student Updated ";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

