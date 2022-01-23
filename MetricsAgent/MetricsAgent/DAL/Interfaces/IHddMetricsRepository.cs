﻿using Dapper;
using MetricsAgent.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public interface IHddMetricsRepository : IRepository<HddMetrics>
    {

    }

    public class HddMetricsRepository : IHddMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100";
        //инжектируем соединение с БД в наш репозиторий через конструктор

        public HddMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(HddMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM hddmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public void Update(HddMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE hddmetrics SET value=@value, time=@time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }
        public IList<HddMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var hddMetrics = connection.Query<HddMetrics>("SELECT Id, Time, Value FROM hddmetrics").ToList();
                return hddMetrics;
            }
        }
        public HddMetrics GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var hddMetrics = connection.QuerySingle<HddMetrics>("SELECT Id, Time, Value FROM hddmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });

                return hddMetrics;
            }
        }
    }
}
