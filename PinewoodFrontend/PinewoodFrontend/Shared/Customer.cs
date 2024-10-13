using System.Text.Json.Serialization;

namespace PinewoodFrontend.Shared
{
    public class Customer
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("DateOfBirth")]
        public DateTime Dob { get; set; }
    }
}
