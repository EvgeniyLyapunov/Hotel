using Hotel.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class ElementsVisible
    {
        /// <summary>
        /// Метод закрывает все Юзер Контролы
        /// </summary>
        public static void IsMainScreenHidden()
        {
            var MainWindowVM = Locator.Current.GetService<MainWindowViewModel>();

            MainWindowVM.IsMainPictureVisible = "Hidden";

            MainWindowVM.LoginVM.IsLoginViewVisible = "Hidden";
            MainWindowVM.SelectHotelsVM.IsVisible = "Hidden";
            MainWindowVM.OrderVM.IsOrderVisible = "Hidden";
        }

        /// <summary>
        /// Метод выводит заставку и название приложения
        /// </summary>
        public static void IsMainScreenVisible()
        {
            var MainWindowVM = Locator.Current.GetService<MainWindowViewModel>();

            MainWindowVM.IsMainPictureVisible = "Visible";
        }
    }
}
