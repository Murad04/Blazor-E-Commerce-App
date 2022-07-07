using Blazor_E_Commerce.UseCases.PluginInterfaces.StateStore.Interface;

namespace Blazor_E_Commerce.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners = null!;

        public void AddStateChangeListeners(Action listener) => this.listeners += listener;

        public void BroadCastStateChange()
        {
            if (this.listeners != null) this.listeners.Invoke();
        }

        public void RemoveStateChangeListeners(Action listener) => this.listeners += listener;
    }
}