using AccountingForPersonalFinances.Application.Common.Mappings;
using AccountingForPersonalFinances.Domain.Models;
using AutoMapper;

namespace AccountingForPersonalFinances.Application.Wallets.Queries.GetWalletList
{
    public class WalletLookupDto : IMapWith<Wallet>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Сurrency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Wallet, WalletLookupDto>()
                .ForMember(walletDto => walletDto.ID,
                    opt => opt.MapFrom(wallet => wallet.ID))
                .ForMember(walletDto => walletDto.Name,
                    opt => opt.MapFrom(wallet => wallet.Name))
                .ForMember(walletDto => walletDto.Сurrency,
                    opt => opt.MapFrom(wallet => wallet.Сurrency));
        }
    }
}