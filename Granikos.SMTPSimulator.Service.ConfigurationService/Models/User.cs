using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Granikos.SMTPSimulator.Service.Models;

namespace Granikos.SMTPSimulator.Service.ConfigurationService.Models
{
    [DataContract]
    public class User : IUser
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        [Required]
        public string Mailbox { get; set; }
    }
}