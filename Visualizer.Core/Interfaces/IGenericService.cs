using System.Collections.Generic;
using System.Threading.Tasks;
using Visualizer.Core.Entities;

namespace Visualizer.Core.Interfaces {
    public interface IGenericService<T> where T : BaseEntity {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}