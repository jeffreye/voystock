using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Voystock.Communication;
using System.Linq;

namespace Voystock.ViewModel
{
	/// <summary>
	/// This class contains properties that a View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class SelectSchemeViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the LearningViewModel class.
		/// </summary>
		public SelectSchemeViewModel()
        {
            UserSession.AllSchemesChanged += UserSession_AllSchemesChanged;
        }

        private void UserSession_AllSchemesChanged(object sender, EventArgs e)
        {
            _schemes.Clear();
            foreach (var item in UserSession.AllSchemes)
            {
                _schemes.Add(item.Name);
            }

            if (!_schemes.Contains(_schemeName))
            {
                方案名称 = _schemes.FirstOrDefault() ?? string.Empty;
            }
        }

        /// <summary>
        /// The <see cref="方案详情" /> property's name.
        /// </summary>
        public const string 方案详情PropertyName = "方案详情";

        private Scheme _schemeDetail = null;

        /// <summary>
        /// Sets and gets the 方案详情 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Scheme 方案详情
        {
            get
            {
                return _schemeDetail;
            }
            set
            {
                Set(方案详情PropertyName, ref _schemeDetail, value);

                方案名称 = value.Name;
                _configedIndicators.Clear();
                foreach (var item in value.EvaluationIndicators)
                {
                    _configedIndicators.Add(item);
                }

                已学习参数 = value.LearningIndicators;
            }
        }


        /// <summary>
        /// The <see cref="方案名称" /> property's name.
        /// </summary>
        public const string 方案名称PropertyName = "方案名称";

		private string _schemeName = "MACD(10,20,5)";

		/// <summary>
        /// 选中的方案名称
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
				if (_schemeName == value || !_schemes.Contains(_schemeName))
				{
					return;
				}

				_schemeName = value;
				RaisePropertyChanged(方案名称PropertyName);
                方案详情 = UserSession.AllSchemes[value];
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

            //private set
            //{
            //    if (_schemes == value)
            //    {
            //        return;
            //    }

            //    _schemes = value;
            //    RaisePropertyChanged(所有方案列表PropertyName);
            //}
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

        /// <summary>
        /// The <see cref="已学习参数PropertyName" /> property's name.
        /// </summary>
        public const string 已学习参数PropertyName = "已学习参数";

        private LearningResult _learnedParameters = new LearningResult();

        /// <summary>
        /// Sets and gets the 已学习参数 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LearningResult 已学习参数
		{
			get
			{
				return _learnedParameters;
			}
            private set
            {
				Set(已学习参数PropertyName, ref _learnedParameters, value);
			}
		}
	}
}