using System.Text.Json.Serialization;

namespace Task3
{
    public class Car
    {
        [JsonPropertyName("id")]          // Maps the JSON 'id' field to the C# property 'id'
        public int id { get; set; }

        [JsonPropertyName("type")]       // Maps the JSON 'type' field to the C# property 'type'
        public string type { get; set; }

        [JsonPropertyName("passengers")] // Maps the JSON 'passengers' field to the C# property 'passengers'
        public string passengers { get; set; }

        [JsonPropertyName("isDining")]   // Maps the JSON 'isDining' field to the C# property 'isDining'
        public bool isDining { get; set; }

        [JsonPropertyName("consumption")] // Maps the JSON 'consumption' field to the C# property 'consumption'
        public int consumption { get; set; }

        public Car(int Id, string Type, string Passengers, bool IsDining, int Consumption)
        {
            id = Id;
            type = Type;
            passengers = Passengers;
            isDining = IsDining;
            consumption = Consumption;
        }
    }
}
