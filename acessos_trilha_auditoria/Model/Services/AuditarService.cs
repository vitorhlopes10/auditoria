using acessos_trilha_auditoria.Model.Domains;
using acessos_trilha_auditoria.Model.Domains.Auditoria;
using acessos_trilha_auditoria.Model.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace acessos_trilha_auditoria.Model.Services
{
    class AuditarService
    {
        public readonly Repository _repository;

        public AuditarService()
        {
            _repository = new Repository();
        }

        public List<RootObject> FiltrarLogs(List<RootObject> logsDoRabbitMq)
        {
            List<string> tabelasParaAuditar = new List<string>();
            var dadosDeConfiguracaoDeAuditoria = BuscarConfiguracoesDeAuditoria();
            dadosDeConfiguracaoDeAuditoria.RemoveAll(x => x.id_status != Enumerados.Status.Aprovado);
            dadosDeConfiguracaoDeAuditoria.ForEach(x => x.listaTabelas.ForEach(y => tabelasParaAuditar.Add(y.nome_tabela)));
            logsDoRabbitMq.ForEach(x => x.EntityFrameworkEvent.Entries.RemoveAll(y => !(tabelasParaAuditar.Contains(y.Table))));
            logsDoRabbitMq = logsDoRabbitMq.Any(x => x.EntityFrameworkEvent.Entries.Any()) ? logsDoRabbitMq : null;

            return logsDoRabbitMq;
        }

        public void Auditar(List<RootObject> logsValidos)
        {
            var obj = MontarObjetoFinal(logsValidos);
            _repository.Salvar(obj);
        }

        public List<log> MontarObjetoFinal(List<RootObject> logsValidos)
        {
            List<log> obj = new List<log>();

            logsValidos.ForEach(x => obj.Add(new log
            {
                ip = x.ip,
                agent = x.agent,
                start_date = x.StartDate,
                user_name = x.Environment.UserName,
                manchine_name = x.Environment.MachineName,
                cpf_user = "teste", //x.cpf_user,
                name_user = "teste", //x.name_user,
                calling_method_name = x.Environment.CallingMethodName,
                http_method = "teste",
                assembly_name = x.Environment.AssemblyName,
                database_name = x.EntityFrameworkEvent.Database,
                change = GetChanges(x.EntityFrameworkEvent.Entries)
            }));

            return obj;
        }

        public List<change> GetChanges(List<Entry> list)
        {
            List<change> changes = new List<change>();

            list.ForEach(x => changes.Add(new change
            {
                schema = x.Schema,
                table = x.Table,
                action = x.Action,
                tuple = FormatarTuple(x.ColumnValues)
            })); 

            return changes;
        }

        public string FormatarTuple(Dictionary<string, string> dictionary)
        {
            string dictionaryString = "{";

            foreach (KeyValuePair<string, string> keyValues in dictionary)
            {
                dictionaryString += keyValues.Key + ": " + keyValues.Value + ", ";
            }

            return dictionaryString.TrimEnd(',', ' ') + "}";
        }

        public List<TrilhaAuditoria> BuscarConfiguracoesDeAuditoria()
        {
            try
            {
                Uri urlRequest = new Uri($"{System.Configuration.ConfigurationManager.AppSettings["acessos"]}/trilha-auditoria/listarTodos");
                var request = (HttpWebRequest)WebRequest.Create(urlRequest);

                HttpWebResponse response = null;
                request.Method = "GET";

                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                   (se, cert, chain, sslerror) =>
                   {
                       return true;
                   };

                response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return JsonConvert.DeserializeObject<List<TrilhaAuditoria>>(responseString);
            }
            catch (HttpException)
            {
                return null;
            }
        } 
    }
}
