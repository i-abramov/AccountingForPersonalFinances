using AccountingForPersonalFinances.Application.Common.Mappings;
using AccountingForPersonalFinances.Domain.Models;
using AutoMapper;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses
{
    public class ExpenseLookupDto : IMapWith<Transaction>
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transaction, ExpenseLookupDto>()
                .ForMember(transactionDto => transactionDto.ID,
                    opt => opt.MapFrom(transaction => transaction.ID))
                .ForMember(transactionDto => transactionDto.Date,
                    opt => opt.MapFrom(transaction => transaction.Date))
                .ForMember(transactionDto => transactionDto.Amount,
                    opt => opt.MapFrom(transaction => transaction.Amount))
                .ForMember(transactionDto => transactionDto.Description,
                    opt => opt.MapFrom(transaction => transaction.Description));
        }
    }
}