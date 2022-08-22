using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            
            Teacher berat = new Teacher (mediator);
            berat.Name = "Berat";

            mediator.Teacher = berat;

            Student damla = new Student(mediator);
            damla.Name = "Damla";
            

            

            Student busra = new Student(mediator);
            busra.Name = "Büşra";

            mediator.Students = new List<Student> {damla,busra };

            berat.SendNewImgUrl("slider1.jpg");

            berat.RecieveQuestion("is it true", busra);

            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0}, {1}", student.Name,question);
        }

        public void SendNewImgUrl(string url)
        {
            Console.WriteLine("teacher changed slide: {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("teacher answerd question {0},{1}",student.Name,answer);

        }
        
    }

     class Student:CourseMember
     {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} student received image: {0}",url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("student received answer {0}", answer);
        }

        public string Name { get; set; }

        
     }
    

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
