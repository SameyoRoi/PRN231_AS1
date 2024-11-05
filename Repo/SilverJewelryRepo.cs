using BO;
using DAO;

namespace Repo
{
    public class SilverJewelryRepo : ISilverJewelryRepo
    {
        public async Task<SilverJewelry> AddS(SilverJewelry silverJewelry)
        {
            return await SilverJewelryDAO.Instance.AddS(silverJewelry);
        }

        public async Task<SilverJewelry> DeleteS(string id)
        {
            return await SilverJewelryDAO.Instance.DeleteS(id);
        }

        public async Task<SilverJewelry> GetSById(string id)
        {
            return await SilverJewelryDAO.Instance.GetById(id);
        }

        public async Task<List<SilverJewelry>> GetAllS()
        {
            return await SilverJewelryDAO.Instance.GetAll();
        }

        public async Task<SilverJewelry> UpdateS(SilverJewelry silverJewelry)
        {
            return await SilverJewelryDAO.Instance.UpdateS(silverJewelry);
        }
        public async Task<List<Category>> GetCategory()
        {
            return await SilverJewelryDAO.Instance.GetCategory();
        }
    }
}
