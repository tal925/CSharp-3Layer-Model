using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BO;

namespace BlImplementation
{
    internal class ProductImplementation : BlApi.IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Product boProd)
        {
            try
            {
                // המרה מ-BO ל-DO
                DO.Product doProd = boProd.CopyToDO();
                return _dal.Product.Create(doProd);
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Product with ID {boProd.ProductId} already exists", ex);
            }
        }

        public BO.Product? Read(int id)
        {
            try
            {
                DO.Product? doProd = _dal.Product.Read(id);

                if (doProd == null)
                {
                    throw new BO.BlDoesNotExistException($"Product with ID {id} does not exist.");
                }
                return doProd.CopyToBO();
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Product ID {id} not found.", ex);
            }
        }

        public BO.Product? Read(Func<BO.Product, bool>? filter = null)
        {
            return ReadAll(filter).FirstOrDefault();
        }

        public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            var allProducts = from doProd in _dal.Product.ReadAll()
                              let boProd = doProd.CopyToBO()
                              select boProd;

            if (filter != null)
                return allProducts.Where(filter).ToList();

            return allProducts.ToList();
        }

        public void Update(BO.Product boProd)
        {
            try
            {
                _dal.Product.Update(boProd.CopyToDO());
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Update failed: Product {boProd.ProductId} not found.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Delete failed: Product {id} not found.", ex);
            }
        }

        public bool IsExist(int id)
        {
            var res = _dal.Product.Read(id);
            return res != null;
        }

   
        public void GetValidSalesForProduct(BO.ProductInOrder productInOrder, bool isPreferredCustomer)
        {
            var allSales = _dal.Sale.ReadAll();

            var validSales = from s in allSales
                             where s.ProductID == productInOrder.Id
                             && s.StartrSale <= DateTime.Now
                             && s.EndSale >= DateTime.Now
                             select new BO.SaleInProduct(
                                 s.SaleId,         
                                 s.MinProductSale, 
                                 s.SumPriceSale, 
                                 s.IfEveryOne     
                             );

            productInOrder.ListSale = validSales.ToList();
        }
    }
}