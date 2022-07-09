namespace Blazor_E_Commerce.DataStore.SQL.Dapper.Helpers.Interface
{
    public interface IDataAccess
    {
        void ExecuteCommand<T>(string sql, T parameter);
        List<T> Query<T, U>(string sql, U parameter);
        T QuerySingle<T, U>(string sql, U parameter);
    }
}