using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DateNotBeforeAttribute : ValidationAttribute
    {
        public string EarlierTimeProperty { get; set; }
        public string LaterTimeProperty { get; set; }

        public DateNotBeforeAttribute(string earlier, string later)
        {
            EarlierTimeProperty = earlier;
            LaterTimeProperty = later;
        }

        public override bool IsValid(object value)
        {
            Type objectType = value.GetType();
            var properties = objectType.GetProperties();

            object earlierValue = new object();
            object laterValue = new object();

            Type earlierType = null;
            Type laterType = null;

            int counter = 0;

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name == EarlierTimeProperty || propertyInfo.Name == LaterTimeProperty)
                {
                    if (counter == 0)
                    {
                        earlierValue = propertyInfo.GetValue(value, null);
                        earlierType = propertyInfo.GetValue(value, null).GetType();
                    }

                    if (counter == 1)
                    {
                        laterValue = propertyInfo.GetValue(value, null);
                        laterType = propertyInfo.GetValue(value, null).GetType();
                    }
                    counter++;
                    if (counter == 2) break;

                }
            }
            if (earlierType != null && laterType != null)
            {
                DateTime earlierDate = (DateTime)Convert.ChangeType(earlierValue, earlierType);
                DateTime laterDate = (DateTime)Convert.ChangeType(laterValue, laterType);
                if (earlierDate <= laterDate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
