using System.Runtime.Serialization;

namespace Phoenix.CRM.Integration.Entities
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember(Name = "zip")]
        public string ZipCode { get; set; }
    }
}
