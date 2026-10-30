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
        for (int i = 0; i < classrooms.Count; i++)
        {
            if (classrooms[i].ClassroomId == classroom.ClassroomId &&
                classrooms[i].Building == classroom.Building)
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