using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
    public static  class PurchaseOpMapper
    {
        public static PurchaseOpDTO ConvertToPurchaseOpDTO(this PurchaseOp purchase)
        {
            return Mapper.Map<PurchaseOp, PurchaseOpDTO>(purchase);
        }

        public static PurchaseOp ConvertToPurchaseOp(this PurchaseOpDTO purchase)
        {
            return Mapper.Map<PurchaseOpDTO, PurchaseOp>(purchase);
        }

        public static PurchaseOpDetailDTO ConvertToPurchaseOpDetailDTO(this PurchaseOpDetail purchaseDetail)
        {
            return Mapper.Map<PurchaseOpDetail, PurchaseOpDetailDTO>(purchaseDetail);
        }

        public static PurchaseOpDetail ConvertToPurchaseOpDetail(this PurchaseOpDetailDTO purchaseDetail)
        {
            return Mapper.Map<PurchaseOpDetailDTO, PurchaseOpDetail>(purchaseDetail);
        }

        public static IEnumerable<PurchaseOpDTO> ConvertToPurchaseOpDtos(this IEnumerable<PurchaseOp> purchases)
        {
            return MapperHelper.Map<PurchaseOp, PurchaseOpDTO>(purchases);
        }
    }
}
