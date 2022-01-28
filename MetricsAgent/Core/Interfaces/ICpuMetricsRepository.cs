using Dapper;
using MetricsAgent.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public interface ICpuMetricsRepository : IRepository<CpuMetrics>
    {

    }
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100";
        //инжектируем соединение с БД в наш репозиторий через конструктор

        public CpuMetricsRepository()
        {
            //парсилка типа TimeSpan в качестве подсказки для SQLite
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(CpuMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                //запрос на вставку данных с плейсхолдерами для параметров
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                    //анонимный объект с параметрами запроса
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
                connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public void Update(CpuMetrics item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE cpumetrics SET value=@value, time=@time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }
        public IList<CpuMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                //читаем при помощи Query и в шаблон подставляем тип данных объектов которого Даппер
                //сам и заполнит его поля в соответствии с названиями колонок
                var cpuMetrics = connection.Query<CpuMetrics>("SELECT Id, Time, Value FROM cpumetrics").ToList();
                return cpuMetrics;
            }
        }
        public CpuMetrics GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var cpuMetrics = connection.QuerySingle<CpuMetrics>("SELECT Id, Time, Value FROM cpumetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });

                return cpuMetrics;
            }
        }
    }
}
