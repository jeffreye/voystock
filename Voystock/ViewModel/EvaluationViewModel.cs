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
	public class EvaluationViewModel : CreateSchemeViewModel
	{
		/// <summary>
		/// Initializes a new instance of the EvaluationPage class.
		/// </summary>
		public EvaluationViewModel()
		{

		}

        #region 评测进度

        /// <summary>
        /// The <see cref="Evaluation" /> property's name.
        /// </summary>
        public const string EvaluationPropertyName = "Evaluation";

        private EvaluationResult _evaluation = null;

        /// <summary>
        /// Sets and gets the Evaluation property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public EvaluationResult Evaluation
        {
            get
            {
                return _evaluation;
            }
            set
            {
                Set(EvaluationPropertyName, ref _evaluation, value);

                评测进度 = (int)Math.Floor(value.Progress * 100f);
                评测结束 = value.Done;

                胜率 = (int)Math.Floor(value.WinRate * 100f);
                年化收益率 = value.AnnualizedReturn;
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

		private int _winRate = 50;

		/// <summary>
		/// Sets and gets the 胜率 property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int 胜率
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


        /// <summary>
        /// The <see cref="评测进度" /> property's name.
        /// </summary>
        public const string 评测进度PropertyName = "评测进度";

        private int _evaluationProgress = 0;

        /// <summary>
        /// Sets and gets the 评测进度 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int 评测进度
        {
            get
            {
                return _evaluationProgress;
            }
            set
            {
                Set(评测进度PropertyName, ref _evaluationProgress, value);
            }
        }

        #endregion

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
						if (System.IO.File.Exists("交易详情.xlsx"))
						{
							System.Diagnostics.Process.Start("交易详情.xlsx");
						}

					}));
			}
		}

		private RelayCommand _start;

		/// <summary>
		/// Gets the 开始评测.
		/// </summary>
		public RelayCommand 开始评测
		{
			get
			{
				return _start
					?? (_start = new RelayCommand(Evaluate));
			}
		}

        public async void Evaluate()
        {
            评测结束 = false;
            if (!IsCreated)
            {
                await AddOrCreateScheme();
            }
            await UserSession.Evaluate(SchemeDetail);
            while (!评测结束)
            {
                await Task.Delay(1000);
                Evaluation = await UserSession.GetEvaluationResult(SchemeDetail);
            }
        }
	}
}