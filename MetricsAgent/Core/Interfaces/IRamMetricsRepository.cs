using Dapper;
using MetricsAgent.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public interface IRamMetricsRepository : IRepository<RamMetrics>
    {
    }

    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100";
        //инжектируем соединение с БД в наш репозиторий через конструктор

        public RamMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(RamMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public void Update(RamMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE rammetrics SET value=@value, time=@time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }

        public IList<RamMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var ramMetrics = connection.Query<RamMetrics>("SELECT Id, Time, Value FROM rammetrics").ToList();
                return ramMetrics;
            }
        }

        public RamMetrics GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var ramMetrics = connection.QuerySingle<RamMetrics>(
                    "SELECT Id, Time, Value FROM rammetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });

                return ramMetrics;
            }
        }
    }
}