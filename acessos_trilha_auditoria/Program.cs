using acessos_trilha_auditoria.Model.Services;

namespace acessos_trilha_auditoria
{
    class Program
    {
        static void Main(string[] args)
        {
            ListarMensagensService mensagensService = new ListarMensagensService();
            AuditarService auditoriaService = new AuditarService();
            
            var listaDeMensangesRabbitMq = mensagensService.ListaMensagens();
            var logsValidos = auditoriaService.FiltrarLogs(listaDeMensangesRabbitMq);

            if (logsValidos != null)
            {
                auditoriaService.Auditar(logsValidos);
            }
        }
    }
}
