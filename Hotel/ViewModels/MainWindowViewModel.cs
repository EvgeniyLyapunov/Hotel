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

            LoginVM = new LoginViewModel();
            SelectHotelsVM = new SelectHotelsViewModel();
            OrderVM = new OrderViewModel();

        }

        public LoginViewModel LoginVM { get; set; }
        public SelectHotelsViewModel SelectHotelsVM { get; set; }
        public OrderViewModel OrderVM { get; set; }


        public string IsMainTitleVisible { get; set; }
        public string IsMainPictureVisible { get; set; }
    }
}
