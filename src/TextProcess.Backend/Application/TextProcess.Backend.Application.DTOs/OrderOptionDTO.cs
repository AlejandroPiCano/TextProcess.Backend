using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace TextProcess.Backend.Application.DTOs
{
    [DataContract]
    public enum OrderOptionDTO
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "AlphabeticAsc")]
        AlphabeticAsc = 1,

        [EnumMember(Value = "AlphabeticDesc")]
        AlphabeticDesc = 2,

        [EnumMember(Value = "LenghtAsc")]
        LenghtAsc = 3        
    }
}