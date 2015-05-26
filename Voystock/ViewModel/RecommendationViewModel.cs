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
        
		private IEnumerable<string> _schemes = new []{"plan a","plan b"};

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
		/// The <see cref="已配置的指标" /> property's name.
		/// </summary>
		public const string 已配置的指标PropertyName = "已配置的指标";

		private IEnumerable<string> _configedIndicators = new[] { "MACD(10,20,5)" };

		/// <summary>
		/// Sets and gets the 已配置的指标 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<string> 已配置的指标
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

		private IEnumerable<string> _results = new [] {"什么鬼银行"};

		/// <summary>
		/// Sets and gets the 荐股结果 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<string> 荐股结果
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