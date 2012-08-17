namespace DataAnnotationsExtensions.Core
{
    public class NotNullOrZeroEntity
    {
        [NotNullOrZero]
        public int? NotNullOrZeroInt { get; set; }

        [NotNullOrZero]
        public double? NotNullOrZeroDouble { get; set; }
    }
}
