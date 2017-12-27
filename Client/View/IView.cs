using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.View
{
    interface IView
    {
        void updateView(String json, String type);
        void error(String error);
    }
}
