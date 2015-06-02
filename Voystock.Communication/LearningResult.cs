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
    public class LearningResult
    {
        [DataMember]
        public bool LearningDone { get; set; }

        [DataMember]
        public List<ResultEntry> BestParameters { get; set; }

        [DataContract]
        public class ResultEntry
        {
            [DataMember]
            public Indicator Indicator { get; set; }

            public string Name { get { return Indicator.ToString(); } }

            [DataMember]
            public float WinRate { get; set; }

            [DataMember]
            public float Incoming { get; set; }
        }
    }
}
