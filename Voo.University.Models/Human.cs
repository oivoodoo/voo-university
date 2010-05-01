namespace Voo.University.Models
{
    public enum Sex
    {
        Male,
        Female
    }

    /// <summary>
    /// Class implements base model for storing general human information
    /// </summary>
    [ContentType("0x01")]
    public class Human : DataObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PostcalCode { get; set; }
        public string Age { get; set; }

        public Sex Sex { get; protected set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", Name, Surname); }
        }
    }
}