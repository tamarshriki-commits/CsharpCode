
namespace CsharpCode;

public class CourseOfferingManager
{
    private List<CourseOffering> offerings;

    public CourseOfferingManager()
    {
        offerings = new List<CourseOffering>();
    }

    public List<CourseOffering> GetAllOfferings()
    {
        return offerings;
    }

    private bool IsTimeOverlapping(
        TimeSpan start1, TimeSpan end1,
        TimeSpan start2, TimeSpan end2)
    {
        return start1 < end2 && end1 > start2;
    }

    public bool IsLecturerAvailable(
        Lecturer lecturer,
        DateTime startDate,
        int numberOfMeetings,
        TimeSpan startTime,
        TimeSpan endTime)
    {
        for (int i = 0; i < numberOfMeetings; i++)
        {
            DateTime currentDate = startDate.AddDays(i * 7);

            for (int j = 0; j < offerings.Count; j++)
            {
                CourseOffering offering = offerings[j];

                if (offering.Lecturer.ID == lecturer.ID)
                {
                    bool sameDate =
                        offering.StartDate.Date <= currentDate.Date &&
                        currentDate.Date <= offering.EndDate.Date &&
                        (currentDate.Date - offering.StartDate.Date).Days % 7 == 0;

                    if (sameDate)
                    {
                        if (IsTimeOverlapping(
                            startTime, endTime,
                            offering.StartTime, offering.EndTime))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public bool IsClassroomAvailable(
        Classroom classroom,
        DateTime startDate,
        int numberOfMeetings,
        TimeSpan startTime,
        TimeSpan endTime)
    {
        for (int i = 0; i < numberOfMeetings; i++)
        {
            DateTime currentDate = startDate.AddDays(i * 7);

            for (int j = 0; j < offerings.Count; j++)
            {
                CourseOffering offering = offerings[j];

                if (offering.Classroom.ClassroomId ==
                        classroom.ClassroomId &&
                    offering.Classroom.Building == classroom.Building)
                {
                    bool sameDate =
                        offering.StartDate.Date <= currentDate.Date &&
                        currentDate.Date <= offering.EndDate.Date &&
                        (currentDate.Date - offering.StartDate.Date).Days % 7 == 0;

                    if (sameDate)
                    {
                        if (IsTimeOverlapping(
                            startTime, endTime,
                            offering.StartTime, offering.EndTime))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public List<Classroom> GetAvailableClassrooms(
        List<Classroom> classrooms,
        Lecturer lecturer,
        DateTime startDate,
        int numberOfMeetings,
        TimeSpan startTime,
        TimeSpan endTime)
    {
        List<Classroom> available = new List<Classroom>();

        if (!IsLecturerAvailable(
            lecturer, startDate, numberOfMeetings,
            startTime, endTime))
        {
            return available;
        }

        for (int i = 0; i < classrooms.Count; i++)
        {
            Classroom classroom = classrooms[i];

            if (IsClassroomAvailable(
                classroom, startDate, numberOfMeetings,
                startTime, endTime))
            {
                available.Add(classroom);
            }
        }

        return available;
    }

    public bool AddOffering(CourseOffering offering)
    {
        if (!IsLecturerAvailable(
            offering.Lecturer,
            offering.StartDate,
            offering.NumberOfMeetings,
            offering.StartTime,
            offering.EndTime))
        {
            return false;
        }

        if (!IsClassroomAvailable(
            offering.Classroom,
            offering.StartDate,
            offering.NumberOfMeetings,
            offering.StartTime,
            offering.EndTime))
        {
            return false;
        }

        offerings.Add(offering);
        return true;
    }
}
