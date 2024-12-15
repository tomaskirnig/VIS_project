using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Purchase(PurchaseDTO purchaseDTO)
        {
            MapPurchase(purchaseDTO);
        }

        public Purchase(int purchaseId)
        {
            PurchaseDTO purchase = PurchaseTDG.GetById(purchaseId);

            if (purchase != null)
            {
                MapPurchase(purchase);
            }
            else
            {
                throw new ArgumentException("Purchase not found");
            }
        }

        public void MapPurchase(PurchaseDTO purchaseDTO)
        {
            PurchaseId = purchaseDTO.PurchaseId;
            GameId = purchaseDTO.GameId;
            PlayerId = purchaseDTO.PlayerId;
            Price = purchaseDTO.Price;
            PurchaseDate = purchaseDTO.PurchaseDate;
        }

        public void Update()
        {
            PurchaseDTO purchase = new PurchaseDTO
            {
                PurchaseId = PurchaseId,
                GameId = GameId,
                PlayerId = PlayerId,
                Price = Price,
                PurchaseDate = PurchaseDate
            };

            PurchaseTDG.Update(purchase);
        }

        public static List<Purchase> GetAllPurchases()
        {
            List<PurchaseDTO> purchasesDTO = PurchaseTDG.GetAll().ToList();

            if (purchasesDTO != null)
            {
                return purchasesDTO.Select(dto => new Purchase(dto)).ToList();
            }
            else
            {
                throw new ArgumentException("No purchases found");
            }
        }

        public static float GetPriceSum()
        {
            return PurchaseTDG.GetPriceSum();
        }

        public static int GetPurchaseCount()
        {
            return PurchaseTDG.GetPurchaseCount();
        }

        public static float GetPriceSum(int gameId)
        {
            return PurchaseTDG.GetPriceSum(gameId);
        }
    }
}
