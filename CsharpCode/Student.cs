
namespace CsharpCode;

public class Student
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public DateTime BirthDate { get; set; }

        public StudyTrack Track { get; set; }
        public Profession Profession { get; set; }

        public Student(string firstName, string lastName,
            string id, DateTime birthDate,
            StudyTrack track, Profession profession)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            BirthDate = birthDate;
            Track = track;
            Profession = profession;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, ID: {ID}";
        }
}
