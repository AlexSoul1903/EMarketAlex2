using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface IGenericServices<ViewModel,ListViewModel>
        where ViewModel : class
        where ListViewModel : class
    
    {
        Task<ViewModel> add(ViewModel vm);
        Task<ViewModel> GetByIdAnuncioViewModel(int Id);
        Task Update(ViewModel vm);
        Task Delete(ViewModel vm);
        Task<List<ListViewModel>> GetAllViewModel();



    }
}
