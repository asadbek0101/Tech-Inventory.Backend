namespace Tech_Inventory.Application.Common.Helpers;

public static class CollectionExtensions
{
    public static void SyncCollection<TEntity, TDto>(
        this ICollection<TEntity> entities,
        IEnumerable<TDto> dtos,
        Func<TDto, int?> dtoKeySelector,
        Func<TEntity, int> entityKeySelector,
        Action<TEntity, TDto> updateEntity,
        Func<TDto, TEntity> createEntity)
    {
        var dtoIds = dtos
            .Where(d => dtoKeySelector(d).HasValue)
            .Select(d => dtoKeySelector(d)!.Value)
            .ToHashSet();

        var toRemove = entities
            .Where(e => !dtoIds.Contains(entityKeySelector(e)))
            .ToList();

        foreach (var r in toRemove)
            entities.Remove(r);

        foreach (var dto in dtos)
        {
            var dtoId = dtoKeySelector(dto);

            if (dtoId.HasValue)
            {
                var entity = entities.FirstOrDefault(e => entityKeySelector(e) == dtoId.Value);

                if (entity != null)
                {
                    updateEntity(entity, dto); 
                }
                else
                {
                    var newEntity = createEntity(dto); 
                    entities.Add(newEntity);
                }
            }
            else
            {
                var newEntity = createEntity(dto); 
                entities.Add(newEntity);
            }
        }
    }
}