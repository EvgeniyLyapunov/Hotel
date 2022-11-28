using Hotel.Models;
using Hotel.Services;
using Hotel.Views;
using Hotel.Views.UserControls;
using PropertyChanged;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SelectHotelsViewModel
    {
        DataBaseContext context;
        public SelectHotelsViewModel()
        {
            context = new DataBaseContext();
            builder = new StringBuilder();

            CitysDb = new List<City>();
            HotelsDb = new List<Hotels>();
            RoomsDb = new List<Room>();
            CitysComboBox = new ObservableCollection<string>();
            HotelsComboBox = new ObservableCollection<string>();
            RoomsComboBox = new ObservableCollection<string>();
            idRoomsDict = new Dictionary<string, int>();

            CitysDb = context.Citys.ToList();
            HotelsDb = context.Hotels.ToList();
            RoomsDb = context.Rooms.ToList();

            MainWindowVM = Locator.Current.GetService<MainWindowViewModel>();
            IsVisible = "Hidden";
        }

        // Команда открывает окно выбора отеля
        private RelayCommand selectVisibleCommand;
        public RelayCommand SelectVisibleCommand
        {
            get
            {
                return selectVisibleCommand ??
                    (selectVisibleCommand = new RelayCommand(obj =>
                    {
                        foreach (var city in CitysDb)
                        {
                            CitysComboBox.Add(city.CityName);
                        }
                        if (IsVisible == "Hidden")
                        {
                            ElementsVisible.IsMainScreenHidden();
                            IsVisible = "Visible";
                        }

                    }));
            }
        }

        // Команда зарывает окно выбора отеля
        private RelayCommand closeSelectViewCommand;
        public RelayCommand CloseSelectViewCommand
        {
            get
            {
                return closeSelectViewCommand ??
                    (closeSelectViewCommand = new RelayCommand(obj =>
                    {
                        CitysComboBox.Clear();
                        HotelsComboBox.Clear();
                        RoomsComboBox.Clear();
                        FinalUserSelectInfo = "";
                        if (IsVisible == "Visible")
                        {
                            ElementsVisible.IsMainScreenHidden();
                            MainWindowVM.IsMainPictureVisible = "Visible";
                        }
                            
                    }));
            }
        }



        public string IsVisible { get; set; }

        // выбор города
        public List<City> CitysDb { get; set; }
        public ObservableCollection<string> CitysComboBox { get; set; }

        private string citysComboBoxSelectedItem;
        public string CitysComboBoxSelectedItem
        {
            get
            {
                return citysComboBoxSelectedItem;
            }
            set
            {
                HotelsComboBox.Clear();
                RoomsComboBox.Clear();

                int id = 1;
                foreach (var city in CitysDb)
                {
                    if (city.CityName == value)
                    {
                        id = city.Id;
                        selectedCity = city;
                    }
                }
                HotelsComboBox.Clear();
                foreach (var item in HotelsDb)
                {
                    if (item.CityId == id)
                    {
                        HotelsComboBox.Add(item.HotelName);
                    }

                }
                citysComboBoxSelectedItem = value;
            }
        }
        public City selectedCity { get; set; }

        // выбор отеля
        public List<Hotels> HotelsDb { get; set; }
        public ObservableCollection<string> HotelsComboBox { get; set; }
        private string hotelsComboBoxSelectedItem;
        public string HotelsComboBoxSelectedItem
        {
            get
            {
                return hotelsComboBoxSelectedItem;
            }

            set
            {
                RoomsComboBox.Clear();
                int id = 1;
                foreach (var item in HotelsDb)
                {
                    if (item.HotelName == value)
                    {
                        id = item.Id;
                        selectedHotel = item;
                    }
                }
                RoomsComboBox.Clear();
                idRoomsDict.Clear();
                foreach (var item in RoomsDb)
                {
                    if (item.HotelId == id)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(item.Type);
                        sb.Append(", ");
                        sb.Append(item.Prise.ToString());
                        sb.Append(", ");
                        if (item.IsFree)
                        {
                            sb.Append("Свободен");
                        }
                        else
                        {
                            sb.Append("Занят");
                        }
                        idRoomsDict.Add(sb.ToString(), item.Id);
                        RoomsComboBox.Add(sb.ToString());
                    }
                }
                hotelsComboBoxSelectedItem = value;
            }
        }
        public Hotels selectedHotel { get; set; }

        // выбор номера
        public List<Room> RoomsDb { get; set; }
        public ObservableCollection<string> RoomsComboBox { get; set; }
        private string roomsComboBoxSelectedItem;
        public string RoomsComboBoxSelectedItem
        {
            get
            {
                return roomsComboBoxSelectedItem;
            }

            set
            {
                builder.Clear();
                int id = 0;
                foreach(var item in idRoomsDict)
                {
                    if(item.Key == value)
                    {
                        id = item.Value;
                    }
                }
                foreach(var item in RoomsDb)
                {
                    if(item.Id == id) 
                    {
                        selectedRoom = item;
                    }
                }
               
                roomsComboBoxSelectedItem = value;
                if(!String.IsNullOrEmpty(citysComboBoxSelectedItem))
                {
                    builder.Append(citysComboBoxSelectedItem.ToString());
                    builder.Append(", ");
                }
                if(!String.IsNullOrEmpty(hotelsComboBoxSelectedItem)) 
                {
                    builder.Append(hotelsComboBoxSelectedItem.ToString());
                    builder.Append(", ");
                }
                if(!String.IsNullOrEmpty(roomsComboBoxSelectedItem))
                {
                    builder.Append(roomsComboBoxSelectedItem.ToString());
                }

                if(builder.ToString().Contains("Занят"))
                {
                    FinalUserSelectInfo = "Этот номер занят, пожалуйста, выберите другой";
                    ColorFinalSelectText = "red";
                }
                else
                {
                    FinalUserSelectInfo = builder.ToString();
                    ColorFinalSelectText = "black";
                }
                
            }
        }
        public Dictionary<string, int> idRoomsDict { get; set; }
        public Room selectedRoom { get; set; }

        // строка информации о выборе пользователя
        public string FinalUserSelectInfo { get; set; }
        StringBuilder builder;
        public string ColorFinalSelectText { get; set; } = "black";


        public MainWindowViewModel MainWindowVM { get; set; }

        // команда, открывающая окно "заказать номер" и передающая в OrderUserViewModel объекты выбора пользователя
        private RelayCommand orderVisibleCommand;
        public RelayCommand OrderVisibleCommand
        { 
            get
            {
                return orderVisibleCommand ??
                    (orderVisibleCommand = new RelayCommand(obj =>
                    {
                        var orderVM = Locator.Current.GetService<OrderViewModel>();
                        if (orderVM.IsOrderVisible == "Hidden") 
                        {
                            ElementsVisible.IsMainScreenHidden();
                            orderVM.IsOrderVisible = "Visible";
                        }
                    }));
            }
        }




    }
}
