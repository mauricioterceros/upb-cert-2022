using System;
using System.Collections.Generic;
using System.Text;

using Logic.Entities;
using Microsoft.Extensions.Configuration;
using Services;

namespace Logic.Managers
{
    public class StudentManager
    {
        private List<Student> _students;
        private IConfiguration _configuration;
        private AddressService _addressService;
        public StudentManager(IConfiguration configuration, AddressService addressService)
        {
            _configuration = configuration;
            _addressService = addressService;
            _students = new List<Student>();
            _students.Add(new Student() { Name = "Mauricio", LastName = "Terceros", Code = 44551 });
            _students.Add(new Student() { Name = "Andrew", LastName = "Smith", Code = 44552 });
            _students.Add(new Student() { Name = "David", LastName = "Walters", Code = 44553 });
        }
        public List<Student> GetStudents()
        {
            string envName = _configuration.GetSection("EnvName").Value;

            foreach (Student st in _students)
            {
                st.Name = $"{st.Name} ({envName})";
            }

            return _students;
        }

        public Student CreateStudent(string name, string lastName)
        {
            int generatedCode = new Random().Next(44600, 44700);
            Address retrievedAddress = _addressService.GetAddress().Result;
            Student createdStudent = new Student() { Name = name, LastName = lastName, Code = generatedCode, Address = retrievedAddress };
            _students.Add(createdStudent);
            return createdStudent;
        }
    }
}
