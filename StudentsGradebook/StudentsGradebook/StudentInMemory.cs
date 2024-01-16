﻿namespace StudentsGradebook
{
    public class StudentInMemory : StudentBase
    {
        private List<float> grades = new List<float>();

        public override event GradeAddedDalegate GradeAdded;

        public StudentInMemory(string firstName, string lastName, string studentClass)
            :base(firstName, lastName, studentClass)
        {
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
                        Console.WriteLine($"Invalid Grade: {grade}");
                        break;
                }
            }
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);

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

        public override void AddGrade(int grade)
        {
            float intToFloat = grade;
            this.AddGrade(intToFloat);
        }

        public override Grades GetGrades()
        {
            var statistics = new Grades();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}
