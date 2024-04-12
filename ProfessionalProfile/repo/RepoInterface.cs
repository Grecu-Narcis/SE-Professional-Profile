using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public interface RepoInterface<T>
    {
        public T GetById(int id);
        public List<T> GetAll();
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
