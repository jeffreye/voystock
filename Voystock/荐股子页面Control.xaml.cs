using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Voystock
{
    /// <summary>
    /// Interaction logic for 荐股子页面Control.xaml
    /// </summary>
    public partial class 荐股子页面Control : UserControl, INotifyPropertyChanged
    {
        public 荐股子页面Control()
        {
            InitializeComponent();
        }

        void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string PrevTab
        {
            get { return 荐股子页面.SelectedIndex <= 0 ? "" : "上一步:" + ((TabItem)荐股子页面.Items[荐股子页面.SelectedIndex - 1]).Header.ToString(); }
        }

        public string NextTab
        {
            get { return 荐股子页面.SelectedIndex >= 荐股子页面.Items.Count - 1 ? "" : "下一步:" + ((TabItem)荐股子页面.Items[荐股子页面.SelectedIndex + 1]).Header.ToString(); }
        }



        private RelayCommand _prevStep;

        /// <summary>
        /// Gets the 上一步.
        /// </summary>
        public RelayCommand 上一步
        {
            get
            {
                return _prevStep
                    ?? (_prevStep = new RelayCommand(
                    () =>
                    {
                        if (!上一步.CanExecute(null))
                        {
                            return;
                        }

                        荐股子页面.SelectedIndex--;
                    },
                    () => 荐股子页面.SelectedIndex > 0));
            }
        }

        private RelayCommand _nextStep;

        /// <summary>
        /// Gets the 下一步.
        /// </summary>
        public RelayCommand 下一步
        {
            get
            {
                return _nextStep
                    ?? (_nextStep = new RelayCommand(
                    () =>
                    {
                        if (!下一步.CanExecute(null))
                        {
                            return;
                        }

                        荐股子页面.SelectedIndex++;
                    },
                    () => 荐股子页面.SelectedIndex <= 荐股子页面.Items.Count - 2 && ((TabItem)荐股子页面.Items[荐股子页面.SelectedIndex + 1]).IsEnabled));
            }
        }

        private void 荐股子页面_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(PrevTab));
            OnPropertyChanged(nameof(NextTab));
            上一步.RaiseCanExecuteChanged();
            下一步.RaiseCanExecuteChanged();
        }
    }
}
