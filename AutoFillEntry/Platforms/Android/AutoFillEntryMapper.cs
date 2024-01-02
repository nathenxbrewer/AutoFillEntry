using Android.Views;
using Android.Views.Autofill;
using Android.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace AutoFillEntry.Maui.Platforms
{
    public static class AutoFillEntryMapper
    {
        private const string AUTOFILL_HINT_EMAIL_ADDRESS = "emailAddress";
        private const string AUTOFILL_HINT_PERSON_NAME = "personName";
        private const string AUTOFILL_HINT_PERSON_NAME_GIVEN = "personGivenName";
        private const string AUTOFILL_HINT_PERSON_NAME_MIDDLE = "personMiddleName";
        private const string AUTOFILL_HINT_PERSON_NAME_FAMILY = "personFamilyName";
        private const string AUTOFILL_HINT_PHONE_NUMBER = "phoneNumber";
        private const string AUTOFILL_HINT_POSTAL_ADDRESS_STREET_ADDRESS = "streetAddress";
        private const string AUTOFILL_HINT_POSTAL_CODE = "postalCode";
        private const string AUTOFILL_HINT_USERNAME = "username";
        private const string AUTOFILL_HINT_PASSWORD = "password";
        private const string AUTOFILL_HINT_NEW_PASSWORD = "newPassword";
        private const string AUTOFILL_HINT_POSTAL_ADDRESS_COUNTRY = "addressCountry";
        private const string AUTOFILL_HINT_EMAIL_OTP = "emailOTPCode";
        private const string AUTOFILL_HINT_SMS_OTP = "smsOTPCode";
        private const string AUTOFILL_HINT_BIRTH_DATE_FULL = "birthDateFull";
        private const string AUTOFILL_HINT_BIRTH_DATE_DAY = "birthDateDay";
        private const string AUTOFILL_HINT_BIRTH_DATE_MONTH = "birthDateMonth";
        private const string AUTOFILL_HINT_BIRTH_DATE_YEAR = "birthDateYear";
        private const string AUTOFILL_HINT_POSTAL_ADDRESS_LOCALITY = "addressLocality";
        private const string AUTOFILL_HINT_POSTAL_ADDRESS_REGION = "addressRegion";
    

        public static void Map(IElementHandler handler, IElement view)
        {
            if (view is not Controls.AutoFillEntry) return;
            var casted = (EntryHandler)handler;
            var viewData = (Controls.AutoFillEntry)view;
            var textView = (EditText)casted.PlatformView;
            var autofillmanager = (AutofillManager)Android.App.Application.Context.GetSystemService("autofill");
            autofillmanager?.RequestAutofill(textView);
            textView.ImportantForAutofill = ImportantForAutofill.Yes;
            var autoFillHint = viewData.ContentType switch
            {
                ContentType.EmailAddress => AUTOFILL_HINT_EMAIL_ADDRESS,
                ContentType.FullName => AUTOFILL_HINT_PERSON_NAME,
                ContentType.FirstName => AUTOFILL_HINT_PERSON_NAME_GIVEN,
                ContentType.LastName => AUTOFILL_HINT_PERSON_NAME_FAMILY,
                ContentType.MiddleName => AUTOFILL_HINT_PERSON_NAME_MIDDLE,
                ContentType.Phone => AUTOFILL_HINT_PHONE_NUMBER,
                ContentType.StreetAddress => AUTOFILL_HINT_POSTAL_ADDRESS_STREET_ADDRESS,
                ContentType.Address1 => AUTOFILL_HINT_POSTAL_ADDRESS_STREET_ADDRESS,
                ContentType.Address2 => AUTOFILL_HINT_POSTAL_ADDRESS_STREET_ADDRESS,
                ContentType.City => AUTOFILL_HINT_POSTAL_ADDRESS_LOCALITY,
                ContentType.State => AUTOFILL_HINT_POSTAL_ADDRESS_REGION,
                ContentType.PostalCode => AUTOFILL_HINT_POSTAL_CODE,
                ContentType.Country => AUTOFILL_HINT_POSTAL_ADDRESS_COUNTRY,
                ContentType.Username => AUTOFILL_HINT_USERNAME,
                ContentType.Password => AUTOFILL_HINT_PASSWORD,
                ContentType.NewPassword => AUTOFILL_HINT_NEW_PASSWORD,
                ContentType.EmailOTP => AUTOFILL_HINT_EMAIL_OTP,
                ContentType.SmsOTP => AUTOFILL_HINT_SMS_OTP,
                ContentType.Birthday => AUTOFILL_HINT_BIRTH_DATE_FULL,
                ContentType.BirthdayDay => AUTOFILL_HINT_BIRTH_DATE_DAY,
                ContentType.BirthdayMonth => AUTOFILL_HINT_BIRTH_DATE_MONTH,
                ContentType.BirthdayYear => AUTOFILL_HINT_BIRTH_DATE_YEAR,
                _ => throw new ArgumentOutOfRangeException()
            };
            casted.PlatformView.SetAutofillHints(autoFillHint);
        }

    }
}
