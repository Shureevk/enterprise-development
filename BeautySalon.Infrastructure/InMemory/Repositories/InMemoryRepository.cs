using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Repositories;

namespace BeautySalon.Infrastructure.InMemory.Repositories;

/// <summary>
/// Общие операции с сущностями в памяти
/// </summary>
public abstract class InMemoryRepository<TEntity>(
    SalonStorage storage,
    List<TEntity> entities,
    Func<TEntity, TEntity> copy) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected SalonStorage Storage { get; } = storage;

    /// <inheritdoc />
    public IReadOnlyList<TEntity> GetAll()
    {
        lock (Storage.SyncRoot)
        {
            return entities.Select(copy).ToList();
        }
    }

    /// <inheritdoc />
    public TEntity? GetById(int id)
    {
        lock (Storage.SyncRoot)
        {
            var entity = Find(id);
            return entity is null ? null : copy(entity);
        }
    }

    /// <inheritdoc />
    public TEntity Add(TEntity entity)
    {
        lock (Storage.SyncRoot)
        {
            var saved = copy(entity);
            PrepareForSave(saved, null);
            saved.Id = Storage.NextId<TEntity>();
            entities.Add(saved);
            return copy(saved);
        }
    }

    /// <inheritdoc />
    public bool Update(TEntity entity)
    {
        lock (Storage.SyncRoot)
        {
            var current = Find(entity.Id);
            if (current is null)
            {
                return false;
            }

            var saved = copy(entity);
            PrepareForSave(saved, current);
            ApplyChanges(current, saved);
            return true;
        }
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        lock (Storage.SyncRoot)
        {
            var current = Find(id);
            if (current is null)
            {
                return false;
            }

            CheckDeletion(current);
            return entities.Remove(current);
        }
    }

    /// <summary>
    /// Подготовить копию к сохранению и проверить ограничения
    /// </summary>
    protected virtual void PrepareForSave(TEntity saved, TEntity? current)
    {
    }

    /// <summary>
    /// Обновить объект на месте, чтобы сохранить ссылки на него
    /// </summary>
    protected abstract void ApplyChanges(TEntity current, TEntity saved);

    /// <summary>
    /// Проверить, можно ли удалить объект
    /// </summary>
    protected virtual void CheckDeletion(TEntity entity)
    {
    }

    private TEntity? Find(int id)
    {
        return entities.FirstOrDefault(entity => entity.Id == id);
    }
}
