using Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore.Interface;

namespace Blazor_E_Commerce.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;

        public void AddStateChangeListeners(Action listener) => this.listeners += listener;

        public void BroadCastStateChange()
        {
            throw new NotImplementedException();
        }

        public void RemoveStateChangeListeners(Action listener) => this.listeners += listener;
    }
}