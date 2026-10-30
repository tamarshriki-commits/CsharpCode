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
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].ID == student.ID)
            {
                return false;
            }
        }

        students.Add(student);
        return true;
    }

    public Student FindStudent(string id)
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].ID == id)
            {
                return students[i];
            }
        }

        return null;
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}