namespace CsharpCode;

public class LecturerManager
{
    private List<Lecturer> lecturers;

    public LecturerManager()
    {
        lecturers = new List<Lecturer>();
    }

    public bool AddLecturer(Lecturer lecturer)
    {
        foreach (Lecturer current in lecturers)
        {
            if (current.ID == lecturer.ID)
            {
                return false;
            }
        }

        lecturers.Add(lecturer);
        return true;
    }

    public Lecturer FindLecturer(string id)
    {
        foreach (Lecturer lecturer in lecturers)
        {
            if (lecturer.ID == id)
            {
                return lecturer;
            }
        }

        return null;
    }

    public List<Lecturer> GetLecturersForCourse(Course course)
    {
        List<Lecturer> result = new List<Lecturer>();

        foreach (Lecturer lecturer in lecturers)
        {
            if (!lecturer.IsSuspended)
            {
                foreach (Course lecturerCourse in lecturer.Courses)
                {
                    if (lecturerCourse.CourseCode == course.CourseCode)
                    {
                        result.Add(lecturer);
                        break;
                    }
                }
            }
        }

        return result;
    }

    public List<Lecturer> GetAllLecturers()
    {
        return lecturers;
    }
}
