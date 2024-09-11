namespace MyTasks.API.DTOs
{
    public class MyTaskDTO
    {
        public long Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public bool Done { get; set; }
    }
}
