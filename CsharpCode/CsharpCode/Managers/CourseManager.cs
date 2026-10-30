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
        for (int i = 0; i < courses.Count; i++)
        {
            if (courses[i].CourseCode == course.CourseCode)
            {
                return false;
            }
        }

        courses.Add(course);
        return true;
    }

    public Course FindCourse(string code)
    {
        for (int i = 0; i < courses.Count; i++)
        {
            if (courses[i].CourseCode == code)
            {
                return courses[i];
            }
        }

        return null;
    }

    public List<Course> GetAllCourses()
    {
        return courses;
    }
}