﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PurchaseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PurchaseDTO> GetAllPurchases()
        {
            var purchases = _context.Purchases
                .Include(p => p.Product)
                .ToList();
            var t = purchases.Select(s => new { s.ProductId, s.QuantityPurchased });
            return _mapper.Map<List<PurchaseDTO>>(purchases);
        }
        public PurchaseDTO GetPurchaseById(int id)
        {
            var purchase = _context.Purchases.Find(id);
            if (purchase == null)
            {
                return null;
            }
            return _mapper.Map<PurchaseDTO>(purchase);
        }
        public PurchaseDTO CreatePurchase(PurchaseDTO purchaseDto)
        {
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            var product = _context.Products.FirstOrDefault(x => x.ProductID == purchaseDto.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.QuantityInStock += purchaseDto.QuantityPurchased;
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
            return _mapper.Map<PurchaseDTO>(purchase);
        }
    }

}
