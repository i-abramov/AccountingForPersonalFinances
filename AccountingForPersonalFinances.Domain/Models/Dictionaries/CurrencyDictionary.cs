using System.Collections.ObjectModel;

namespace AccountingForPersonalFinances.Domain.Models.Dictionaries
{
    public static class CurrencyDictionary
    {
        public static readonly IReadOnlyDictionary<string, string> All =
        new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>
            {
                { "Рубль", "RUB" },
                { "Доллар США", "USD" },
                { "Евро", "EUR" },
                { "Фунт стерлингов", "GBP" },
                { "Японская иена", "JPY" }
            });
    }
}