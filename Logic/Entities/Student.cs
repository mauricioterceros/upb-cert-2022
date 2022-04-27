using Services;

namespace Logic.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Code { get; set; }
        public Address Address { get; set; }
    }
}