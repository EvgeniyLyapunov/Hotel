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
            LoginVM = new LoginViewModel();
            
        }

        public LoginViewModel LoginVM { get; set; }

        

        public string IsMainTitleVisible { get; set; }
    }
}
