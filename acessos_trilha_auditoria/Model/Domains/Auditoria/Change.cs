namespace acessos_trilha_auditoria.Model.Domains.Auditoria
{
    public class Change
    {
        public Change() { }
        public string ColumnName { get; set; }
        public object OriginalValue { get; set; }
        public object NewValue { get; set; }
    }
}
