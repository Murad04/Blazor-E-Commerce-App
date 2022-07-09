using Dapper;
using System.Data;
using System.Data.SqlClient;

var connectStr = "Data Source=DESKTOP-8UQUVJ2;Initial Catalog=Blazor_E_Commmerce_App;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
using (IDbConnection connection=new SqlConnection(connectStr))
{
    var results = connection.Query("SELECT *FROM Product");
}