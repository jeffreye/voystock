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

            方案详情 = UserSession.AllSchemes.FirstOrDefault() ?? new Scheme();
        }

        #region 选择方案

        /// <summary>
        /// The <see cref="选中的方案名称" /> property's name.
        /// </summary>
        public const string 选中的方案名称PropertyName = "选中的方案名称";

		private string _schemeName = "MACD(10,20,5)";

		/// <summary>
        /// 选中的方案名称
		/// Sets and gets the 方案名称 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string 选中的方案名称
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
				RaisePropertyChanged(选中的方案名称PropertyName);
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

        #endregion

        /// <summary>
        /// The <see cref="方案详情" /> property's name.
        /// </summary>
        public const string 方案详情PropertyName = "方案详情";

        protected Scheme SchemeDetail = new Scheme();

        /// <summary>
        /// Sets and gets the 方案详情 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Scheme 方案详情
        {
            get
            {
                return SchemeDetail;
            }
            set
            {
                Set(方案详情PropertyName, ref SchemeDetail, value);

                选中的方案名称 = value.Name;
            }
        }

        #region 方案编辑
        
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