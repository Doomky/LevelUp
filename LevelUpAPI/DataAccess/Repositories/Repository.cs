using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.Repositories
{
    public abstract class Repository<DBEntity, ModelEntity> : IRepository<DBEntity, ModelEntity>
        where DBEntity : class, new()
        where ModelEntity : class, Dbo.IObjectWithId, new()
    {
        protected readonly DbSet<DBEntity> _set;
        protected readonly Model.levelupContext _context;
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;

        public Repository(Model.levelupContext context, DbSet<DBEntity> set, ILogger logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
            _set = set;
        }

        public virtual async Task<IEnumerable<ModelEntity>> Get(int? id = null)
        {
            try
            {
                List<DBEntity> query = null;
                query = await _set.AsNoTracking().ToListAsync();
                var arr = _mapper.Map<ModelEntity[]>(query);
                if (id.HasValue)
                    return arr.Where(obj => obj.Id == id.Value);
                else
                    return arr;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get this entry", ex);
                return null;
            }
        }

        public virtual async Task<ModelEntity> Insert(ModelEntity entity)
        {
            DBEntity dbEntity = _mapper.Map<DBEntity>(entity);
            _set.Add(dbEntity);
            try
            {
                await _context.SaveChangesAsync();
                ModelEntity newEntity = _mapper.Map<ModelEntity>(dbEntity);
                return newEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot insert this new entry", ex);
                return null;
            }
        }

        public virtual async Task<ModelEntity> Update(ModelEntity entity)
        {
            DBEntity dbEntity = _set.Find(entity.Id);

            if (dbEntity == null)
            {
                return null;
            }
            _mapper.Map(entity, dbEntity);
            if (!_context.ChangeTracker.HasChanges())
            {
                return entity;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot update this entry", ex);
                return null;
            }
            return _mapper.Map<ModelEntity>(dbEntity);
        }

        public virtual async Task<bool> Delete(int idEntity)
        {
            DBEntity dbEntity = _set.Find(idEntity);

            if (dbEntity == null)
            {
                return false;
            }
            _set.Remove(dbEntity);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot delete this entry", ex);
                return false;
            }
        }
    }
}
