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
        for (int i = 0; i < lecturers.Count; i++)
        {
            if (lecturers[i].ID == lecturer.ID)
            {
                return false;
            }
        }

        lecturers.Add(lecturer);
        return true;
    }

    public Lecturer FindLecturer(string id)
    {
        for (int i = 0; i < lecturers.Count; i++)
        {
            if (lecturers[i].ID == id)
            {
                return lecturers[i];
            }
        }

        return null;
    }

    public List<Lecturer> GetLecturersForCourse(Course course)
    {
        List<Lecturer> result = new List<Lecturer>();

        for (int i = 0; i < lecturers.Count; i++)
        {
            if (!lecturers[i].IsSuspended)
            {
                for (int j = 0; j < lecturers[i].Courses.Count; j++)
                {
                    if (lecturers[i].Courses[j].CourseCode == course.CourseCode)
                    {
                        result.Add(lecturers[i]);
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
