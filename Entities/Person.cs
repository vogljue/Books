
namespace Books.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string DisplayName => $"{Lastname},{Firstname}";

        public Person()
        {
            Id = 0;
            Lastname = string.Empty;
            Address = string.Empty;
            EmailAddress = string.Empty;
            Country = string.Empty;
        }

        public override string ToString()
        {
            return $"{Id}, {Lastname}, {Firstname}, {Address}, {EmailAddress}, {Country}";
        }
    }
}
