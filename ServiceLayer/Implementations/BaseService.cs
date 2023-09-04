using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Abstracts;

namespace ServiceLayer.Implementations
{
    public class BaseService<TRequestDto, TEntity, TResponseDto> 
        : IBaseService<TRequestDto, TEntity, TResponseDto>
        where TEntity : EntityBase
    {
        protected readonly IMapper _mapper;
        protected readonly WebAppDatabaseContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseService(IMapper mapper, WebAppDatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TResponseDto> CreateAsync(TRequestDto requestDto)
        {
            var entity = _mapper.Map<TEntity>(requestDto);
            entity.CreateId = 1;
            entity.CreateTime = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            var responseDto = _mapper.Map<TResponseDto>(entity);
            return responseDto;
        }

        public async Task<IEnumerable<TResponseDto>> GetAllAsync()
        {
            var entityList = await _dbSet.ToListAsync();
            var responseDto = _mapper.Map<IEnumerable<TResponseDto>>(entityList);
            return responseDto;
        }

        public async Task<TResponseDto> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            var responseDto = _mapper.Map<TResponseDto>(entity);
            return responseDto;
        }

        public async Task<TResponseDto> UpdateAsync(TRequestDto requestDto)
        {
            var entity = _mapper.Map<TEntity>(requestDto);
            entity.UpdateId = 1;
            entity.UpdateTime = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            var responseDto = _mapper.Map<TResponseDto>(entity);
            return responseDto;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return 0;
            }
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}