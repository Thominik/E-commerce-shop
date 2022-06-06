using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Address = Core.Entities.Identity.Address;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(x => x.ProductBrand, c => c.MapFrom(s => s.ProductBrand.Name))
            .ForMember(x => x.ProductType, c => c.MapFrom(s => s.ProductType.Name))
            .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

        CreateMap<Address, AddressDto>().ReverseMap();

        CreateMap<CustomerBasketDto, CustomerBasket>();

        CreateMap<BasketItemDto, BasketItem>();

        CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();

        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod,
                o =>
                    o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.ShippingPrice,
                o =>
                    o.MapFrom(s => s.DeliveryMethod.Price));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId,
                o =>
                    o.MapFrom(s => s.ItemOrdered.ProductItemId))
            .ForMember(d => d.ProductName,
                o =>
                    o.MapFrom(s => s.ItemOrdered.ProductName))
            .ForMember(d => d.PictureUrl,
                o =>
                    o.MapFrom(s => s.ItemOrdered.PictureUrl))
            .ForMember(d => d.PictureUrl, o => 
                o.MapFrom<OrderItemUrlResolver>());
    }
}