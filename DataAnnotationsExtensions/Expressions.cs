namespace DataAnnotationsExtensions
{
    public static class Expressions
    {
        public const string Cuit = @"^[0-9]{2}-?[0-9]{8}-?[0-9]$";

        /// <summary>
        /// Matches:
        ///   Country code: {{}, 0, ..., 0000, +0, ..., +0000} (with or without a trailing break character: [-/. ])
        ///   Area code: {(00), ..., (0000), 00, ..., 0000}
        ///   Local: {0, ...}+ (with or without a leading break character: [-/. ])
        /// </summary>
        public const string PhoneNumber = @"^(\+?\d{1,4}[-/.\s]?)?(\(\d{2,4}\)|\d{2,4})([-/.\s]?\d+)+$";

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
