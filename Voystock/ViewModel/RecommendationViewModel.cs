using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
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
	public class RecommendationViewModel : SelectSchemeViewModel
	{
		/// <summary>
		/// Initializes a new instance of the RecommendationViewModel class.
		/// </summary>
		public RecommendationViewModel()
		{
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
					?? (_start = new RelayCommand(Recommend));
			}
		}

        public async void Recommend()
        {
            await UserSession.Recommend(SchemeDetail);
        }

        private RelayCommand _getResult;

        /// <summary>
        /// Gets the 获取所有荐股结果.
        /// </summary>
        public RelayCommand 获取所有荐股结果
        {
            get
            {
                return _getResult
                    ?? (_getResult = new RelayCommand(GetAllRecommendationResults));
            }
        }

        public async void GetAllRecommendationResults()
        {
            获取荐股结果中 = true;
            荐股结果 = await UserSession.GetRecommendationResult(SchemeDetail);
            获取荐股结果中 = false;
        }

        private RelayCommand<System.DateTime> _getResultOnDate;

        /// <summary>
        /// Gets the 获得某天荐股结果.
        /// </summary>
        public RelayCommand<System.DateTime> 获得某天荐股结果
        {
            get
            {
                return _getResultOnDate
                    ?? (_getResultOnDate = new RelayCommand<System.DateTime>(GetRecommendationResultOnDate));
            }
        }

        private async void GetRecommendationResultOnDate(System.DateTime parameter)
        {
            获取荐股结果中 = true;
            荐股结果 = await UserSession.GetRecommendationResultOnDate(SchemeDetail,parameter);
            获取荐股结果中 = false;
        }

		/// <summary>
		/// The <see cref="荐股结果" /> property's name.
		/// </summary>
		public const string 荐股结果PropertyName = "荐股结果";

		private IEnumerable<RecommendationResult> _results = new RecommendationResult[]
		{
			//new RecommendationResult { Code = "002036" , Name = 	"汉麻产业"},
			//new RecommendationResult { Code = "600601" , Name = 	"方正科技"},
			//new RecommendationResult { Code = "600275" , Name = 	"武昌鱼  "},
			//new RecommendationResult { Code = "000883" , Name = 	"湖北能源"},
			//new RecommendationResult { Code = "002575" , Name = 	"群兴玩具"},
			//new RecommendationResult { Code = "601777" , Name = 	"力帆股份"},
			//new RecommendationResult { Code = "002397" , Name = 	"梦洁家纺"},
			//new RecommendationResult { Code = "600250" , Name = 	"南纺股份"},
			//new RecommendationResult { Code = "002135" , Name = 	"东南网架"},
			//new RecommendationResult { Code = "600505" , Name = 	"西昌电力"},
			//new RecommendationResult { Code = "002526" , Name = 	"山东矿机"},
			//new RecommendationResult { Code = "000066" , Name = 	"长城电脑"},
			//new RecommendationResult { Code = "002255" , Name = 	"海陆重工"},
			//new RecommendationResult { Code = "002282" , Name = 	"博深工具"},
			//new RecommendationResult { Code = "000595" , Name = 	"西北轴承"},
			//new RecommendationResult { Code = "600400" , Name = 	"红豆股份"},
			//new RecommendationResult { Code = "603126" , Name = 	"中材节能"},
			//new RecommendationResult { Code = "600190" , Name = 	"锦州港  "},
			//new RecommendationResult { Code = "002389" , Name = 	"南洋科技"},
			//new RecommendationResult { Code = "600328" , Name = 	"兰太实业"},

		};

		/// <summary>
		/// Sets and gets the 荐股结果 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public IEnumerable<RecommendationResult> 荐股结果
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

        /// <summary>
        /// The <see cref="获取荐股结果中" /> property's name.
        /// </summary>
        public const string 获取荐股结果中PropertyName = "获取荐股结果中";

        private bool _AquiringData = false;

        /// <summary>
        /// Sets and gets the 获取荐股结果中 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool 获取荐股结果中
        {
            get
            {
                return _AquiringData;
            }
            set
            {
                Set(获取荐股结果中PropertyName, ref _AquiringData, value);
            }
        }
	}
}