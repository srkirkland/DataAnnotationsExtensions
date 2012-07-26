using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UrlAttribute : DataTypeAttribute
    {
        /// <summary>
        /// The base URL regular expression.
        /// </summary>
        /// <remarks>
        /// RFC-952 describes basic name standards: http://www.ietf.org/rfc/rfc952.txt
        /// KB 909264 describes Windows name standards: http://support.microsoft.com/kb/909264
        /// </remarks>
        private const string BaseUrlExpression = @"(((([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-fA-F]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|([a-zA-Z][\-a-zA-Z0-9]*)|((([a-zA-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-zA-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-zA-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-zA-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-zA-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-zA-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-fA-F]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-fA-F]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-fA-F]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-fA-F]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?";

        /// <summary>
        /// The base protocol regular expression.
        /// </summary>
        private const string BaseProtocolExpression = @"(https?|ftp):\/\/";

        private readonly UrlOptions _urlOptions = UrlOptions.RequireProtocol; //Default to require protocol

        private readonly string _regex;

        public string Regex
        {
            get
            {
                return _regex;
            }
        }

        public UrlAttribute(UrlOptions urlOptions = UrlOptions.RequireProtocol) : base(DataType.Url)
        {
            _urlOptions = urlOptions;

            switch (urlOptions)
            {
                case UrlOptions.RequireProtocol:
                    _regex = @"^" + BaseProtocolExpression + BaseUrlExpression + @"$";
                    break;
                case UrlOptions.OptionalProtocol:
                    _regex = @"^(" + BaseProtocolExpression + @")?" + BaseUrlExpression + @"$";
                    break;
                case UrlOptions.DisallowProtocol:
                    _regex = @"^" + BaseUrlExpression + @"$";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("urlOptions");
            }
        }

        [Obsolete("Obsolete, use UrlAttribute(UrlOptions)")]
        public UrlAttribute(bool requireProtocol)
            : this(requireProtocol ? UrlOptions.RequireProtocol : UrlOptions.OptionalProtocol)
        {

        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                switch (_urlOptions)
                {
                    case UrlOptions.RequireProtocol:
                        ErrorMessage = ValidatorResources.UrlAttribute_Invalid;
                        break;
                    case UrlOptions.OptionalProtocol:
                        ErrorMessage = ValidatorResources.UrlAttributeProtocolOptional_Invalid;
                        break;
                    case UrlOptions.DisallowProtocol:
                        ErrorMessage = ValidatorResources.UrlAttributeWithoutProtocol_Invalid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueAsString =  value is Uri ? value.ToString() : value as string;
            
            return valueAsString != null &&
                   new Regex(_regex, RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(valueAsString).Length > 0;
        }
    }
}