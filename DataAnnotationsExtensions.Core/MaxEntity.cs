namespace DataAnnotationsExtensions.Core
{
    public class MaxEntity
    {
        [Max(50)]
        public int MaxFifty { get; set; }

        [Max(10.5)]
        public double MaxTenAndAHalf { get; set; }
    }
}