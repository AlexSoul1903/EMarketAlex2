using AutoMapper;
using EMarketAlex2.Core.Aplication.Helpers;
using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Services
{
    public class GenericService<SaveViewModel,ViewModel,Entity> : IGenericServices<SaveViewModel,ViewModel,Entity>
        where SaveViewModel: class
        where ViewModel: class
        where Entity: class
    {
        private readonly IGenericRespository <Entity> _repository;

        private readonly IMapper _mapper;

        public GenericService(IGenericRespository<Entity> genericRespository, IMapper mapper)
           
        {
     
            _repository = genericRespository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);

          entity=  await _repository.AddAsync(entity);

            SaveViewModel saveViewModel = _mapper.Map<SaveViewModel>(entity);

            return saveViewModel;


        }

        public virtual async Task Delete(SaveViewModel vm, int id)
        {

            Entity entity = _mapper.Map<Entity>(vm);

 
            await _repository.DeleteAsync(entity, id);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entityList);
        }

        public virtual async Task<SaveViewModel> GetByIdAnuncioViewModel(int Id)
        {
            
            Entity entity = await _repository.GetByIdAsync(Id);


            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);

            return vm;


        }

        public virtual async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);


            await _repository.UpdateAsync(entity,id);

        }
    }
}
