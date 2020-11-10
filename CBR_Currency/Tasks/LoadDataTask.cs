using CBR_Currency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBR_Currency.Tasks
{

    // Задача выполняется фоном. Данные загружаются с сервера ЦБ и сохраняются.
    // Задача выполняется 1 раз в час.

    public class LoadDataTask : IHostedService, IDisposable
    {
        private const string CB_REQUEST_URL = @"https://www.cbr-xml-daily.ru/daily_json.js";

        private Timer _timer;

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public void Load(object state)
        {
            // Загрузка данных с сервера
            WebRequest request = WebRequest.Create(CB_REQUEST_URL);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // Здесь может быть вывод в лог или оповещение об ошибке...
                return;
            }


            // Чтение данных
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(response.CharacterSet));

            string readData = sr.ReadToEnd();

            JToken valute = JObject.Parse(readData)["Valute"];
            Currency[] currencies = valute.ToObject<Dictionary<string, Currency>>().Values.ToArray();


            // Добавление и обновление данных
            using (DbCurrencyContext context = new DbCurrencyContext())
            {
                foreach (Currency cur in currencies)
                {
                    if (context.Currencies.Any(e => e.ID == cur.ID))
                    {
                        context.Entry(cur).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(cur).State = EntityState.Added;
                    }
                }
                context.SaveChanges();
            }


        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Load, null, TimeSpan.Zero, TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
