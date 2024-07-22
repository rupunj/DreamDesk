﻿using Grpc.Core;

namespace DiscountGRPC.Services;

public class DiscountService :DiscountProtoService.DiscountProtoServiceBase
{
    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        return base.CreateDiscount(request, context);
    }
    public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        return base.GetDiscount(request, context);
    }
    public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        return base.UpdateDiscount(request, context);
    }
    public override Task<DeleteDiscpountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return base.DeleteDiscount(request, context);
    }

}
