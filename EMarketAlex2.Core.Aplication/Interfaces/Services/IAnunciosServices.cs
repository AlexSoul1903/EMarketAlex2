using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface IAnunciosServices: IGenericServices<SaveAnuncioViewModel, AnuncioViewModel>
    {

        Task<List<AnuncioViewModel>> GetAnuncioViewModels(FilterAnuncioViewModel filter);

    }
}
