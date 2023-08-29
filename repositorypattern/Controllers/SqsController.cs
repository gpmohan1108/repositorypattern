using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using repositorypattern.Model;
using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon;

namespace repositorypattern.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class SqsController : Controller
    {
        [HttpPost]
        public IActionResult Post(Product emp)
        {
            var credentials = new BasicAWSCredentials("AKIA27QAY", "Z1MbRwqz1L/IrZPY8XgHxXnjtP");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);



            var request = new SendMessageRequest
            {

                MessageBody = JsonSerializer.Serialize(emp),
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/754030919443/myqueue"
            };
            client.SendMessageAsync(request).Wait();
            return NoContent();
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var credentials = new BasicAWSCredentials("AKIA27D5JQAY", "Z1MbR6z1L/IrZPY8XgHxXnjtP");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);



            var request = new ReceiveMessageRequest
            {
                // MessageBody = JsonSerializer.Serialize(emp),
                MaxNumberOfMessages = 10,
                WaitTimeSeconds = 10,
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/754030919443/myqueue"
            };
            var req = client.ReceiveMessageAsync(request).Result;
            var list = new List<Product>();
            foreach (var item in req.Messages)
            {
                var m = JsonSerializer.Deserialize<Product>(item.Body);
                list.Add(m);



            }
            return list;
        }

    }
}
