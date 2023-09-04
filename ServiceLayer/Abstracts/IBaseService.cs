namespace ServiceLayer.Abstracts
{
    public interface IBaseService<TRequestDto, TEntity, TResponseDto>
    {
        Task<TResponseDto> CreateAsync(TRequestDto requestDto);
        Task<IEnumerable<TResponseDto>> GetAllAsync();
        Task<TResponseDto> GetByIdAsync(int id);
        Task<TResponseDto> UpdateAsync(TRequestDto requestDto);
        Task<int> DeleteAsync(int id);
    }
}