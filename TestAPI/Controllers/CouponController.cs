using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Controllers
{
    public class CouponController : ControllerBase
    {
        private readonly TestDbContext _dbContext;

        public CouponController (TestDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("/GetCoupon")]
        public async Task<ActionResult> GetCoupon(string couponCode)
        {
            // Get the Coupon record
            CouponModel coupon = new CouponModel();
            coupon = _dbContext.Coupons
                            .AsNoTracking()
                            .FirstOrDefault(f => f.CouponCode == couponCode);
            if (coupon == null)
            {
                return NotFound("Coupon code " + couponCode + " does not exist");
            }

            //??
            double amount = coupon.Amount;


            //========================================================================
            // This must be changed to populate the lists in the CouponModel
            // with .include statements
            //========================================================================

            // Get the Countries where this coupon is valid
            List<CouponCountryModel> listCouponCountry = new List<CouponCountryModel>();
            listCouponCountry = await _dbContext.CouponCountries
                                .Where(s => s.CouponCode == couponCode)
                                .AsNoTracking()
                                .ToListAsync();


            // Now get the countries into the CouponModel
            coupon.ValidCountries = new List<CountryModel>();
            foreach(CouponCountryModel couponCountryModel in listCouponCountry)
            {
                //var country = _dbContext.Countries.FirstOrDefault(f => f.ID == Guid.Parse("97DF528D-0859-4629-949E-A4EC17A7DDBF"));
                CountryModel country = await _dbContext.Countries
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(s => s.ID == couponCountryModel.CountryId);
                if (country != null)
                    coupon.ValidCountries.Add(country);
            }


            // Get the Products for which this coupon is valid
            List<CouponProductModel> listCouponProduct = new List<CouponProductModel>();
            listCouponProduct = await _dbContext.CouponProducts
                                .Where(s => s.CouponCode == couponCode)
                                .AsNoTracking()
                                .ToListAsync();
            // Now get the products into the CouponModel
            coupon.ValidProducts = new List<ProductModel>();
            foreach (CouponProductModel couponProductModel in listCouponProduct)
            {
                ProductModel product = await _dbContext.Products.FindAsync(couponProductModel.ProductID);
                if (product != null)
                    coupon.ValidProducts.Add(product);
            }

                return Ok(coupon);
        }



        [HttpGet("/GetCountries")]
        public async Task<ActionResult> GetCountries()
        {
            //?? This gives an error "Invalid column name 'CouponModelID'
            var listCountries = await _dbContext.Countries.ToListAsync();
            return Ok(listCountries);
        }





    }
}
