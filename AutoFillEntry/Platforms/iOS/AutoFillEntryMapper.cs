using Microsoft.Maui.Handlers;
using UIKit;
using static UIKit.UITextContentType;

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

                var contentType = Name;
                contentType = viewData.ContentType switch
                {
                    ContentType.EmailAddress => EmailAddress,
                    ContentType.FullName => Name,
                    ContentType.FirstName => GivenName,
                    ContentType.LastName => FamilyName,
                    ContentType.MiddleName => MiddleName,
                    ContentType.Phone => TelephoneNumber,
                    ContentType.StreetAddress => FullStreetAddress,
                    ContentType.Address1 => StreetAddressLine1,
                    ContentType.Address2 => StreetAddressLine2,
                    ContentType.City => AddressCity,
                    ContentType.State => AddressState,
                    ContentType.PostalCode => PostalCode,
                    ContentType.Country => CountryName,
                    ContentType.Username => Username,
                    ContentType.Password => Password,
                    ContentType.NewPassword => NewPassword,
                    ContentType.EmailOTP => OneTimeCode,
                    ContentType.SmsOTP => OneTimeCode,
                    ContentType.Birthday => Birthdate,
                    ContentType.BirthdayDay => BirthdateDay,
                    ContentType.BirthdayMonth => BirthdateMonth,
                    ContentType.BirthdayYear => BirthdateYear,
                    _ => throw new ArgumentOutOfRangeException()
                };
                casted.PlatformView.SetTextContentType(contentType);
            }
        }
    }

}
