using Microsoft.Maui.Handlers;
using UIKit;

namespace AutoFillEntry.Maui.Platforms
{
    public static class AutoFillEntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            if (view is Controls.AutoFillEntry)
            {
                var casted = (EntryHandler)handler;
                var viewData = (Controls.AutoFillEntry)view;

                switch (viewData.ContentType)
                {
                    case ContentType.EmailAddress:
                        casted.PlatformView.SetTextContentType(UITextContentType.EmailAddress);
                        break;
                    case ContentType.FullName:
                        break;
                    case ContentType.FirstName:
                        casted.PlatformView.SetTextContentType(UITextContentType.GivenName);
                        break;
                    case ContentType.LastName:
                        casted.PlatformView.SetTextContentType(UITextContentType.FamilyName);
                        break;
                    case ContentType.Phone:
                        casted.PlatformView.SetTextContentType(UITextContentType.TelephoneNumber);
                        break;
                    case ContentType.StreetAddress:
                        casted.PlatformView.SetTextContentType(UITextContentType.FullStreetAddress);
                        break;
                    case ContentType.Unspecified:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

}
