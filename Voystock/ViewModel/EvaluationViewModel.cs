using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Voystock.ViewModel
{
	/// <summary>
	/// This class contains properties that a View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class EvaluationViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the EvaluationPage class.
		/// </summary>
		public EvaluationViewModel()
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
		/// The <see cref="起始时间" /> property's name.
		/// </summary>
		public const string 起始时间PropertyName = "起始时间";

		private DateTime _startTime = DateTime.Now;

		/// <summary>
		/// Sets and gets the 起始时间 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public DateTime 起始时间
		{
			get
			{
				return _startTime;
			}
			set
			{
				Set(起始时间PropertyName, ref _startTime, value);
			}
		}

		/// <summary>
		/// The <see cref="结束时间" /> property's name.
		/// </summary>
		public const string 结束时间PropertyName = "结束时间";

		private DateTime _endTime = DateTime.Now;

		/// <summary>
		/// Sets and gets the 结束时间 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public DateTime 结束时间
		{
			get
			{
				return _endTime;
			}
			set
			{
				Set(结束时间PropertyName, ref _endTime, value);
			}
		}

		/// <summary>
		/// The <see cref="首次投入资金比例" /> property's name.
		/// </summary>
		public const string 首次投入资金比例PropertyName = "首次投入资金比例";

		private int _firstInvestmentPercent = 50;

		/// <summary>
		/// Sets and gets the 首次投入资金比例 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 首次投入资金比例
		{
			get
			{
				return _firstInvestmentPercent;
			}
			set
			{
				Set(首次投入资金比例PropertyName, ref _firstInvestmentPercent, value);
			}
		}

		/// <summary>
		/// The <see cref="首次卖出股票比例" /> property's name.
		/// </summary>
		public const string 首次卖出股票比例PropertyName = "首次卖出股票比例";

		private int _firstSellPercent = 50;

		/// <summary>
		/// Sets and gets the 首次卖出股票比例 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 首次卖出股票比例
		{
			get
			{
				return _firstSellPercent;
			}
			set
			{
				Set(首次卖出股票比例PropertyName, ref _firstSellPercent, value);
			}
		}

		/// <summary>
		/// The <see cref="投入剩余资金上涨条件" /> property's name.
		/// </summary>
		public const string 投入剩余资金上涨条件PropertyName = "投入剩余资金上涨条件";

		private int _additionalInvestmentCondition = 7;

		/// <summary>
		/// Sets and gets the 投入剩余资金上涨条件 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 投入剩余资金上涨条件
		{
			get
			{
				return _additionalInvestmentCondition;
			}
			set
			{
				Set(投入剩余资金上涨条件PropertyName, ref _additionalInvestmentCondition, value);
			}
		}

		/// <summary>
		/// The <see cref="卖出剩余股票下跌条件" /> property's name.
		/// </summary>
		public const string 卖出剩余股票下跌条件PropertyName = "卖出剩余股票下跌条件";

		private int _additionalSellCondition = 7;

		/// <summary>
		/// Sets and gets the 卖出剩余股票下跌条件 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 卖出剩余股票下跌条件
		{
			get
			{
				return _additionalSellCondition;
			}
			set
			{
				Set(卖出剩余股票下跌条件PropertyName, ref _additionalSellCondition, value);
			}
		}

		/// <summary>
		/// The <see cref="止盈率" /> property's name.
		/// </summary>
		public const string 止盈率PropertyName = "止盈率";

		private int _profitLimit = 7;

		/// <summary>
		/// Sets and gets the 止盈率 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 止盈率
		{
			get
			{
				return _profitLimit;
			}
			set
			{
				Set(止盈率PropertyName, ref _profitLimit, value);
			}
		}

		/// <summary>
		/// The <see cref="止损率" /> property's name.
		/// </summary>
		public const string 止损率PropertyName = "止损率";

		private int _lossLimit = 7;

		/// <summary>
		/// Sets and gets the 止损率 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 止损率
		{
			get
			{
				return _lossLimit;
			}
			set
			{
				Set(止损率PropertyName, ref _lossLimit, value);
			}
		}

		/// <summary>
		/// The <see cref="止盈率启用" /> property's name.
		/// </summary>
		public const string 止盈率启用PropertyName = "止盈率启用";

		private bool _enableProfitLimit = false;

		/// <summary>
		/// Sets and gets the 止盈率启用 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public bool 止盈率启用
		{
			get
			{
				return _enableProfitLimit;
			}
			set
			{
				Set(止盈率启用PropertyName, ref _enableProfitLimit, value);
			}
		}

		/// <summary>
		/// The <see cref="止损率启用" /> property's name.
		/// </summary>
		public const string 止损率启用PropertyName = "止损率启用";

		private bool _enableLossLimit = false;

		/// <summary>
		/// Sets and gets the 止损率启用 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public bool 止损率启用
		{
			get
			{
				return _enableLossLimit;
			}
			set
			{
				Set(止损率启用PropertyName, ref _enableLossLimit, value);
			}
		}

		/// <summary>
		/// The <see cref="固定交易周期" /> property's name.
		/// </summary>
		public const string 固定交易周期PropertyName = "固定交易周期";

		private int _holdingCycles = 15;

		/// <summary>
		/// Sets and gets the 固定交易周期 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 固定交易周期
		{
			get
			{
				return _holdingCycles;
			}
			set
			{
				Set(固定交易周期PropertyName, ref _holdingCycles, value);
			}
		}

		/// <summary>
		/// The <see cref="固定交易周期启用" /> property's name.
		/// </summary>
		public const string 固定交易周期启用PropertyName = "固定交易周期启用";

		private bool _enableHoldingCycles = false;

		/// <summary>
		/// Sets and gets the 固定交易周期启用 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public bool 固定交易周期启用
		{
			get
			{
				return _enableHoldingCycles;
			}
			set
			{
				Set(固定交易周期启用PropertyName, ref _enableHoldingCycles, value);
			}
		}

		/// <summary>
		/// The <see cref="已选股票" /> property's name.
		/// </summary>
		public const string 已选股票PropertyName = "已选股票";

		private System.Collections.Generic.IEnumerable<string> _selectedStocks = new []{"平安银行","工商银行","交通银行"};

		/// <summary>
		/// Sets and gets the 已选股票 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public System.Collections.Generic.IEnumerable<string> 已选股票
		{
			get
			{
				return _selectedStocks;
			}
			set
			{
				Set(已选股票PropertyName, ref _selectedStocks, value);
			}
		}

		/// <summary>
		/// The <see cref="全部股票选中" /> property's name.
		/// </summary>
		public const string 全部股票选中PropertyName = "全部股票选中";

		private bool _selectAllStock = false;

		/// <summary>
		/// Sets and gets the 全部股票选中 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public bool 全部股票选中
		{
			get
			{
				return _selectAllStock;
			}
			set
			{
				Set(全部股票选中PropertyName, ref _selectAllStock, value);
			}
		}

		/// <summary>
		/// The <see cref="所有指标" /> property's name.
		/// </summary>
		public const string 所有指标PropertyName = "所有指标";

		private IEnumerable<string> _allIndicator = new []{"MACD","MA","KD"};

		/// <summary>
		/// Sets and gets the 所有指标 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<string> 所有指标
		{
			get
			{
				return _allIndicator;
			}
			set
			{
				Set(所有指标PropertyName, ref _allIndicator, value);
			}
		}

		/// <summary>
		/// The <see cref="当前选中指标" /> property's name.
		/// </summary>
		public const string 当前选中指标PropertyName = "当前选中指标";

		private string _selectedIndicator = "";

		/// <summary>
		/// Sets and gets the 当前选中指标 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 当前选中指标
		{
			get
			{
				return _selectedIndicator;
			}
			set
			{
				Set(当前选中指标PropertyName, ref _selectedIndicator, value);
			}
		}

		/// <summary>
		/// The <see cref="当前选中股票的买入点" /> property's name.
		/// </summary>
		public const string 当前选中股票的买入点PropertyName = "当前选中股票的买入点";

		private string _buyCondition = "出现金叉";

		/// <summary>
		/// Sets and gets the 当前选中股票的买入点 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 当前选中股票的买入点
		{
			get
			{
				return _buyCondition;
			}
			set
			{
				Set(当前选中股票的买入点PropertyName, ref _buyCondition, value);
			}
		}

		/// <summary>
		/// The <see cref="当前选中股票的卖出点" /> property's name.
		/// </summary>
		public const string 当前选中股票的卖出点PropertyName = "当前选中股票的卖出点";

		private string _sellCondition = "出现死叉";

		/// <summary>
		/// Sets and gets the 当前选中股票的卖出点 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 当前选中股票的卖出点
		{
			get
			{
				return _sellCondition;
			}
			set
			{
				Set(当前选中股票的卖出点PropertyName, ref _sellCondition, value);
			}
		}

		/// <summary>
		/// The <see cref="当前选中股票备注" /> property's name.
		/// </summary>
		public const string 当前选中股票备注PropertyName = "当前选中股票备注";

		private string _currentTips = "别乱填参数啊亲";

		/// <summary>
		/// Sets and gets the 当前选中股票备注 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 当前选中股票备注
		{
			get
			{
				return _currentTips;
			}
			set
			{
				Set(当前选中股票备注PropertyName, ref _currentTips, value);
			}
		}

		/// <summary>
		/// The <see cref="已配置的指标" /> property's name.
		/// </summary>
		public const string 已配置的指标PropertyName = "已配置的指标";

		private IEnumerable<string> _configedIndicators = new [] {"MACD(10,20,5)" };

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

		/// <summary>
		/// The <see cref="评测结束" /> property's name.
		/// </summary>
		public const string 评测结束PropertyName = "评测结束";

		private bool _evaluationDone = false;

		/// <summary>
		/// Sets and gets the 评测结束 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public bool 评测结束
		{
			get
			{
				return _evaluationDone;
			}
			set
			{
				Set(评测结束PropertyName, ref _evaluationDone, value);
			}
		}

		/// <summary>
		/// The <see cref="胜率" /> property's name.
		/// </summary>
		public const string 胜率PropertyName = "胜率";

		private float _winRate = 0.5f;

		/// <summary>
		/// Sets and gets the 胜率 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public float 胜率
		{
			get
			{
				return _winRate;
			}
			set
			{
				Set(胜率PropertyName, ref _winRate, value);
			}
		}

		/// <summary>
		/// The <see cref="年化收益率" /> property's name.
		/// </summary>
		public const string 年化收益率PropertyName = "年化收益率";

		private float _annualIncoming = 0.15f;

		/// <summary>
		/// Sets and gets the 年化收益率 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public float 年化收益率
		{
			get
			{
				return _annualIncoming;
			}
			set
			{
				Set(年化收益率PropertyName, ref _annualIncoming, value);
			}
		}

		private RelayCommand _learnScheme;

		/// <summary>
		/// Gets the 学习此方案.
		/// </summary>
		public RelayCommand 学习此方案
		{
			get
			{
				return _learnScheme
					?? (_learnScheme = new RelayCommand(
					() =>
					{
						if (!学习此方案.CanExecute(null))
						{
							return;
						}


					},
					() => 评测结束));
			}
		}

		private RelayCommand _reviewDetails;

		/// <summary>
		/// Gets the 查看交易详情.
		/// </summary>
		public RelayCommand 查看交易详情
		{
			get
			{
				return _reviewDetails
					?? (_reviewDetails = new RelayCommand(
					() =>
					{
						if (!查看交易详情.CanExecute(null))
						{
							return;
						}


					},
					() => 评测结束));
			}
		}
	}
}