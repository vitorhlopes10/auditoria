using System.Collections.Generic;

namespace acessos_trilha_auditoria.Model.Domains.Auditoria
{
    public class EntityFrameworkEvent
    {
        public EntityFrameworkEvent() { }
        public string Database { get; set; }
        public List<Entry> Entries { get; set; }
        public int Result { get; set; }
        public bool Success { get; set; }
    }
}
