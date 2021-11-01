using ClientLib.API;
using Database;
using System;
using System.Collections.ObjectModel;

namespace Interface.ClientUI.ViewModels
{
    public class ExchangeCurrencyViewModel : BaseViewModel
    {
        
        public ExchangeCurrencyViewModel()
        {
            CurrencyYearList = ApiService.GetYearExchangeRates();
            CurrencyMonthList = ApiService.GetMonthExchangeRates(DateTime.Now.Month);

            ActualCurrency = ApiService.GetLatest();
            baseMultiplier = ActualCurrency.Ron;
            Ron = ActualCurrency.Ron;
            Euro = ActualCurrency.Euro;
        }

        public void UpdateMonthList(int month)
        {
            CurrencyMonthList = ApiService.GetMonthExchangeRates(month);
        }

        private ObservableCollection<ExchangeCurrency> _currencyYearList;
        public ObservableCollection<ExchangeCurrency> CurrencyYearList
        {
            get => _currencyYearList;
            set => _currencyYearList = value;
        }

        private ObservableCollection<ExchangeCurrency> _currencyMonthList;
        public ObservableCollection<ExchangeCurrency> CurrencyMonthList
        {
            get => _currencyMonthList;
            set => _currencyMonthList = value;
        }

        private decimal baseMultiplier;

        private ExchangeCurrency _actualCurrency;
        private ExchangeCurrency ActualCurrency
        {
            get => _actualCurrency;
            set => _actualCurrency = value;
        }

        private decimal _ron;
        public decimal Ron
        {
            get => _ron;
            set
           {
                _ron = value;
                ActualCurrency.Ron = _ron;
            }
        }

        private decimal _euro;
        public decimal Euro
        {
            get => _euro;
            set
            {
                _euro = value;
                Ron = _euro * baseMultiplier;
                ActualCurrency.Euro = _euro;
            }
        }
    }
}
