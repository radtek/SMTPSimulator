using System.Runtime.Serialization;

namespace HydraService.Models
{
    [DataContract]
    public class ImportResult
    {
        public ImportResult(int imported, int deleted)
        {
            ImportCount = imported;
            OverwrittenCount = deleted;
        }

        [DataMember]
        public int ImportCount { get; private set; }

        [DataMember]
        public int OverwrittenCount { get; private set; }
    }
}