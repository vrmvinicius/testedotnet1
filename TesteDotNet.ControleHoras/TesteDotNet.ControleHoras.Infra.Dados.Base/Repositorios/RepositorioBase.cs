﻿using Infra.Dados.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;

namespace Infra.Dados.Base
{
    public abstract class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade> where TEntidade : class
    {
        private readonly DbContexto _dbContexto;

        public RepositorioBase(DbContexto Context)
        {
            _dbContexto = Context;
        }

        public virtual void Add(TEntidade obj)
        {
            try
            {
                _dbContexto.Set<TEntidade>().Add(obj);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual TEntidade GetById(int id)
        {
            return _dbContexto.Set<TEntidade>().Find(id);
        }

        public virtual IEnumerable<TEntidade> GetAll()
        {
           return _dbContexto.Set<TEntidade>().ToList();
        }

        public virtual Task<List<TEntidade>> GetAllAsync()
        {
            return _dbContexto.Set<TEntidade>().AsNoTracking().ToListAsync();
        }

        public virtual void Update(TEntidade obj)
        {
            try
            {
                _dbContexto.Entry(obj).State = EntityState.Modified;
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void Remove(TEntidade obj)
        {
            try
            {
                _dbContexto.Set<TEntidade>().Remove(obj);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _dbContexto.Dispose();
        }
    }
}
