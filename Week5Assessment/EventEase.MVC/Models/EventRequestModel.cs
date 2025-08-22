namespace EventEase.MVC.Models
{
    public class EventRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Location
        {
            get; set;
        }
    }
}
