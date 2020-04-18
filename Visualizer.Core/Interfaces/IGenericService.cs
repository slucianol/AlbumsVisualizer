using System.Linq;
using Visualizer.Core.Entities;

namespace Visualizer.Core.Interfaces {
    public interface IGenericService<T> where T : BaseEntity {
        IQueryable<T> GetAll();
        T GetById(short id);
    }
}