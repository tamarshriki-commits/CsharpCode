namespace CsharpCode;

public class CourseOffering
{
    public Course Course { get; set; }
    public Lecturer Lecturer { get; set; }
    public Classroom Classroom { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int NumberOfMeetings { get; set; }

    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public CourseOffering(Course course,
        Lecturer lecturer, Classroom classroom,
        DateTime startDate, int numberOfMeetings,
        TimeSpan startTime, TimeSpan endTime)
    {
        Course = course;
        Lecturer = lecturer;
        Classroom = classroom;

        StartDate = startDate;
        NumberOfMeetings = numberOfMeetings;

        StartTime = startTime;
        EndTime = endTime;

        EndDate = startDate.AddDays((numberOfMeetings - 1) * 7);
    }

    public override string ToString()
    {
        return $"{Course.CourseName} | " +
               $"{Lecturer.FirstName} {Lecturer.LastName} | " +
               $"Class: {Classroom.ClassroomId} | " +
               $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
    }
}