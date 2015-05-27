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
        //[DataMember]
        //public string Date { get; set; }

        [DataMember]
        public string StockCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public RecommendationOperation Operation { get; set; }

        public bool IsSell { get { return Operation == RecommendationOperation.Sell; } }

        public bool IsBuy { get { return Operation == RecommendationOperation.Buy; } }

        public bool IsWait { get { return Operation == RecommendationOperation.Wait; } }
    }

    public enum RecommendationOperation
    {
        Wait,
        Buy,
        Sell
    }
}
