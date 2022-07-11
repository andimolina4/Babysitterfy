using BabysitterfyApp.Dtos;

namespace BabysitterfyApp.Models
{
    public class BabySitter
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Price { get; set; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeEnd { get; set; }
    }
}
