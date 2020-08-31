using System;
using System.Text;
using RabbitMQ.Client;
using System.Configuration;
using System.Collections.Generic;
using RabbitMQ.Client.Events;

namespace acessos_trilha_auditoria.Mq
{
    public class RabbitMq
    {
        private readonly string _queue = ConfigurationManager.AppSettings["queueMQ"];
        private readonly string _hostName = ConfigurationManager.AppSettings["hostnameMQ"];
        private readonly string _userName = ConfigurationManager.AppSettings["usernameMQ"];
        private readonly string _password = ConfigurationManager.AppSettings["passwordMQ"];
        private readonly bool _autoRecovery = Convert.ToBoolean(ConfigurationManager.AppSettings["autoRecoveryMQ"]);
        private readonly ushort _networkRecoveryInterval = Convert.ToUInt16(ConfigurationManager.AppSettings["networkRecoveryIntervalMQ"]);
        private readonly ushort _maximumChannel = Convert.ToUInt16(ConfigurationManager.AppSettings["maximumChannelMQ"]);
        private readonly ConnectionFactory _connectionFactory = new ConnectionFactory();


        /// <returns>
        /// Uma instância de IConnection, necessária para conectar com o serviço de mensageria.
        /// </returns>
        public IConnection GetConnection()
        {
            _connectionFactory.HostName = this._hostName;
            _connectionFactory.UserName = this._userName;
            _connectionFactory.Password = this._password;
            _connectionFactory.AutomaticRecoveryEnabled = this._autoRecovery;
            _connectionFactory.NetworkRecoveryInterval = TimeSpan.FromSeconds(_networkRecoveryInterval);
            _connectionFactory.RequestedChannelMax = this._maximumChannel;
            return _connectionFactory.CreateConnection();
        }

        /// <returns>
        /// Uma lista de strings contendo as mensagens da fila.
        /// </returns>
        public List<string> Receive()
        {
            using (IConnection connection = GetConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    List<string> list = new List<string>();

                    QueueDeclareOk queueDeclareResponse = channel.QueueDeclare(this._queue, false, false, false, null);

                    //Fila vazia
                    if (queueDeclareResponse.MessageCount == 0)
                        return list;

                    uint queueDeep;

                    do
                    {
                        BasicGetResult result = channel.BasicGet(this._queue, true);
                        if (result == null)
                        {
                            return null;
                        }
                        queueDeep = result.MessageCount;
                        string message = Encoding.UTF8.GetString(result.Body.ToArray());
                        list.Add(message);
                    } while (queueDeep != 0);

                    return list;
                }
            }
        }
    }
}

