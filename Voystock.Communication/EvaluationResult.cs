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
	public class EvaluationResult
	{
		[DataMember]
		public float Progress { get; set; }

		public bool Done { get { return Progress >= 1.0f; } }

		[DataMember]
		public float Money { get; set; }

		[DataMember]
		public float WinRate { get; set; }
	}
}
