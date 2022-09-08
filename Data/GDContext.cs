using System.Data.SqlClient;

namespace GDBank.Data;

public class GDContext
{
    public SqlConnection connection;

    public GDContext()
    {
        connection = new SqlConnection(ConString.ConnectionString);
    }

    private async Task Connect()
    {
        await Task.Run(() => connection.OpenAsync());
    }

    private async Task Disconnect()
    {
        await Task.Run(() => connection.CloseAsync());
    }
}
