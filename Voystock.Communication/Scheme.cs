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
	public class Scheme
	{
		[DataMember]
		public int ID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public float FirstInvestmentPercent { get; set; }

		[DataMember]
		public float AdditionalInvestmentCondition { get; set; }

		[DataMember]
		public int HoldingCycles { get; set; }

		[DataMember]
		public float LossLimit { get; set; }

		[DataMember]
		public float ProfitLimit { get; set; }

		[DataMember]
		public List<Stock> EvaluationStocks { get; set; }

		[DataMember]
		public bool StartEvaluation { get; set; }

		[DataMember]
		public List<Indicator> EvaluationIndicators { get; set; }

		[DataMember]
		public bool StartLearning { get; set; }

		[DataMember]
		public bool LearningDone { get; set; }

		[DataMember]
		public List<Indicator> LearningIndicators { get; set; }

		[DataMember]
		public bool EnableRecommendation { get; set; }
	}
}
