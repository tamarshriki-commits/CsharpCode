namespace CsharpCode;

public class Lecturer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ID { get; set; }
    public DateTime BirthDate { get; set; }

    public bool IsSuspended { get; set; }

    public List<Course> Courses { get; set; }

    public Lecturer(string firstName, string lastName,
        string id, DateTime birthDate, bool isSuspended)
    {
        FirstName = firstName;
        LastName = lastName;
        ID = id;
        BirthDate = birthDate;
        IsSuspended = isSuspended;

        Courses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course);
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, ID: {ID}";
    }
}