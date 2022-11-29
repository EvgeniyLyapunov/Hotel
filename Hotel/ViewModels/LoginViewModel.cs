using Hotel.Models;
using Hotel.Services;
using Hotel.Views.UserControls;
using PropertyChanged;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        DataBaseContext context;
        public LoginViewModel()
        {
            context= new DataBaseContext();
            IsLoginViewVisible = "Hidden";
            MainWindowVM = Locator.Current.GetService<MainWindowViewModel>();

            UserList = new List<User>();

            FirstName = "";
            LastName = "";
            MiddleName = "";

        }

        // Команда открывает окно авторизации
        private RelayCommand loginViewVisibleCommand;
        public RelayCommand LoginViewVisibleCommand
        {
            get
            {
                return loginViewVisibleCommand ??
                   (loginViewVisibleCommand = new RelayCommand(obj =>
                   {
                       if (IsLoginViewVisible == "Hidden")
                       {
                          IsLoginViewVisible = "Visible";
                          MainWindowVM.IsMainTitleVisible = "Hidden";
                       }
                   }));
            }
        }

        // Команда сохраняет введённые пользователем данные в базе данных
        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                    (loginCommand = new RelayCommand(obj =>
                    {
                        loginUC = Locator.Current.GetService<LoginUserControl>();

                        User user = new User();
                        if(!String.IsNullOrEmpty(LastName) && !String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(MiddleName))
                        {
                            ColorLastText = "black";
                            ColorFirstText = "black";
                            ColorMiddleText = "black";
                            user.LastName = LastName;
                            user.FirstName = FirstName;
                            user.MiddleName = MiddleName;

                            try
                            {
                                //UserList = context.Users.ToList();

                                UserList = context.Users.Where(u => u.LastName == LastName &&
                                                                    u.FirstName == FirstName &&
                                                                    u.MiddleName == MiddleName).ToList();

                                if (UserList.Count == 0)
                                {
                                    context.Users.Add(user);
                                    context.SaveChanges();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Что то пошло не так с запросом в базу данных.");
                            }

                            MessageBox.Show($"Вы вошли как {user.LastName} {user.FirstName} {user.MiddleName}", "Вход выполнен", MessageBoxButton.OK, MessageBoxImage.Information);

                            MainWindowVM.AuthUser = context.Users.FirstOrDefault(u => u.FirstName == user.FirstName &&
                                                                                      u.LastName == user.LastName &&
                                                                                      u.MiddleName == user.MiddleName);
                            MainWindowVM.LastLine = user.LastName;
                            MainWindowVM.FirstLine = user.FirstName;
                            MainWindowVM.MiddleLine = user.MiddleName;

                            user = null;

                            LoginViewCloseCommand.Execute(this);
                        } 
                        else
                        {
                            _ = String.IsNullOrEmpty(LastName) ? ColorLastText = "red" : ColorLastText = "black";
                            _ = String.IsNullOrEmpty(FirstName) ? ColorFirstText = "red" : ColorFirstText = "black";
                            _ = String.IsNullOrEmpty(MiddleName) ? ColorMiddleText = "red" : ColorMiddleText = "black";
                            return;
                        }
                    }));
            }
        }

        // Команда закрывает окно авторизации
        private RelayCommand loginViewCloseCommand;
        public RelayCommand LoginViewCloseCommand
        {
            get
            {
                return loginViewCloseCommand ??
                   (loginViewCloseCommand = new RelayCommand(obj =>
                   {
                       if (IsLoginViewVisible == "Visible")
                       {
                           IsLoginViewVisible = "Hidden";
                           MainWindowVM.IsMainTitleVisible = "Visible";
                           ColorLastText = "black";
                           ColorFirstText = "black";
                           ColorMiddleText = "black";
                           LastName = "";
                           FirstName = "";
                           MiddleName = "";
                       }
                   }));
            }
        }


        public string IsLoginViewVisible { get; set; }
        public MainWindowViewModel MainWindowVM { get; set; }
        public LoginUserControl loginUC { get; set; }

        public List<User> UserList { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set;}

        public string ColorLastText { get; set; } = "black";
        public string ColorFirstText { get; set; } = "black";
        public string ColorMiddleText { get; set; } = "black";

    }
}
