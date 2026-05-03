using System;
using System.Collections.Generic;
using System.Linq;
using BO;

namespace BlImplementation
{
    internal class CustemerImplementation : BlApi.ICustemer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        //לוקחת מ-BO וממירה ל-DO ואז שולחת ל-DAL
        public int Create(BO.Custemer boCust)
        {
            try
            {
                DO.Custemer doCust = boCust.CopyToDO();
                return _dal.Custemer.Create(doCust);
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Customer with ID {boCust.CustemerID} already exists", ex);
            }
        }

        public BO.Custemer? Read(int id)
        {
            try
            {
                DO.Custemer? doCust = _dal.Custemer.Read(id);

                if (doCust == null)
                {
                    throw new BO.BlDoesNotExistException($"Customer with ID {id} does not exist.");
                }
                return doCust.CopyToBO();
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Customer ID {id} not found.", ex);
            }
        }
        public BO.Custemer? Read(Func<BO.Custemer, bool>? filter = null)
        {
            return ReadAll(filter).FirstOrDefault();
        }

        public List<BO.Custemer?> ReadAll(Func<BO.Custemer, bool>? filter = null)
        {
            var allCustemers = from doCust in _dal.Custemer.ReadAll()
                               let boCust = doCust.CopyToBO()
                               select boCust;

            if (filter != null)
                return allCustemers.Where(filter).ToList();

            return allCustemers.ToList();
        }

        public void Update(BO.Custemer boCust)
        {
            try
            {
                _dal.Custemer.Update(boCust.CopyToDO());
            }
            
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Update failed: Customer {boCust.CustemerID} not found.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Custemer.Delete(id);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Delete failed: Customer {id} not found.", ex);
            }
        }

        public bool IsExist(int id)
        {
            var res = _dal.Custemer.Read(id);
            return res != null;
        }
    }
}