using acessos_trilha_auditoria.Model.Domains.Auditoria;
using acessos_trilha_auditoria.Mq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace acessos_trilha_auditoria.Model.Services
{
    /// <summary>
    /// Classe que implementa a Service que busca mensagens da fila.
    /// </summary>
    public class ListarMensagensService
    {
        private readonly RabbitMq _rabbitMQ;

        /// <param name="rabbitMQ">Uma instância de IRabbitMQ, necessária para consumir as mensagens de auditoria que estão na fila.</param>
        public ListarMensagensService()
        {
            _rabbitMQ = new RabbitMq();
        }

        /// <returns>
        /// Uma list<RootObject> contendo as mensagens da fila.
        /// </returns>
        public List<RootObject> ListaMensagens()
        {
            List<RootObject> list = new List<RootObject>();

            List<string> messageList = this._rabbitMQ.Receive();

            if (null == messageList || messageList.Count == 0)
                return list;

            foreach (string message in messageList)
            {
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(message);
                list.Add(rootObject);
            }

            return list;
        }
    }
}

