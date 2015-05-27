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
	public class LearningViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the LearningViewModel class.
		/// </summary>
		public LearningViewModel()
		{
		}


		/// <summary>
		/// The <see cref="方案名称" /> property's name.
		/// </summary>
		public const string 方案名称PropertyName = "方案名称";

		private string _schemeName = "MACD(10,20,5)";

		/// <summary>
		/// Sets and gets the 方案名称 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 方案名称
		{
			get
			{
				return _schemeName;
			}

			set
			{
				if (_schemeName == value)
				{
					return;
				}

				_schemeName = value;
				RaisePropertyChanged(方案名称PropertyName);
			}
		}

		/// <summary>
        /// The <see cref="所有方案列表" /> property's name.
        /// </summary>
        public const string 所有方案列表PropertyName = "所有方案列表";

        private ObservableCollection<string> _schemes = new ObservableCollection<string>(){"MACD(10,20,5)"};

        /// <summary>
        /// Sets and gets the 所有方案列表 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> 所有方案列表
        {
            get
            {
                return _schemes;
            }

            set
            {
                if (_schemes == value)
                {
                    return;
                }

                _schemes = value;
                RaisePropertyChanged(所有方案列表PropertyName);
            }
        }

		/// <summary>
		/// The <see cref="已配置的指标" /> property's name.
		/// </summary>
		public const string 已配置的指标PropertyName = "已配置的指标";

		private ObservableCollection<string> _configedIndicators = new ObservableCollection<string>() { "MACD(10,20,5)" };

		/// <summary>
		/// Sets and gets the 已配置的指标 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public ObservableCollection<string> 已配置的指标
		{
			get
			{
				return _configedIndicators;
			}
			set
			{
				Set(已配置的指标PropertyName, ref _configedIndicators, value);
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

		public class Result
		{
			public string Name { get; set; }
			public float WinRate { get; set; }

			public float Incoming { get; set; }
		}


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

		/// <summary>
		/// The <see cref="个股模式" /> property's name.
		/// </summary>
		public const string 个股模式PropertyName = "个股模式";

		private bool _independent = false;

		/// <summary>
		/// Sets and gets the 个股模式 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public bool 个股模式
		{
			get
			{
				return _independent;
			}
			set
			{
				Set(个股模式PropertyName, ref _independent, value);
			}
		}

		private RelayCommand _start;

		/// <summary>
		/// Gets the 开始学习.
		/// </summary>
		public RelayCommand 开始学习
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

		private RelayCommand _checkResults;

		/// <summary>
		/// Gets the 查看学习详情.
		/// </summary>
		public RelayCommand 查看学习详情
		{
			get
			{
				return _checkResults
					?? (_checkResults = new RelayCommand(
					() =>
					{
						if (System.IO.File.Exists("学习详情.xlsx"))
						{
							System.Diagnostics.Process.Start("学习详情.xlsx");
						}
					}));
			}
		}
	}
}