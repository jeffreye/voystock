using GalaSoft.MvvmLight;

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
		/// The <see cref="SchemeName" /> property's name.
		/// </summary>
		public const string SchemeNamePropertyName = "SchemeName";

		private string _schemeName = "MACD(1,2,3)";

		/// <summary>
		/// Sets and gets the SchemeName property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string SchemeName
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
				RaisePropertyChanged(SchemeNamePropertyName);
			}
		}
	}
}