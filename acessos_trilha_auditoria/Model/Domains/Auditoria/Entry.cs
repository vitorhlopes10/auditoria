using System.Collections.Generic;

namespace acessos_trilha_auditoria.Model.Domains.Auditoria
{
    public class Entry
    {
        public Entry() { }
        public string Schema { get; set; }
        public string Table { get; set; }
        public string Action { get; set; }
        public PrimaryKey PrimaryKey { get; set; }
        public List<Change> Changes { get; set; }
        public Dictionary<string, string> ColumnValues { get; set; }
        public bool Valid { get; set; }
        public List<object> ValidationResults { get; set; }
        public string Tupla { get; set; }
    }
}
