using System.Diagnostics;

namespace WeTicket.Contract.Logging;

public class ActivityExtensions
{
    public static Activity StartNew(string name, string? parentId = null)
    {
        Activity activity = new(name);

        if (!string.IsNullOrEmpty(parentId))
        {
            activity.SetParentId(parentId);
        }

        activity.Start();
        return activity;
    }
}