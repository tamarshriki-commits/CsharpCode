namespace CsharpCode;

public class CourseManager
{
    private List<Course> courses;

    public CourseManager()
    {
        courses = new List<Course>();
    }

    public bool AddCourse(Course course)
    {
        foreach (Course current in courses)
        {
            if (current.CourseCode == course.CourseCode)
            {
                return false;
            }
        }

        courses.Add(course);
        return true;
    }

    public Course FindCourse(string code)
    {
        foreach (Course course in courses)
        {
            if (course.CourseCode == code)
            {
                return course;
            }
        }

        return null;
    }

    public List<Course> GetAllCourses()
    {
        return courses;
    }
}