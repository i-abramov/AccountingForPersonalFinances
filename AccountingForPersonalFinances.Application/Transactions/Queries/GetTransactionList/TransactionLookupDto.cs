using AccountingForPersonalFinances.Application.Common.Mappings;
using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;
using AutoMapper;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList
{
    public class TransactionLookupDto : IMapWith<Transaction>
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transaction, TransactionLookupDto>()
                .ForMember(transactionDto => transactionDto.ID,
                    opt => opt.MapFrom(transaction => transaction.ID))
                .ForMember(transactionDto => transactionDto.Date,
                    opt => opt.MapFrom(transaction => transaction.Date))
                .ForMember(transactionDto => transactionDto.Amount,
                    opt => opt.MapFrom(transaction => transaction.Amount))
                .ForMember(transactionDto => transactionDto.Type,
                    opt => opt.MapFrom(transaction => transaction.Type))
                .ForMember(transactionDto => transactionDto.Description,
                    opt => opt.MapFrom(transaction => transaction.Description));
        }
    }
}