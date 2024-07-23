using DiscountGRPC.Data;
using DiscountGRPC.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DiscountGRPC.Services;

public class DiscountService(DiscountContext discountContext ,ILogger<DiscountService> logger) :DiscountProtoService.DiscountProtoServiceBase
{
    public async override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument,"Invalid Request"));
        }
        await discountContext.Coupons.AddAsync(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation("DiscountService CreateDiscount {productName} has been added", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await discountContext
                        .Coupons
                        .FirstOrDefaultAsync(x=>x.ProductName == request.ProductName);

        if (coupon is null)
        {
            coupon = new Coupon{
                ProductName = "No Discount",
                Description = "No Discount",
                Amount = 0
            };
        }
        logger.LogInformation("DiscountService GetDiscount {productName} has {discount}", coupon.ProductName,coupon.Amount);
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
    public async override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument,"Invalid Request"));
        }
        discountContext.Coupons.Update(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation("DiscountService Update Discount {productName} has been added", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
    public override async Task<DeleteDiscpountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await discountContext.Coupons
                        .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,$"Discount With Product Name {request.ProductName} is not found"));
        }
        discountContext.Coupons.Remove(coupon);
        await discountContext.SaveChangesAsync();

        logger.LogInformation("DiscountService DeleteDiscount {productName} has been deleted", coupon.ProductName);
        return new DeleteDiscpountResponse{Success = true};
    }

}
