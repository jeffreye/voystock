﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Voystock.Communication
{
    [DataContract]
    public class Indicator
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<float> Parameters { get; set; } = new List<float>();

        public override string ToString()
        {
            return string.Format("{0}({1})", Name, string.Join(",", Parameters));
        }
    }
}
