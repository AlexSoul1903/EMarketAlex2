using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface IGenericServices<ViewModel,ListViewModel,Entity>
        where ViewModel : class
        where ListViewModel : class
        where Entity : class
    
    {
        Task<ViewModel> add(ViewModel vm);
        Task<ViewModel> GetByIdAnuncioViewModel(int Id);
        Task Update(ViewModel vm, int id);
        Task Delete(ViewModel vm, int id);
        Task<List<ListViewModel>> GetAllViewModel();



    }
}
