﻿using System.Collections.ObjectModel;
using CarWashManager.DataAccess.Entities;

namespace CarWashManager.DataAccess.Repositories.Wash;

public class WashRepository : IWashRepository
{
    private readonly WashContext _context;
    public WashRepository(WashContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<WashEntity>> Get() =>
        Task.FromResult(_context.Washs.ToList().AsReadOnly());

    public Task<WashEntity?> Get(string WashId) =>
        Task.FromResult(_context.Washs.FirstOrDefault(e => e.WashId == WashId));

    public Task<ReadOnlyCollection<WashEntity>> Get(Func<WashEntity, bool> predicate)
    {
        return Task.FromResult(_context.Washs.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(WashEntity entity)
    {
        _context.Washs.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(WashEntity entity)
    {
        foreach (var e in _context.Washs)
        {
            if (e.WashId == entity.WashId)
            {
                e.WashType = entity.WashType;
                e.DishType = entity.DishType;
                e.DishName = entity.DishName;
                e.Amount = entity.Amount;
                e.WashTime = entity.WashTime;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string WashId)
    {
        var entity = _context.Washs.FirstOrDefault(e => e.OrderId == WashId);
        if (entity != null)
        {
            _context.Washs.Remove(entity);
        }
        return Task.CompletedTask;
    }
}