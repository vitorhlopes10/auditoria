using System;

namespace acessos_trilha_auditoria.Model.Domains.Auditoria
{
    public class RootObject
    {
        public RootObject() { }
        public string EventType { get; set; }
        public Environment Environment { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public EntityFrameworkEvent EntityFrameworkEvent { get; set; }
        public string ip { get; set; }
        public string agent { get; set; }
        public string http_method { get; set; }
        public string cpf_user { get; set; }
        public string name_user { get; set; }

    }
}
