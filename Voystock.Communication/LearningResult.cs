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
		public List<Indicator> BestParameters { get; set; }
	}
}
