using MiniStore.Contract.Guids;

namespace MiniStore.Infrastructure.Guids;

public class GuidProvider : IGuidProvider
{
    public Guid Create()
    {
        return Guid.NewGuid();
    }
}