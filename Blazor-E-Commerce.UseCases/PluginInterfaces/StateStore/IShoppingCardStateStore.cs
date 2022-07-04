using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore
{
    public interface IShoppingCardStateStore:IStateStore
    {
        Task<int> GetItemsCount();
        void UpdateLineItemsCount();
    }
}
