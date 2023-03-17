using System;

namespace SomerenModel
{
    public class Student : Human
    {
        public int Number { get; set; } // StudentNumber, e.g. 474791
        public DateTime BirthDate { get; set; }
    }
}