using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel

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

		private string _schemeName = "MACD(1,2,3)";

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

		private IEnumerable<string> _learnedParameters = new[] 
		{
			"MACD(6, 7, 3)	 ",
			"MACD(5, 9, 3)	 ",
			"MACD(7, 10, 3)	 ",
			"MACD(7, 8, 2)	 ",
			"MACD(5, 10, 3)	 ",
			"MACD(6, 10, 2)	 ",
			"MACD(5, 8, 3)	 ",
			"MACD(6, 9, 2)	 ",
			"MACD(6, 8, 3)	 ",
		};


		/// <summary>
		/// Sets and gets the 已学习参数 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<string> 已学习参数
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