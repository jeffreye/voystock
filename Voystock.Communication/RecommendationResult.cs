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
	public class RecommendationResult
	{
        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string StockCode { get; set; }

        [DataMember]
        public RecommendationOperation Operation { get; set; }
    }

    public enum RecommendationOperation
    {
        Wait,
        Buy,
        Sell
    }
}
