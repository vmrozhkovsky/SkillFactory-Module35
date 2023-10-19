using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO_Dll;

public class MainConnector
{
    SqlConnection connection;
    public async Task < bool > ConnectAsync() {
        bool result;
        // SqlConnection connection;
        try {
            connection = new SqlConnection(ConnectionString.MsSqlConnection);
            await connection.OpenAsync();
            result = true;
        } 
        catch {
            result = false;
        }

        return result;
    }
    
    // public async void DisconnectAsync() {
    //     if (connection.State == ConnectionState.Open) {
    //         await connection.CloseAsync();
    //     }
    // }
}