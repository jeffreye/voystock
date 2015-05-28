using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Voystock.Communication;

namespace Voystock.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CreateSchemeViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the EvaluationPage class.
        /// </summary>
        public CreateSchemeViewModel()
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

        #region 规则

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
        #endregion

        #region 标的(股票)

        /// <summary>
        /// The <see cref="已选股票" /> property's name.
        /// </summary>
        public const string 已选股票PropertyName = "已选股票";

        private ObservableCollection<Stock> _selectedStocks = new ObservableCollection<Stock>
        {
            new Stock { Code = "002036" , Name =    "汉麻产业"},
            new Stock { Code = "600601" , Name =    "方正科技"},
            new Stock { Code = "600275" , Name =    "武昌鱼  "},
            new Stock { Code = "000883" , Name =    "湖北能源"},
            new Stock { Code = "002575" , Name =    "群兴玩具"},
            new Stock { Code = "601777" , Name =    "力帆股份"},
            new Stock { Code = "002397" , Name =    "梦洁家纺"},
            new Stock { Code = "600250" , Name =    "南纺股份"},
            new Stock { Code = "002135" , Name =    "东南网架"},
            new Stock { Code = "600505" , Name =    "西昌电力"},
            new Stock { Code = "002526" , Name =    "山东矿机"},
            new Stock { Code = "000066" , Name =    "长城电脑"},
            new Stock { Code = "002255" , Name =    "海陆重工"},
            new Stock { Code = "002282" , Name =    "博深工具"},
            new Stock { Code = "000595" , Name =    "西北轴承"},
            new Stock { Code = "600400" , Name =    "红豆股份"},
            new Stock { Code = "603126" , Name =    "中材节能"},
            new Stock { Code = "600190" , Name =    "锦州港  "},
            new Stock { Code = "002389" , Name =    "南洋科技"},
            new Stock { Code = "600328" , Name =    "兰太实业"},
        };

        private readonly ReadOnlyCollection<Stock> _allStock = new List<Stock>()
        { new Stock { Code = "000000" , Name = "全部股票"} }.AsReadOnly();

        /// <summary>
        /// Sets and gets the 已选股票 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IEnumerable<Stock> 已选股票
        {
            get
            {
                return _selectAllStock ? (IEnumerable<Stock>)_allStock : _selectedStocks;
            }
            //set
            //{
            //	Set(已选股票PropertyName, ref _selectedStocks, value);
            //}
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

                RaisePropertyChanged(已选股票PropertyName);
            }
        }

        private RelayCommand<string> _addStock;

        /// <summary>
        /// Gets the 自定义添加股票.
        /// </summary>
        public RelayCommand<string> 自定义添加股票
        {
            get
            {
                return _addStock
                    ?? (_addStock = new RelayCommand<string>(
                    code =>
                    {
                        // TODO: search stocks
                        throw new NotImplementedException();
                    }));
            }
        }

        #endregion

        #region 指标加减

        /// <summary>
        /// The <see cref="所有指标" /> property's name.
        /// </summary>
        public const string 所有指标PropertyName = "所有指标";

        /// <summary>
        /// Sets and gets the 所有指标 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IEnumerable<IndicatorDescription> 所有指标
        {
            get
            {
                return UserSession.Indicators;
            }
        }

        /// <summary>
        /// The <see cref="当前选中指标" /> property's name.
        /// </summary>
        public const string 当前选中指标PropertyName = "当前选中指标";

        private IndicatorDescription _selectedIndicator = new IndicatorDescription()
        {
            Name = "MACD",
            BuyPoint = "出现金叉",
            SellPoint = "出现死叉",
            Remark = ""
        };

        /// <summary>
        /// Sets and gets the 当前选中指标 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IndicatorDescription 当前选中指标
        {
            get
            {
                return _selectedIndicator;
            }
            set
            {
                Set(当前选中指标PropertyName, ref _selectedIndicator, value);
                //RaisePropertyChanged(指标参数1PropertyName);
                //RaisePropertyChanged(指标参数2PropertyName);
                //RaisePropertyChanged(指标参数3PropertyName);
                RaisePropertyChanged(nameof(当前选中股票的买入点));
                RaisePropertyChanged(nameof(当前选中股票的卖出点));
                RaisePropertyChanged(nameof(当前选中股票备注));
            }
        }

        /// <summary>
        /// The <see cref="指标参数1" /> property's name.
        /// </summary>
        public const string 指标参数1PropertyName = "指标参数1";

        private int _param1 = 8;

        /// <summary>
        /// Sets and gets the 指标参数1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int 指标参数1
        {
            get
            {
                return _param1;
            }
            set
            {
                Set(指标参数1PropertyName, ref _param1, value);
            }
        }

        /// <summary>
        /// The <see cref="指标参数2" /> property's name.
        /// </summary>
        public const string 指标参数2PropertyName = "指标参数2";

        private int _param2 = 20;

        /// <summary>
        /// Sets and gets the 指标参数2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int 指标参数2
        {
            get
            {
                return _param2;
            }
            set
            {
                Set(指标参数2PropertyName, ref _param2, value);
            }
        }

        /// <summary>
        /// The <see cref="指标参数3" /> property's name.
        /// </summary>
        public const string 指标参数3PropertyName = "指标参数3";

        private int _param3 = 5;

        /// <summary>
        /// Sets and gets the 指标参数3 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int 指标参数3
        {
            get
            {
                return _param3;
            }
            set
            {
                Set(指标参数3PropertyName, ref _param3, value);
            }
        }

        /// <summary>
        /// Sets and gets the 当前选中股票的买入点 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string 当前选中股票的买入点
        {
            get
            {
                return _selectedIndicator.BuyPoint;
            }
        }

        /// <summary>
        /// Sets and gets the 当前选中股票的卖出点 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string 当前选中股票的卖出点
        {
            get
            {
                return _selectedIndicator.SellPoint;
            }
        }

        /// <summary>
        /// Sets and gets the 当前选中股票备注 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string 当前选中股票备注
        {
            get
            {
                return _selectedIndicator.Remark;
            }
        }

        /// <summary>
        /// The <see cref="已配置的指标" /> property's name.
        /// </summary>
        public const string 已配置的指标PropertyName = "已配置的指标";

        private ObservableCollection<Indicator> _configedIndicators = new ObservableCollection<Indicator>();

        /// <summary>
        /// Sets and gets the 已配置的指标 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Indicator> 已配置的指标
        {
            get
            {
                return _configedIndicators;
            }
            //private set
            //{
            //	Set(已配置的指标PropertyName, ref _configedIndicators, value);
            //}
        }


        private RelayCommand _addIndicator;

        /// <summary>
        /// Gets the 添加指标.
        /// </summary>
        public RelayCommand 添加指标
        {
            get
            {
                return _addIndicator
                    ?? (_addIndicator = new RelayCommand(
                    () =>
                    {
                        _configedIndicators.Add(
                            new Indicator()
                            {
                                Name = 当前选中指标.Name,
                                Parameters = new List<float>() { 指标参数1, 指标参数2, 指标参数3 }
                            });
                    }));
            }
        }

        private RelayCommand<Indicator> _deleteIndicaot;

        /// <summary>
        /// Gets the 删除指标.
        /// </summary>
        public RelayCommand<Indicator> 删除指标
        {
            get
            {
                return _deleteIndicaot
                    ?? (_deleteIndicaot = new RelayCommand<Indicator>(
                    p =>
                    {
                        _configedIndicators.Remove(p);
                    }));
            }
        }

        #endregion

        #region 方案管理

        public Scheme SchemeDetail { get; set; } = new Scheme();

        public bool IsCreated
        {
            get
            {
                return SchemeDetail.ID != 0;
            }
        }

        private RelayCommand _createScheme;

        /// <summary>
        /// Gets the 添加方案.
        /// </summary>
        public RelayCommand 添加方案
        {
            get
            {
                return _createScheme
                    ?? (_createScheme = new RelayCommand(Execute添加或修改方案));
            }
        }

        async void Execute添加或修改方案()
        {
            await AddOrCreateScheme();
        }

        protected async Task AddOrCreateScheme()
        {
            SchemeDetail.Name = _schemeName;
            SchemeDetail.FirstInvestmentPercent = _firstInvestmentPercent;
            SchemeDetail.AdditionalInvestmentCondition = _additionalInvestmentCondition;
            SchemeDetail.FirstSellPercent = _firstSellPercent;
            SchemeDetail.AdditionalSellCondition = _additionalSellCondition;
            SchemeDetail.HoldingCycles = _holdingCycles;
            SchemeDetail.LossLimit = _enableLossLimit ? _lossLimit : 100f;
            SchemeDetail.ProfitLimit = _enableProfitLimit ? _profitLimit : 100f;

            SchemeDetail.EvaluationStartDate = _startTime;
            SchemeDetail.EvaluationEndDate = _endTime;
            SchemeDetail.EvaluationStocks = _selectAllStock ? new ObservableCollection<Stock>(_allStock) : _selectedStocks;
            SchemeDetail.EvaluationIndicators = _configedIndicators;

            await UserSession.AddOrModifyScheme(SchemeDetail);
        }

        private RelayCommand _delelteScheme;

        /// <summary>
        /// Gets the 删除方案.
        /// </summary>
        public RelayCommand 删除方案
        {
            get
            {
                return _delelteScheme
                    ?? (_delelteScheme = new RelayCommand(Execute删除方案));
            }
        }

        protected async void Execute删除方案()
        {
            await UserSession.DeleteScheme(SchemeDetail);
        }

        #endregion
    }
}