using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;

namespace ClientLib.API
{
    public class ApiService
    {
        public static ObservableCollection<ExchangeCurrency> GetYearExchangeRates()
        {
            try
            {
                using (Service.ServiceClient service = new Service.ServiceClient())
                {
                    return service.GetYearExchangeRate();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ObservableCollection<ExchangeCurrency> GetMonthExchangeRates(int month)
        {
            try
            {
                using (Service.ServiceClient service = new Service.ServiceClient())
                {
                    return service.GetMonthExchangeRate(month);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ObservableCollection<Api_Object> Load()
        {
            try
            {
                using (StreamReader r = new StreamReader(@"D:\ExchangeCurrency2021.json"))
                {
                    string json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<ObservableCollection<Api_Object>>(json);

                    return items;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ObservableCollection<ExchangeCurrency> LoadAsExchangeCurrency()
        {
            try
            {
                using (StreamReader r = new StreamReader(@"D:\ExchangeCurrency2021.json"))
                {
                    string json = r.ReadToEnd();
                    var items = Load();

                    ObservableCollection<ExchangeCurrency> exchangeCurrencies = new ObservableCollection<ExchangeCurrency>();
                    foreach(Api_Object api in items)
                    {
                        ExchangeCurrency temp = new ExchangeCurrency
                        {
                            Date = DateTime.Parse(api.date),
                            Euro = (decimal)api.rates.EUR,
                            Ron = (decimal)api.rates.RON
                        };

                        exchangeCurrencies.Add(temp);
                    }

                    return exchangeCurrencies;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Api_Object Create(string date)
        {
            try
            {
                String URLStringTime = "http://api.exchangeratesapi.io/v1/" + date + "?access_key=2c52cd24471429729d11dffd07b84580&base=USD";
                using (WebClient client = new WebClient())
                {
                    var downloadJson = client.DownloadString(URLStringTime);
                    var json = JsonConvert.SerializeObject(downloadJson, Formatting.Indented);
                    Api_Object api = JsonConvert.DeserializeObject<Api_Object>(downloadJson);

                    return api;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ExchangeCurrency GetLatest()
        {
            try
            {
                using (Service.ServiceClient service = new Service.ServiceClient())
                {
                    ExchangeCurrency exchange  = service.GetLastExchangeRate();
                    DateTime currentDate = DateTime.Now;

                    if (exchange.Date != currentDate.Date)
                    {
                        Api_Object api = DownloadLatest();
                        ExchangeCurrency newExchange = new ExchangeCurrency
                        {
                            Date = DateTime.Parse(api.date),
                            Euro = (decimal)api.rates.EUR,
                            Ron = (decimal)api.rates.RON
                        };

                        if (service.UpdateExchangeRate(newExchange))
                        {
                            return newExchange;
                        }
                        else
                            return null;
                    }

                    return exchange;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static Api_Object DownloadLatest()
        {
            try
            {
                String URLString = "http://api.exchangeratesapi.io/v1/latest?access_key=2c52cd24471429729d11dffd07b84580";

                using (WebClient client = new WebClient())
                {
                    var downloadJson = client.DownloadString(URLString);
                    var json = JsonConvert.SerializeObject(downloadJson, Formatting.Indented);
                    Api_Object api = JsonConvert.DeserializeObject<Api_Object>(downloadJson);

                    return api;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
