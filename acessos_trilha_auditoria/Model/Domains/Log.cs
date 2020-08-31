using System;

namespace acessos_trilha_auditoria.Model.Domínio
{
    class Log
    {
        public int id { get; set; }
        public string ip { get; set; }
        public string agent { get; set; }
        public DateTime start_date { get; set; }
        public string user_name { get; set; }
        public string manchine_name { get; set; }
        public string calling_method_name { get; set; }
        public string assembly_name { get; set; }
        public string database_name { get; set; }
        public string changes { get; set; }
    }
}
