using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface ISilverJewelryRepo
    {
        Task<List<SilverJewelry>> GetAllS();
        Task<SilverJewelry> GetSById(string id);
        Task<SilverJewelry> AddS(SilverJewelry silverJewelry);
        Task<SilverJewelry> UpdateS(SilverJewelry silverJewelry);
        Task<SilverJewelry> DeleteS(string id);
        Task<List<Category>> GetCategory();
    }
}
