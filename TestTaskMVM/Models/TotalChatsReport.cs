namespace TestTaskMVM.Models
{
    public class TotalChatsReport
    {
        public string Name { get; set; }
        public Request Request { get; set; }
        public int Total { get; set; }
        public Dictionary<string, Record> Records { get; set; }
    }
}
