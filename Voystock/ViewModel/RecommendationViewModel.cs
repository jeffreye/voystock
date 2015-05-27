using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Voystock.ViewModel
{
	/// <summary>
	/// This class contains properties that a View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class RecommendationViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the RecommendationViewModel class.
		/// </summary>
		public RecommendationViewModel()
		{
		}

		/// <summary>
		/// The <see cref="方案列表" /> property's name.
		/// </summary>
		public const string 方案列表PropertyName = "方案列表";

		private IEnumerable<string> _schemes = new[] { "MACD(10,20,5)" };

		/// <summary>
		/// Sets and gets the 方案列表 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<string> 方案列表
		{
			get
			{
				return _schemes;
			}
			set
			{
				Set(方案列表PropertyName, ref _schemes, value);
			}
		}

		/// <summary>
		/// The <see cref="已选择方案" /> property's name.
		/// </summary>
		public const string 已选择方案PropertyName = "已选择方案";

		private string _selectedScheme = "MACD(10,20,5)";

		/// <summary>
		/// Sets and gets the 已选择方案 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 已选择方案
		{
			get
			{
				return _selectedScheme;
			}
			set
			{
				Set(已选择方案PropertyName, ref _selectedScheme, value);
			}
		}

		/// <summary>
		/// The <see cref="已学习参数" /> property's name.
		/// </summary>
		public const string 已学习参数PropertyName = "已学习参数";

		private IEnumerable<Result> _learnedParameters = new[] 
		{
			new Result { Name = "MACD(9, 22, 9)	", WinRate =    0.3571f, 	Incoming = 0.2976f  },
			new Result { Name = "MACD(9, 25, 8)	", WinRate =    0.3571f, 	Incoming = 0.2814f  },
			new Result { Name = "MACD(10, 20, 9)", WinRate = 	0.3571f, 	Incoming = 0.3296f  },
			new Result { Name = "MACD(10, 22, 8)", WinRate = 	0.3571f, 	Incoming = 0.2976f  },
			new Result { Name = "MACD(11, 20, 8)", WinRate = 	0.3571f, 	Incoming = 0.3296f  },
			new Result { Name = "MACD(11, 23, 7)", WinRate = 	0.3571f, 	Incoming = 0.2926f  },
			new Result { Name = "MACD(12, 21, 7)", WinRate = 	0.3571f, 	Incoming = 0.2989f  },
			new Result { Name = "MACD(13, 17, 8)", WinRate = 	0.3571f, 	Incoming = 0.3220f  },
			new Result { Name = "MACD(13, 19, 7)", WinRate = 	0.3571f, 	Incoming = 0.3247f  },
			new Result { Name = "MACD(14, 20, 6)", WinRate = 	0.3571f, 	Incoming = 0.2716f  },
			new Result { Name = "MACD(18, 36, 9)", WinRate = 	0.3571f, 	Incoming = 0.1626f  },
			new Result { Name = "MACD(10, 19, 9)", WinRate = 	0.3556f, 	Incoming = 0.3099f  },
			new Result { Name = "MACD(13, 16, 8)", WinRate = 	0.3556f, 	Incoming = 0.3500f  },
			new Result { Name = "MACD(14, 22, 5)", WinRate = 	0.3556f, 	Incoming = 0.2369f  },
			new Result { Name = "MACD(15, 20, 5)", WinRate = 	0.3556f, 	Incoming = 0.2349f  },
			new Result { Name = "MACD(10, 22, 6)", WinRate = 	0.3542f, 	Incoming = 0.2090f  },
			new Result { Name = "MACD(12, 16, 7)", WinRate = 	0.3529f, 	Incoming = 0.2286f  },
			new Result { Name = "MACD(13, 15, 7)", WinRate = 	0.3529f, 	Incoming = 0.2351f  },
			new Result { Name = "MACD(10, 23, 8)", WinRate = 	0.3500f, 	Incoming = 0.2270f  },
		};

		/// <summary>
		/// Sets and gets the 已学习参数 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<Result> 已学习参数
		{
			get
			{
				return _learnedParameters;
			}
			set
			{
				Set(已学习参数PropertyName, ref _learnedParameters, value);
			}
		}

		public class Result
		{
			public string Name { get; set; }
			public float WinRate { get; set; }

			public float Incoming { get; set; }
		}

		private RelayCommand _start;

		/// <summary>
		/// Gets the 开始荐股.
		/// </summary>
		public RelayCommand 开始荐股
		{
			get
			{
				return _start
					?? (_start = new RelayCommand(
					() =>
					{

					}));
			}
		}

		/// <summary>
		/// The <see cref="荐股结果" /> property's name.
		/// </summary>
		public const string 荐股结果PropertyName = "荐股结果";

		private IEnumerable<Stock> _results = new[]
		{
			new Stock { Code = "002036" , Name = 	"汉麻产业"},
			new Stock { Code = "600601" , Name = 	"方正科技"},
			new Stock { Code = "600275" , Name = 	"武昌鱼  "},
			new Stock { Code = "000883" , Name = 	"湖北能源"},
			new Stock { Code = "002575" , Name = 	"群兴玩具"},
			new Stock { Code = "601777" , Name = 	"力帆股份"},
			new Stock { Code = "002397" , Name = 	"梦洁家纺"},
			new Stock { Code = "600250" , Name = 	"南纺股份"},
			new Stock { Code = "002135" , Name = 	"东南网架"},
			new Stock { Code = "600505" , Name = 	"西昌电力"},
			new Stock { Code = "002526" , Name = 	"山东矿机"},
			new Stock { Code = "000066" , Name = 	"长城电脑"},
			new Stock { Code = "002255" , Name = 	"海陆重工"},
			new Stock { Code = "002282" , Name = 	"博深工具"},
			new Stock { Code = "000595" , Name = 	"西北轴承"},
			new Stock { Code = "600400" , Name = 	"红豆股份"},
			new Stock { Code = "603126" , Name = 	"中材节能"},
			new Stock { Code = "600190" , Name = 	"锦州港  "},
			new Stock { Code = "002389" , Name = 	"南洋科技"},
			new Stock { Code = "600328" , Name = 	"兰太实业"},

		};

		public class Stock
		{
			public string Name { get; set; }
			public string Code { get; set; }
		}

		/// <summary>
		/// Sets and gets the 荐股结果 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<Stock> 荐股结果
		{
			get
			{
				return _results;
			}
			set
			{
				Set(荐股结果PropertyName, ref _results, value);
			}
		}
	}
}