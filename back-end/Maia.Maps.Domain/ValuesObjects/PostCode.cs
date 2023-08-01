namespace Maia.Maps.Domain.ValuesObjects
{
    public class PostCode : ValueObject
    {
        public PostCode(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; }
        public string To { get; }
    }
}
