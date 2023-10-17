using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using bimbam537.ViewModels;
using Microsoft.CodeAnalysis.Scripting.Hosting;
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

    public List<Request> GetRequests()
    {
        List<ResponsiblesForRequest> rfr = GetResponsiblesForRequest();
        List<Request> requests = new List<Request>();
        string query = "select * from `Cоздание заявки` join Тип_неисправности Тн on `Cоздание заявки`.Неисправность = Тн.id join Статус_заявки Сз on Статус_Заявки = Сз.id";
        MySqlCommand command = new MySqlCommand(query, connection);
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            //MySqlCommand mCommand = new MySqlCommand("select * from Ответственный_За_Заявку where ID_заявки = @id;", connection);
            //mCommand.Parameters.AddWithValue("@id", id);
            //List<Responsible> rs = new List<Responsible>();
            //MySqlDataReader mReader = mCommand.ExecuteReader();
            //while (mReader.Read())
            //{
            //    rs.Add();
            //}
            List<ResponsiblesForRequest> crfr = rfr.Where(x => x.requestId == id).ToList();
            List<string> rf = new List<string>();
            foreach (var item in crfr)
            {
                rf.Add(MainWindowViewModel.responsibles.Where(x => x.id == item.id).Select(x => x.name).First());
            }
            DateTime time = reader.GetDateTime(1);
            string equip = reader.GetString(2);
            string defect = reader.GetString(8);
            string problemDesc = reader.GetString(4);
            string client = reader.GetString(5);
            string status = reader.GetString(10);
            requests.Add(new Request(id, time, equip, defect, problemDesc, client, status, rf));
        }

        connection.Close();
        return requests;
    }
    
    
    public List<Responsible> GetResponsibles()
    {
        List<Responsible> resps = new List<Responsible>();
        string query = "select * from ответственный";
        MySqlCommand command = new MySqlCommand(query, connection);
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            resps.Add(new Responsible(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
        }

        connection.Close();
        
        return resps;
    }

    public List<Status> GetStatuses()
    {
        List<Status> stats = new List<Status>();
        string query = "select * from Статус_заявки";
        MySqlCommand command = new MySqlCommand(query, connection);
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            stats.Add(new Status(reader.GetInt32(0), reader.GetString(1)));
        }
        
        connection.Close();

        return stats;
    }
    
    public List<Defect> GetDefects()
    {
        List<Defect> defects = new List<Defect>();
        string query = "select * from Тип_неисправности";
        MySqlCommand command = new MySqlCommand(query, connection);
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            defects.Add(new Defect(reader.GetInt32(0), reader.GetString(1)));
        }

        connection.Close();
        
        return defects;
    }

    public List<ResponsiblesForRequest> GetResponsiblesForRequest()
    {
        List<ResponsiblesForRequest> resps = new List<ResponsiblesForRequest>();
        string query = "select * from Ответственный_За_Заявку";
        MySqlCommand command = new MySqlCommand(query, connection);
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            resps.Add(new ResponsiblesForRequest(reader.GetInt32(0), reader.GetInt32(2), reader.GetInt32(1)));
        }

        connection.Close();
        
        return resps;
    }
}