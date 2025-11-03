using AccountingForPersonalFinances.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Wallets.Queries.GetWalletList
{
    public class GetWalletListQueryHandler : IRequestHandler<GetWalletListQuery, WalletListVm>
    {
        private readonly IAccountingForPersonalFinancesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWalletListQueryHandler(IAccountingForPersonalFinancesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<WalletListVm> Handle(GetWalletListQuery request, CancellationToken cancellationToken)
        {
            var walletsQuery = await _dbContext.Wallets
                .ProjectTo<WalletLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new WalletListVm { Wallets = walletsQuery };
        }
    }
}