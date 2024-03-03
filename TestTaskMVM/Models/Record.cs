using System.Text.Json.Serialization;

namespace TestTaskMVM.Models
{
    public class Record
    {
        // Для Total Chats и Duration
        [JsonPropertyName("total")]
        public int Total { get; set; }
        // Для Duration
        [JsonPropertyName("agents_chatting_duration")]
        public int AgentsChattingDuration { get; set; }
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        // Для Ratings
        [JsonPropertyName("bad")]
        public int Bad { get; set; }
        [JsonPropertyName("good")]
        public int Good { get; set; }
        [JsonPropertyName("chats")]
        public int Chats { get; set; }
        // Для Response Time
        [JsonPropertyName("response_time")]
        public double Response_time { get; set; }
        [JsonPropertyName("count")]
        public double Count { get; set; }
        // Для Tags (пример, вы можете адаптировать в зависимости от структуры)
        public Dictionary<string, object>? Tags { get; set; }
    }
}
