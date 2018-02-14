using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using DataAnnotationsExtensions.Resources;
using System.Web;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FileExtensionsAttribute : DataTypeAttribute
    {
        public string Extensions { get; private set; }

        /// <summary>
        /// Provide the allowed file extensions, seperated via comma or pipe, defaults to "png,jpeg,jpg,gif" 
        /// </summary>
        public FileExtensionsAttribute(string allowedExtensions = "png,jpg,jpeg,gif")
            : base("fileextension")
        {
            Extensions = string.IsNullOrWhiteSpace(allowedExtensions) ? "png,jpg,jpeg,gif" : allowedExtensions.Replace("|", ",").Replace(" ", "");
        }
        
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.FileExtensionsAttribute_Invalid;
            }

            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Extensions);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string valueAsString;
            if (value != null && value is HttpPostedFileBase)
            {
                valueAsString = (value as HttpPostedFileBase).FileName;
            }
            else
            {
                valueAsString = value as string;
            }

            if (valueAsString != null)
            {
                return ValidateExtension(valueAsString);
            }

            return false;
        }

        private bool ValidateExtension(string fileName)
        {
            try
            {
                return Extensions.Split(',').Contains(Path.GetExtension(fileName).Replace(".","").ToLowerInvariant());
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}