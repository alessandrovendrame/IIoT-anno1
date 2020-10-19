using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.ApiBoredWorkService.Model;

namespace Vendrame.ApiBoredWorkService.Service
{
    public interface IServiceActivity
    {
        void InsertActivity(Activity a);

        IEnumerable<Activity> getActivity();
    }
}
