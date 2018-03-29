using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    public interface BaseRepository<T>
    {
        List<T> FindAll();

        bool Create(T t);

        bool Update(T t);

        bool Delete(T t);
    }
}
