using Hotel.Models;
using PropertyChanged;
using Splat;

namespace Hotel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel
    {

        public MainWindowViewModel()
        {
            Locator.CurrentMutable.RegisterConstant(this);
            IsMainTitleVisible = "Visible";
            IsMainPictureVisible = "Visible";

            AuthUser = new User();

            LoginVM = new LoginViewModel();
            SelectHotelsVM = new SelectHotelsViewModel();
            OrderVM = new OrderViewModel();
            CheckVM = new CheckViewModel();

        }

        public LoginViewModel LoginVM { get; set; }
        public SelectHotelsViewModel SelectHotelsVM { get; set; }
        public OrderViewModel OrderVM { get; set; }
        public CheckViewModel CheckVM { get; set; }


        public string IsMainTitleVisible { get; set; }
        public string IsMainPictureVisible { get; set; }

        // поля отображения титульного названия проекта и ФИО вошедшего пользователя
        public User AuthUser { get; set; }
        public string FirstLine { get; set; } = "Wpf Client";
        public string MiddleLine { get; set; } = "of project";
        public string LastLine { get; set; } = "\"Hotel\"";
        public string InfoAboutSucces { get; set; } = "";
    }
}
