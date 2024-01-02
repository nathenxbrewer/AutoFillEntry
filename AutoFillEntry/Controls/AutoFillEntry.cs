namespace AutoFillEntry.Maui.Controls;

public sealed class AutoFillEntry : Entry
{
    public static BindableProperty ContentTypeProperty =
        BindableProperty.Create(nameof(ContentType), typeof(ContentType), typeof(AutoFillEntry), ContentType.Unspecified);
        
    public ContentType ContentType
    {
        get => (ContentType)GetValue(ContentTypeProperty);
        set => SetValue(ContentTypeProperty, value);
    }
}

