// See https://aka.ms/new-console-template for more information



namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Fedulov", "Dima", "A", "M8O-211B-21", Student.practice_course_mode.C);
            Student student2 = new Student("Dush santush aveiru", "Cristiano Ronaldo", "dcm", "M8O-211B-21", Student.practice_course_mode.C);
            Console.WriteLine(student1.Course);
            Console.WriteLine(student1); 
            Console.WriteLine(student2.Equals(student1));
        }
    }
}