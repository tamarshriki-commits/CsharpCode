namespace CsharpCode;

public class Course
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }
    public string ParentFaculty { get; set; }
    public int StudyHours { get; set; }

    public Course(string courseCode, string courseName,
        int credits, string parentFaculty, int studyHours)
    {
        CourseCode = courseCode;
        CourseName = courseName;
        Credits = credits;
        ParentFaculty = parentFaculty;
        StudyHours = studyHours;
    }

    public override string ToString()
    {
        return $"{CourseCode} - {CourseName}";
    }
}