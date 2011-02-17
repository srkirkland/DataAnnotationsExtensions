using System;

namespace DataAnnotationsExtensions.Core
{
    public class DateEntity
    {
        [Date]
        public string DateAsString { get; set; }

        [Date]
        public DateTime DateTime { get; set; }

        public DateEntity()
        {
            DateTime = DateTime.Now;
        }
    }
}
