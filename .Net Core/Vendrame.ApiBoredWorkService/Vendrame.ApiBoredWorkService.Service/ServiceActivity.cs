using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.ApiBoredWorkService.Data;
using Vendrame.ApiBoredWorkService.Model;

namespace Vendrame.ApiBoredWorkService.Service
{
    public class ServiceActivity : IServiceActivity
    {
        private readonly IActivityData _activityData;

        public ServiceActivity(IActivityData activityData)
        {
            _activityData = activityData;
        }

        public IEnumerable<Activity> getActivity()
        {
            return _activityData.GetAll();       
        }

        public void InsertActivity(Activity a)
        {
            _activityData.Insert(a);
        }
    }
}
