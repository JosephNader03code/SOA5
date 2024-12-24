namespace test
{
    internal class Courses
    {
        Dictionary<string, Tuple<string, string, double>> AvailableCourses = new Dictionary<string, Tuple<string, string, double>>()
        {

            { "Programing CS123", new Tuple<string, string, double>("Mahmoud Ismail", "Asmaa", 2000.00) },
            { "Digital CS456", new Tuple<string, string, double>("Mahmoud Gamal", "Instructor D", 2000.00) },
            { "Comuiniaction CS789", new Tuple<string, string, double>("Aml", "Instructor F", 2000.00) },
            { "Data Structure CS258", new Tuple<string, string, double>("Yossef ElSheimy", "Yassen Ramadan", 2000.00) }
        };
        public virtual void DisplayCourses()
        {
            foreach (var i in AvailableCourses)
            {
                string courseName = i.Key;
                string instructor1 = i.Value.Item1;
                string instructor2 = i.Value.Item2;
                double price = i.Value.Item3;


                Console.WriteLine($"Course: {courseName}");
                Console.WriteLine($"Instructor 1: {instructor1}");
                Console.WriteLine($"Instructor 2: {instructor2}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine();
            }

        }
    }

}