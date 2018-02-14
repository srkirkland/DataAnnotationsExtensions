using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using DataAnnotationsExtensions.Resources;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace DataAnnotationsExtensions
{
    /// <summary>
    /// Can be applied to string or objects that implement IFormFile
    /// See: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads for info on file uploads in aspnet core
    /// </summary>
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
            if (value != null && value is IFormFile)
            {
                valueAsString = (value as IFormFile).FileName;
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