namespace CsharpCode;

public class Classroom
{
    public string ClassroomId { get; set; }
    public string Building { get; set; }
    public int Seats { get; set; }

    public Classroom(string classroomId,
        string building, int seats)
    {
        ClassroomId = classroomId;
        Building = building;
        Seats = seats;
    }

    public override string ToString()
    {
        return $"Class {ClassroomId}, Building: {Building}, Seats: {Seats}";
    }
}