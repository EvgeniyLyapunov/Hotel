using Hotel.Models;
using Hotel.Services;
using PropertyChanged;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CheckViewModel
    {
        DataBaseContext context;
        public CheckViewModel()
        {
            context = new DataBaseContext();
            MainWindowVM = Locator.Current.GetService<MainWindowViewModel>();

            IsCheckVisible = "Hidden";
        }

        // команда открывает окно показа чека
        private RelayCommand viewCheckCommand;
        public RelayCommand ViewCheckCommand
        {
            get
            {
                return viewCheckCommand ??
                    (viewCheckCommand = new RelayCommand(obj =>
                    {
                        if(MainWindowVM.InfoAboutSucces == "")
                        {
                            MessageBox.Show("Вы либо уже получили чек, либо ещё ничего не оплатили, ведь так?", "Is user a deer?", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        Check check = context.Checks.ToList()[0];

                        UserName = check.UserName;
                        CheckDate = check.DateOfPayment;
                        CityName = check.City;
                        HotelName = check.HotelName;
                        RoomType = check.RoomType;
                        PeopleCount = check.People.ToString();
                        NightsCount= check.Nights.ToString();
                        PaymantAmount = check.AmountPayment.ToString();

                        if(IsCheckVisible == "Hidden")
                        {
                            MainWindowVM.IsMainTitleVisible = "Hidden";
                            IsCheckVisible = "Visible";
                        }
                    }));
            }
        }

        // команда закрывает окно показа чека и сбрасывает все значения, повторно чек посмотреть нельзя(в текущей реализации)
        private RelayCommand closeViewCheckCommand;
        public RelayCommand CloseViewCheckCommand
        {
            get
            {
                return closeViewCheckCommand ??
                    (closeViewCheckCommand = new RelayCommand(obj =>
                    {
                        UserName = "";
                        CheckDate = "";
                        CityName = "";
                        HotelName = "";
                        RoomType = "";
                        PeopleCount = "";
                        NightsCount = "";
                        PaymantAmount = "";

                        MainWindowVM.InfoAboutSucces = "";

                        if (IsCheckVisible == "Visible")
                        {
                            MainWindowVM.IsMainTitleVisible = "Visible";
                            IsCheckVisible = "Hidden";
                        }
                    }));
            }
        }

        public string UserName { get; set; }
        public string CheckDate { get; set; }
        public string CityName { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public string PeopleCount { get; set; }
        public string NightsCount { get; set; }
        public string PaymantAmount { get; set; }


        public string IsCheckVisible { get; set; }
        public MainWindowViewModel MainWindowVM { get; set; }
    }
}
