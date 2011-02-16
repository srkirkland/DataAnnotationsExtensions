namespace DataAnnotationsExtensions.Core
{
    public class MinEntity
    {
        [Min(50)]
        public int MinFifty { get; set; }

        [Min(10.5)]
        public double MinTenAndAHalf { get; set; }
    }
}
