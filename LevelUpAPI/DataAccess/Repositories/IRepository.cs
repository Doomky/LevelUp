using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public interface IRepository<DBEntity, ModelEntity>
    {
        Task<IEnumerable<ModelEntity>> Get(int? id);
        Task<ModelEntity> Insert(ModelEntity entity);
        Task<ModelEntity> Update(ModelEntity entity);
        Task<bool> Delete(int idEntity);
    }
}
