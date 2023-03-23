namespace SomerenModel
{
    public class Room
    {
        public int Id { get; set; }         // database id
        public int Number { get; set; }     // RoomNumber, e.g. 206
        public int Capacity { get; set; }   // number of beds, either 4, 6, 8, 12 or 16
        public RoomType Type;      // student = false, teacher = true
    }

    public enum RoomType { Dormitory = 0, Single = 1 }
}