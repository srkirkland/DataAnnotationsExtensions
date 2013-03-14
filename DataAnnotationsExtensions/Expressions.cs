namespace DataAnnotationsExtensions
{
    public static class Expressions
    {
        public const string Cuit = @"^[0-9]{2}-?[0-9]{8}-?[0-9]$";

        /// <summary>
        /// Matches:
        ///   International dialing prefix: {{}, +, 0, 0000} (with or without a trailing break character, if not '+': [-/. ])
        ///     > ((\+)|(0(\d+)?[-/.\s]))
        ///   Country code: {{}, 1, ..., 999} (with or without a trailing break character: [-/. ])
        ///     > [1-9]\d{,2}[-/.\s]?
        ///   Area code: {(0), ..., (000000), 0, ..., 000000} (with or without a trailing break character: [-/. ])
        ///     > ((\(\d{1,6}\)|\d{1,6})[-/.\s]?)?
        ///   Local: {0, ...}+ (with or without a trailing break character: [-/. ])
        ///     > (\d+[-/.\s]?)+\d+
        /// </summary>
        /// <remarks>
        /// This regular expression is not complete for identifying the numerous variations that exist in phone numbers.
        /// It provides basic assertions on the format and will help to eliminate most nonsense input but does not
        /// guarantee validity of the value entered for any specific geography. If greater value checking is required
        /// then consider: http://nuget.org/packages/libphonenumber-csharp.
        /// </remarks>
        public const string PhoneNumber = @"^((\+|(0(\d+)?[-/.\s]?))[1-9]\d{0,2}[-/.\s]?)?((\(\d{1,6}\)|\d{1,6})[-/.\s]?)?(\d+[-/.\s]?)+\d+$";

        /// <summary>
        /// ISO 4217:2008: Currency codes. Confirms structure not validity.
        /// </summary>
        public const string CurrencyCode = @"^[a-zA-Z]{3}|[0-9]{3}$";

        /// <summary>
        /// ISO 3166: Country codes. Confirms structure not validity.
        /// </summary>
        public const string CountryCode = @"^[a-zA-Z]{2,3}|[0-9]{3}$";

        /// <summary>
        /// RFC 4646: ISO 639 + ISO 3166: Culture codes. Confirms structure not validity.
        /// Matches:
        ///   Neutral culture: {aa, ..., ZZZ}
        ///   Neutral culture with script: {aa-aaaa, ..., ZZZ-ZZZZ}
        ///   Specific culture: {aa-aa, ..., ZZZ-ZZZ, aa-000, ... ZZZ-000}
        ///   Specific culture with script: {aa-aa-aaaa, ..., ZZZ-ZZZ-ZZZZ, aa-000-aaaa, ..., ZZZ-000-ZZZZ}
        /// </summary>
        public const string CultureCode = @"^[a-zA-Z]{2,3}(-([a-zA-Z]{2,3}|[0-9]{3}))?(-[a-zA-Z]{4})?$";
    }
}
