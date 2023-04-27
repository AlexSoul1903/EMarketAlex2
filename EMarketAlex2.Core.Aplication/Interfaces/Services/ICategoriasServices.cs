using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface ICategoriasServices: IGenericServices<SaveCategoriaViewModel, CategoriasViewModel,Categorias>

    {

        Task<List<CategoriasViewModel>> GetAllViewModeWithIncludel();

    }
}
