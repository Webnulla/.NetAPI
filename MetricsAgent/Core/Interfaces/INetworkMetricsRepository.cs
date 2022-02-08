using Dapper;
using MetricsAgent.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public interface INetworkMetricsRepository : IRepository<NetworkMetrics>
    {
    }

    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100";
        //инжектируем соединение с БД в наш репозиторий через конструктор

        public NetworkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(NetworkMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds
                    });
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public void Update(NetworkMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE networkmetrics SET value=@value, time=@time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }

        public IList<NetworkMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var networkMetrics = connection.Query<NetworkMetrics>("SELECT Id, Time, Value FROM networkmetrics")
                    .ToList();
                return networkMetrics;
            }
        }

        public NetworkMetrics GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var networkMetrics = connection.QuerySingle<NetworkMetrics>(
                    "SELECT Id, Time, Value FROM networkmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });

                return networkMetrics;
            }
        }
    }
}