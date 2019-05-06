using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Repository.Repository;

namespace SmallBusinessManagementApp.BLL.BLL
{
    public class SupplierManager
    {
        public SupplierRepository _repository = new SupplierRepository();

        public bool Saved(Supplier supplier)
        {
            if (_repository.Exist(supplier))
            {
                return false;
            }
            bool isSaved = _repository.Saved(supplier);
            return isSaved;
        }

        public List<Supplier> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(Supplier supplier)
        {
            bool isUpdated = _repository.Update(supplier);
            return isUpdated;
        }

        public bool Delete(Supplier supplier)
        {
            bool isDeleted = _repository.Delete(supplier);
            return isDeleted;
        }

        public Supplier GetSupplierById(int id)
        {
            Supplier supplier = _repository.GetsupplierById(id);
            return supplier;
        }
    }
}
