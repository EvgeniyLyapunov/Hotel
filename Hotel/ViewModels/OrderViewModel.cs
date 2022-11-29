using Hotel.Models;
using Hotel.Services;
using PropertyChanged;
using Splat;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderViewModel
    {
        DataBaseContext context;
        public OrderViewModel()
        {
            context = new DataBaseContext();

            Locator.CurrentMutable.RegisterConstant(this);
            MainWindowVM = Locator.Current.GetService<MainWindowViewModel>();
            CurrentDate = DateTime.Now.ToLongDateString();

            IsOrderVisible = "Hidden";
        }

        // команда валидирует ввод пользователя, рассчитывает стоимость и выводит результат на экран
        private RelayCommand costСalculationCommand;
        public RelayCommand CostCalculationCommand
        {
            get
            {
                return costСalculationCommand ??
                    (costСalculationCommand = new RelayCommand(obj =>
                    {
                        InputNightsColorText = "black";
                        InputPeoplesColorText = "black";
                        if (String.IsNullOrEmpty(InputNights))
                        {
                            InputNightsColorText = "red";
                            MessageBox.Show($"Не указанно количество ночей.", "Is user a deer?", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (String.IsNullOrEmpty(InputPeoples))
                        {
                            InputPeoplesColorText = "red";
                            MessageBox.Show($"Не указанно количество въезжающих.", "Is user a deer?", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }


                        

                        if(!int.TryParse(InputNights, out nights)) 
                        {
                            InputNightsColorText = "red";
                            MessageBox.Show($"{InputNights} - не число", "Is user a deer?", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (!int.TryParse(InputPeoples, out peoples))
                        {
                            InputPeoplesColorText = "red";
                            MessageBox.Show($"{InputPeoples} - не число", "Is user a deer?", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if(nights > 100 || nights < 0 )
                        {
                            InputNightsColorText = "red";
                            MessageBox.Show($"{nights} - срок проживания не должен превышать 100 дней", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if(peoples > roomSelected.BedNum + 2)
                        {
                            InputPeoplesColorText = "red";
                            MessageBox.Show($"{peoples} - это больше допустимого числа въезжающих в этот номер. Максимальное количество - {roomSelected.BedNum + 2}", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        decimal coefficient = 1;
                        if(peoples < roomSelected.BedNum)
                        {
                            coefficient = 0.8M;
                        }
                        else if(peoples > roomSelected.BedNum)
                        {
                            coefficient = 1.5M;
                        }
                        theTotalCost =  nights * (roomSelected.Prise * coefficient);

                        theTotalCostInfo = $"К оплате: {theTotalCost} р.";

                    }));
            }
        }

        // команда обнуляет все данные и выходит на главный экран
        private RelayCommand canselCommand;
        public RelayCommand CanselCommand
        {
            get
            {
                return canselCommand ??
                    (canselCommand = new RelayCommand(obj =>
                    {
                        sitySelected = null;
                        hotelSelected = null;
                        roomSelected = null;
                        InputNights = "";
                        InputPeoples = "";
                        InputNightsColorText = "black";
                        InputPeoplesColorText = "black";
                        nights = 0;
                        peoples = 0;
                        theTotalCost = 0;
                        theTotalCostInfo = "";

                        ElementsVisible.IsMainScreenHidden();
                        ElementsVisible.IsMainScreenVisible();

                    }));
            }
        }

        // команда создаёт чек оплаты, сохраняет его в бд,
        // меняет в бд поле комнаты на занята, обнуляет все данные и выходит на главный экран
        private RelayCommand paymantCommand;
        public RelayCommand PaymantCommand
        {
            get
            {
                return paymantCommand ??
                    (paymantCommand = new RelayCommand(obj =>
                    {
                        if(theTotalCost == 0)
                        {
                            MessageBox.Show("Пожалуйста, расчитайте стоимость", "Is user a deer?", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        Check check = new Check();
                        check.UserId = MainWindowVM.AuthUser.Id;
                        check.UserName = $"{MainWindowVM.AuthUser.LastName} {MainWindowVM.AuthUser.FirstName.Substring(0,1).ToUpper()}.{MainWindowVM.AuthUser.MiddleName.Substring(0, 1).ToUpper()}.";
                        check.DateOfPayment = $"{DateTime.Now.ToLongDateString()}";
                        check.City = sitySelected.CityName;
                        check.HotelName = hotelSelected.HotelName;
                        check.RoomType = roomSelected.Type;
                        check.People = peoples;
                        check.Nights = nights;
                        check.AmountPayment = (int)theTotalCost;

                        var del = context.Checks.ToList();
                        if(del.Count > 0 ) 
                        {
                            context.Checks.Remove(del[0]);
                        }

                        context.Checks.Add(check);
                        context.SaveChanges();

                        Room room = context.Rooms.FirstOrDefault(r => r.Id == roomSelected.Id);
                        room.IsFree = false;

                        context.SaveChanges();

                        MainWindowVM.SelectHotelsVM.RoomsDb = context.Rooms.ToList();
                        MainWindowVM.InfoAboutSucces = $"{MainWindowVM.AuthUser.FirstName} {MainWindowVM.AuthUser.MiddleName}, Ваш заказ успешно оплачен. Для получения чека - пункт меню Распечатать чек";

                        CanselCommand.Execute(this);
                    }));
            }
        }

        public string IsOrderVisible { get; set; }

        public string CurrentDate { get; set; }
        public City sitySelected { get; set; }
        public Hotels hotelSelected { get; set; }
        public Room roomSelected { get; set; }

        public string InputNights { get; set; }
        public string InputNightsColorText { get; set; } = "black";
        public string InputPeoples { get; set; }
        public string InputPeoplesColorText { get; set; } = "black";

        int nights = 0;
        int peoples = 0;
        decimal theTotalCost = 0;
        public string theTotalCostInfo { get; set; }

        MainWindowViewModel MainWindowVM { get; set; }





    }

}
