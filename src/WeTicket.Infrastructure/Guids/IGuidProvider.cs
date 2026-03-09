using WeTicket.Contract.Guids;

namespace WeTicket.Infrastructure.Guids;

public class GuidProvider : IGuidProvider
{
    public Guid Create()
    {
        return Guid.NewGuid();
    }
}