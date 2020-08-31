using System.Collections.Generic;

namespace acessos_trilha_auditoria.Model
{
    class Repository
    {
        public readonly AuditoriaContext _context;

        public Repository()
        {
            _context = new AuditoriaContext();
        }

        public void Salvar<TEntidade>(ICollection<TEntidade> entidade) where TEntidade : class
        {
            _context.Set<TEntidade>().AddRange(entidade);
            _context.SaveChanges();
        }
    }
}
