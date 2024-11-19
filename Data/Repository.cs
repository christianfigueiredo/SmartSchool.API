using SQLitePCL;

namespace SmartSchool.API.Data
{
   
    public class Repository : IRepository
    {
        private readonly Contexto _contexto;
        public Repository(Contexto contexto)
        {
            _contexto = contexto;        
        }
        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_contexto.SaveChanges() > 0);            
        }       
    }
}