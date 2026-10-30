namespace CsharpCode;

public class ClassroomManager
{
    private List<Classroom> classrooms;

    public ClassroomManager()
    {
        classrooms = new List<Classroom>();
    }

    public bool AddClassroom(Classroom classroom)
    {
        foreach (Classroom current in classrooms)
        {
            if (current.ClassroomId == classroom.ClassroomId &&
                current.Building == classroom.Building)
            {
                return false;
            }
        }

        classrooms.Add(classroom);
        return true;
    }

    public List<Classroom> GetAllClassrooms()
    {
        return classrooms;
    }
}