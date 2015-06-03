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
	public class Stock
	{
		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public string Name { get; set; }
	}
}
