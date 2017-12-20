using System;
using RabbitMQ.Client;
using System.Text;

public class SenderRabbitMQ
{
    public SenderRabbitMQ()
    {
        //Constructor for SenderRabbitMQ class
    }

    //We can use this to send a message when a order is processed successfully and invoice is generated
    public void SendMessage()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = "Order Processed Successfully"; // Or Invoice generated
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}