using System.Text;
using System.Text.Json;

namespace WeTicket.Domain.Infrastructure.Messaging;

public class Message<TData>
{
    public MetaData MetaData { get; set; }

    public string EventType { get; set; }

    public TData Data { get; set; }

    public string SerializeObject()
    {
        return JsonSerializer.Serialize(this);
    }

    public byte[] GetBytes()
    {
        return Encoding.UTF8.GetBytes(SerializeObject());
    }
}