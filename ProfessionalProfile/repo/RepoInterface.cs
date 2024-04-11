using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public interface RepoInterface<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public void Add(T item);
        public void Delete(int id);
        public void Update(T entity);
    }
}
