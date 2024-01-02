using AutoFillEntry.Maui.Platforms;

namespace AutoFillEntry.Maui;

public static class Helper
{
    // create your own builder logic here
    public static MauiAppBuilder UseAutoFillEntry(this MauiAppBuilder builder)
    {
        Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
        {
            if (view is Controls.AutoFillEntry)
            {
                AutoFillEntryMapper.Map(handler, view);
            }
        });
			
        // Return your custom builder object.
        return builder;
    }
}