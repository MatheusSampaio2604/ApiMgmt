namespace Application.Services.Interfaces
{
    internal interface InterApplication<TVM, TM>
        where TVM : class
        where TM : class
    {
        Task<TM> CreateAsync(TVM model);
        Task<TVM> EditAsync(TVM model);
        Task<TVM?> FindAsync(int id);
        Task<IEnumerable<TVM>> FindAllAsync();
    }

    public interface InterApplication<TM>
        where TM : class
    {
        Task<TM> CreateAsync(TM model);
        Task<TM> EditAsync(TM model);
        Task<TM?> FindAsync(int id);
        Task<IEnumerable<TM>> FindAllAsync();
    }
}
