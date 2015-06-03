using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Voystock.Communication
{
    [DataContract]
    public class IndicatorDescription
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int SupportParameterCount { get; set; }

        [DataMember]
        public string BuyPoint { get; set; }

        [DataMember]
        public string SellPoint { get; set; }

        [DataMember(IsRequired = false)]
        public string Remark { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
