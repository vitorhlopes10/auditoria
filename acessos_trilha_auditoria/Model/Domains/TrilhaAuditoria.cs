using acessos_trilha_auditoria.Model.Enums;
using System;
using System.Collections.Generic;

namespace acessos_trilha_auditoria.Model.Domains
{
    class TrilhaAuditoria
    {
        public TrilhaAuditoria()
        {
            listaTabelas = new List<TrilhaAuditoriaTabelas>();
        }

        public int id { get; set; }
        public Enumerados.Status id_status { get; set; }
        public Enumerados.Sistemas id_sistema { get; set; }
        public Enumerados.Finalidade id_finalidade { get; set; }
        public DateTime data_inclusao { get; set; }
        public DateTime? data_alteracao { get; set; }
        public string incluido_por { get; set; }
        public string alterado_por { get; set; }
        public List<TrilhaAuditoriaTabelas> listaTabelas { get; set; }
    }
}
