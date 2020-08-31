namespace acessos_trilha_auditoria.Model.Domains.Auditoria
{
    public class Environment
    {
        public Environment() { }
        public string UserName { get; set; }
        public string MachineName { get; set; }
        public string DomainName { get; set; }
        public string CallingMethodName { get; set; }
        public string AssemblyName { get; set; }
        public string Culture { get; set; }
    }
}
