using Application.Services.Interfaces;
using AutoMapper;
using Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GeneralApplication<TVM, TM> : InterApplication<TVM, TM>
        where TVM : class
        where TM : class
    {
        protected readonly IMapper _mapper;
        protected readonly InterRepository<TM> _interface_Repo;

        public GeneralApplication(IMapper mapper, InterRepository<TM> interface_Repo)
        {
            _mapper = mapper;
            _interface_Repo = interface_Repo;
        }

        public virtual async Task<TM> CreateAsync(TVM viewModel)
        {
            try
            {
                TM map = _mapper.Map<TVM, TM>(viewModel);

                await _interface_Repo.CreateAsync(map);
                return map;
            }
            catch (Exception)
            {
                // _logger.LogError(ex.Message);
                return _mapper.Map<TVM, TM>(viewModel);
            }
        }

        public virtual async Task<TVM> EditAsync(TVM viewModel)
        {
            try
            {
                await _interface_Repo.EditAsync(_mapper.Map<TVM, TM>(viewModel));
                return viewModel;
            }
            catch (Exception)
            {
                // _logger.LogError(ex.Message);
                return viewModel;
            }
        }

        public virtual async Task<TVM?> FindAsync(int id)
        {
            try
            {
                return _mapper.Map<TM?, TVM?>(await _interface_Repo.FindAsync(id));
            }
            catch (Exception)
            {
                // _logger.LogError(ex.Message);
                return null;
            }
        }

        public virtual async Task<IEnumerable<TVM>> FindAllAsync()
        {
            try
            {
                return _mapper.Map<IEnumerable<TM>, IEnumerable<TVM>>(await _interface_Repo.FindAllAsync());
            }
            catch (Exception)
            {
                // _logger.LogError(ex.Message);
                return _mapper.Map<IEnumerable<TM>, IEnumerable<TVM>>([]);
            }
        }
    }

    public class GeneralApplication<TM> : InterApplication<TM>
        where TM : class
    {
        protected readonly IMapper _mapper;
        protected readonly InterRepository<TM> _interface_Repo;

        public GeneralApplication(IMapper mapper, InterRepository<TM> interface_Repo)
        {
            _mapper = mapper;
            _interface_Repo = interface_Repo;
        }

        public virtual async Task<TM> CreateAsync(TM model)
        {
            try
            {
                await _interface_Repo.CreateAsync(model);
                return model;
            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
                return model;
            }
        }


        public virtual async Task<TM> EditAsync(TM model)
        {
            try
            {
                await _interface_Repo.EditAsync(model);
                return model;
            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
                return model;
            }
        }


        public virtual async Task<TM?> FindAsync(int id)
        {
            try
            {
                return await _interface_Repo.FindAsync(id);
            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
                return default;
            }
        }

        public virtual async Task<IEnumerable<TM>> FindAllAsync()
        {
            try
            {
                return await _interface_Repo.FindAllAsync();
            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
                return [];
            }
        }


    }
}
