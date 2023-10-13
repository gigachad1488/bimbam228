using MySql.Data.MySqlClient;

namespace bimbam537;

using MySql.Data;

public class Db
{
    private string connectionString;

    private MySqlConnection connection;

    public Db()
    {
        connection = new MySqlConnection("server=10.10.1.24;uid=user_01;pwd=user01pro;database=pro1_7");
    }
}