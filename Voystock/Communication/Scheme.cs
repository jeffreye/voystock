using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;

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
        public float FirstSellPercent { get; set; }

        [DataMember]
        public float AdditionalSellCondition { get; set; }

        [DataMember]
		public int HoldingCycles { get; set; }

		[DataMember]
		public float LossLimit { get; set; }

		[DataMember]
		public float ProfitLimit { get; set; }

        [DataMember]
        public SchemeType CombinationType { get; set; }

        [DataMember]
        public int TolerantDays { get; set; } = 5;


        [DataMember]
		public ObservableCollection<Stock> EvaluationStocks { get; set; }

        [DataMember]
        public bool StartEvaluation { get; set; }

        [DataMember]
        string EvaluationStartTime;

        [DataMember]
        string EvaluationEndTime;

        [DataMember]
		public ObservableCollection<Indicator> EvaluationIndicators { get; set; }


		[DataMember]
		public bool StartLearning { get; set; }

		//[DataMember]
		//public bool LearningDone { get; set; }

		[DataMember]
		public LearningResult LearningIndicators { get; set; }

		[DataMember]
		public bool EnableRecommendation { get; set; }


        public DateTime EvaluationStartDate { get; set; }

        public DateTime EvaluationEndDate { get; set; }

        [OnSerializing]
        void OnSerialized(System.Runtime.Serialization.StreamingContext ctx)
        {
            EvaluationStartTime = EvaluationStartDate.ToShortDateString();
            EvaluationEndTime = EvaluationEndDate.ToShortDateString();
        }

        [OnDeserialized]
        void OnDeserializing(System.Runtime.Serialization.StreamingContext ctx)
        {
            EvaluationStartDate = DateTime.Parse(EvaluationStartTime);
            EvaluationEndDate = DateTime.Parse(EvaluationEndTime);
        }

    }

    public enum SchemeType
    {
        Parallel = 1,
        Series,
        Seperated
    }
}
