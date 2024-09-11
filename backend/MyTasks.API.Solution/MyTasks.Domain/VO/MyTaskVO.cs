

using System.ComponentModel.DataAnnotations;

namespace MyTasks.Domain.VO
{
    public class MyTaskVO
    {
        public long Id { get; set; }
        [Required]
        public String Title { get; set; }
        public String Description { get; set; }
        public bool Done { get; set; }
    }
}
