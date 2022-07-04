using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListeners(Action listener);
        void RemoveStateChangeListeners(Action listener);
        void BroadCastStateChange();
    }
}
