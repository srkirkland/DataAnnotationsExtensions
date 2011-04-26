namespace DataAnnotationsExtensions.Core
{
    public class NumericEntity
    {
        [Numeric]
        public string NumberAsString { get; set; }

        [Numeric] //Redundant, but won't cause problems
        public decimal NumberAsDecimal { get; set; }
    }
}
