namespace acessos_trilha_auditoria.Model.Domains
{
    class TrilhaAuditoriaTabelas
    {
        public TrilhaAuditoriaTabelas()
        {
            trilha_de_auditoria = new TrilhaAuditoria();
        }

        public int id { get; set; }
        public string nome_tabela { get; set; }
        public int id_trilha_auditoria { get; set; }
        public TrilhaAuditoria trilha_de_auditoria { get; set; }
    }
}
