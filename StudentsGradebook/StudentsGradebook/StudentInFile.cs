﻿namespace StudentsGradebook
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "_grades.txt";

        private string fullFileName;

        public override event GradeAddedDalegate GradeAdded;

        public StudentInFile(string firstName, string lastName, string studentClass) 
            : base(firstName, lastName, studentClass)
        {
            fullFileName = $"{firstName}-{lastName}_{studentClass}_{fileName}";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(grade);
                }
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception($"Invalid Grade: Grade {grade}, value must be between 1 to 6.");
            }

        }

        public override Grades GetGrades()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.GetGrades(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        public override void GetAllValuesFromList()
        {
            var grades = new List<float>();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }

            foreach (var element in grades)
            {
                switch (element)
                {
                    case 6:
                        Console.Write("6; ");
                        break;
                    case 5.75f:
                        Console.Write("-6; ");
                        break;
                    case 5.50f:
                        Console.Write("+5; ");
                        break;
                    case 5:
                        Console.Write("5; ");
                        break;
                    case 4.75f:
                        Console.Write("-5; ");
                        break;
                    case 4.50f:
                        Console.Write("+4 ");
                        break;
                    case 4:
                        Console.Write("4; ");
                        break;
                    case 3.75f:
                        Console.Write("-4; ");
                        break;
                    case 3.50f:
                        Console.Write("+3; ");
                        break;
                    case 3:
                        Console.Write("3; ");
                        break;
                    case 2.75f:
                        Console.Write("-3; ");
                        break;
                    case 2.50f:
                        Console.Write("+2; ");
                        break;
                    case 2:
                        Console.Write("2; ");
                        break;
                    case 1.75f:
                        Console.Write("-2; ");
                        break;
                    case 1.50f:
                        Console.Write("+1; ");
                        break;
                    default:
                        Console.WriteLine("1; ");
                        break;
                }
            }
        }

        public override void AddGrade(int grade)
        {
            float intToFloat = grade;
            this.AddGrade(intToFloat);
        }

        public override void AddGrade(string grade)
        {
        if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                switch (grade)
                {
                    case "A":
                    case "6":
                        this.AddGrade(6);
                        break;
                    case "A-":
                    case "-A":
                    case "-6":
                    case "6-":
                        this.AddGrade(5.75f);
                        break;
                    case "B+":
                    case "+B":
                    case "+5":
                    case "5+":
                        this.AddGrade(5.50f);
                        break;
                    case "B":
                    case "5":
                        this.AddGrade(5);
                        break;
                    case "B-":
                    case "-B":
                    case "-5":
                    case "5-":
                        this.AddGrade(4.75f);
                        break;
                    case "C+":
                    case "+C":
                    case "+4":
                    case "4+":
                        this.AddGrade(4.50f);
                        break;
                    case "C":
                    case "4":
                        this.AddGrade(4);
                        break;
                    case "C-":
                    case "-C":
                    case "-4":
                    case "4-":
                        this.AddGrade(3.75f);
                        break;
                    case "D+":
                    case "+D":
                    case "+3":
                    case "3+":
                        this.AddGrade(3.50f);
                        break;
                    case "D":
                    case "3":
                        this.AddGrade(3);
                        break;
                    case "D-":
                    case "-D":
                    case "-3":
                    case "3-":
                        this.AddGrade(2.75f);
                        break;
                    case "E+":
                    case "+E":
                    case "+2":
                    case "2+":
                        this.AddGrade(2.50f);
                        break;
                    case "E":
                    case "2":
                        this.AddGrade(2);
                        break;
                    case "E-":
                    case "-E":
                    case "-2":
                    case "2-":
                        this.AddGrade(1.75f);
                        break;
                    case "F+":
                    case "+F":
                    case "+1":
                    case "1+":
                        this.AddGrade(1.50f);
                        break;
                    case "F":
                    case "1":
                        this.AddGrade(1);
                        break;
                    default:
                        Console.WriteLine($"Invalid String: {grade}");
                        break;
                }
            }
        }

        public Grades GetGrades(List<float> grades)
        {
            var statistics = new Grades();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
