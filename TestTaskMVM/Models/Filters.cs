using System.Text.RegularExpressions;

namespace TestTaskMVM.Models
{
    public class Filters
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Groups Groups { get; set; }
    }
}
