using PropertyChanged;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Locator.CurrentMutable.RegisterConstant(this);

            IsOrderVisible = "Hidden";
        }
        public string IsOrderVisible { get; set; }
    }

}
