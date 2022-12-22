using CodeBase.Core.Repositories;
using CodeBase.Core.Services;
using CodeBase.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entitiy)
        {
          await _repository.AddAsync(entitiy);
            await _unitOfWork.CommitAsync();
            return entitiy;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);
            if(hasProduct == null)
            {
                throw new DirectoryNotFoundException($"{typeof(T).Name} not found");
            }
            return hasProduct;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task RemoveAsync(T entitiy)
        {
             _repository.Remove(entitiy);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entitiy)
        {
            _repository.UpdateAsync(entitiy);
            await _unitOfWork.CommitAsync();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

     
    }
}
