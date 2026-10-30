namespace CsharpCode;

public class StudentManager
{
    private List<Student> students;

    public StudentManager()
    {
        students = new List<Student>();
    }

    public bool AddStudent(Student student)
    {
        foreach (Student current in students)
        {
            if (current.ID == student.ID)
            {
                return false;
            }
        }

        students.Add(student);
        return true;
    }

    public Student FindStudent(string id)
    {
        foreach (Student student in students)
        {
            if (student.ID == id)
            {
                return student;
            }
        }

        return null;
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}