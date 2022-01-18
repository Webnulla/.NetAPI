using Dapper;
using MetricsAgent.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public interface IDotNetMetricsReposiroty : IRepository<DotNetMetrics>
    {

    }
    public class DotNetMetricsReposiroty : IDotNetMetricsReposiroty
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100";
        //инжектируем соединение с БД в наш репозиторий через конструктор

        public DotNetMetricsReposiroty()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(DotNetMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM dotnetmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public void Update(DotNetMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE dotnetmetrics SET value=@value, time=@time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }
        public IList<DotNetMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var dotnetMetrics = connection.Query<DotNetMetrics>("SELECT Id, Time, Value FROM dotnetmetrics").ToList();
                return dotnetMetrics;
            }
        }
        public DotNetMetrics GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var dotnetMetrics = connection.QuerySingle<DotNetMetrics>("SELECT Id, Time, Value FROM dotnetmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });

                return dotnetMetrics;
            }
        }
    }
}

