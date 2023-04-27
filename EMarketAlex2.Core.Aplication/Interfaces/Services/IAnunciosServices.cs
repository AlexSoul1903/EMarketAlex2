using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using EMarketAlex2.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface IAnunciosServices: IGenericServices<SaveAnuncioViewModel, AnuncioViewModel,Anuncios>
    {

        Task<List<AnuncioViewModel>> GetAnuncioViewModels(FilterAnuncioViewModel filter);
        Task<List<AnuncioViewModel>> GetAllModelFilter();
        Task<List<AnuncioViewModel>> Filtro(List<int> IdCategorias);
        Task<List<AnuncioViewModel>> GetAllViewModelWithInclude();
    }
}
