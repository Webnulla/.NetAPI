using MetricsAgent.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public interface IRamMetricsRepository : IRepository<RamMetrics>
    {

    }

    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100";
        //инжектируем соединение с БД в наш репозиторий через конструктор
        public void Create(RamMetrics item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            //создаем команду
            using var command = new SQLiteCommand(connection);
            //прописываем в команду SQL запрос на вставку данных
            command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(@value, @time)";
            //добавляем параметры в запрос из нашего объекта
            command.Parameters.AddWithValue("@vakue", item.Value);
            //в таблице будем хранить время в секундах, потому преобразуем перед записью в секунды
            //через свойство
            command.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            //подготовка команд к выполнению
            command.Prepare();
            //выполнение команды
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            //прописываем в команду SQL запрос на удаление данных
            command.CommandText = "DELETE FROM cpumetrics WHERE id=@id";

            command.Parameters.AddWithValue("@id", id);
            command.Prepare();
            command.ExecuteNonQuery();
        }
        public void Update(RamMetrics item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            using var command = new SQLiteCommand(connection);
            //прописываем в команду SQL запрос на обновление данных
            command.CommandText = "UPDATE cpumetrics SET value = @value, time = @time WHERE id=@id";
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@value", item.Value);
            command.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            command.Prepare();

            command.ExecuteNonQuery();
        }
        public IList<RamMetrics> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var command = new SQLiteCommand(connection);

            //прописываем в команду запрос на получение всех данных из таблицы
            command.CommandText = "SELECT * FROM cpumetrics";

            var returnList = new List<RamMetrics>();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                //пока есть что читать -- читаем
                while (reader.Read())
                {
                    returnList.Add(new RamMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        //налету преобразуем прочитанные секунды в метку времени
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2)),
                    });
                }
            }
            return returnList;
        }
        public RamMetrics GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM cpumetrics WHERE id=@id";
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                //если удалось что-то прочитать
                if (reader.Read())
                {
                    return new RamMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(1))
                    };
                }
                else
                {
                    //не нашлись записи по айди, не делаем ничего
                    return null;
                }
            }
        }
    }
}
