namespace acessos_trilha_auditoria.Model.Enums
{
    public static class Enumerados
    {
        public enum Status
        {
            EmAnalise = 1,
            Aprovado = 2,
            Recusado = 3,
            Excluido = 4
        }

        public enum Sistemas
        {
            Acessos = 1,
            EPC = 2,
            Arrecadacao = 3,
            Registro = 4,
            CRE = 5
        }

        public enum Finalidade
        {
            Sistema = 1,
            Rotina = 2,
            SistemaRotina = 3
        }
    }
}

