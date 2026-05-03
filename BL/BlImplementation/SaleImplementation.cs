using System;
using System.Collections.Generic;
using System.Linq;
using BO;

namespace BlImplementation
{
    internal class SaleImplementation : BlApi.ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale boSale)
        {
            try
            {
                DO.Sale doSale = new DO.Sale
                {
                    SaleId = boSale.SaleId,
                    ProductID = boSale.ProductID,
                    MinProductSale = boSale.MinProductSale,
                    SumPriceSale = boSale.SumPriceSale,
                    IfEveryOne = boSale.IfEveryOne,
                    StartrSale = boSale.StartrSale,
                    EndSale = boSale.EndSale
                };

                return _dal.Sale.Create(doSale);
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Sale with ID {boSale.SaleId} already exists", ex);
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
                DO.Sale? doSale = _dal.Sale.Read(id);

                if (doSale == null)
                    throw new BO.BlDoesNotExistException($"Sale with ID {id} does not exist.");

                return new BO.Sale
                {
                    SaleId = doSale.SaleId,
                    ProductID = doSale.ProductID,
                    MinProductSale = doSale.MinProductSale,
                    SumPriceSale = doSale.SumPriceSale,
                    IfEveryOne = doSale.IfEveryOne,
                    StartrSale = doSale.StartrSale,
                    EndSale = doSale.EndSale
                };
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Sale with ID {id} not found.", ex);
            }
        }

        public BO.Sale? Read(Func<BO.Sale, bool>? filter = null)
        {
            return ReadAll(filter).FirstOrDefault();
        }

        public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            var allSales = from doSale in _dal.Sale.ReadAll()
                           select new BO.Sale
                           {
                               SaleId = doSale.SaleId,
                               ProductID = doSale.ProductID,
                               MinProductSale = doSale.MinProductSale,
                               SumPriceSale = doSale.SumPriceSale,
                               IfEveryOne = doSale.IfEveryOne,
                               StartrSale = doSale.StartrSale,
                               EndSale = doSale.EndSale
                           };

            if (filter != null)
                return allSales.Where(filter).ToList();

            return allSales.ToList();
        }

        public void Update(BO.Sale boSale)
        {
            try
            {
                DO.Sale doSale = new DO.Sale
                {
                    SaleId = boSale.SaleId,
                    ProductID = boSale.ProductID,
                    MinProductSale = boSale.MinProductSale,
                    SumPriceSale = boSale.SumPriceSale,
                    IfEveryOne = boSale.IfEveryOne,
                    StartrSale = boSale.StartrSale,
                    EndSale = boSale.EndSale
                };
                _dal.Sale.Update(doSale);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Update failed: Sale {boSale.SaleId} not found.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Delete failed: Sale {id} not found.", ex);
            }
        }

        public bool IsExist(int id)
        {
            var res = _dal.Sale.Read(id);
            return res != null;
        }
    }
}
