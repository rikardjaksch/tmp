using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_windsor.Views
{
    public interface IView
    {
        void Show();
        bool? ShowDialog();
    }
}
