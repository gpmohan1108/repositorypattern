using System.Text.Json;

namespace repositorypattern.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Other properties
    }
    public class ErrorResponse
    {
        public int statuscode { get; set; }
        public string message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
