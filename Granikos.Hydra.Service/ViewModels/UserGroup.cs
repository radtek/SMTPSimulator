using System.Runtime.Serialization;
using Granikos.Hydra.Service.Models;

namespace Granikos.Hydra.Service.ViewModels
{
    [DataContract]
    public class UserGroup : IUserGroup
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int[] UserIds { get; set; }
    }
}