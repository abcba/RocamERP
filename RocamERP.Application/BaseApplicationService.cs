﻿using System.Collections.Generic;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class BaseApplicationService<TEntity> : IBaseApplicationService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseApplicationService(IBaseService<TEntity> service)
        {
            _baseService = service;
        }

        public void Add(TEntity obj)
        {
            _baseService.Add(obj);
        }

        public void Delete(int id)
        {
            _baseService.Delete(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _baseService.Get();
        }

        public TEntity Get(int id)
        {
            return _baseService.Get(id);
        }

        public TEntity Get(string id)
        {
            return _baseService.Get(id);
        }

        public void Update(TEntity obj)
        {
            _baseService.Update(obj);
        }
    }
}
