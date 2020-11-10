using CBR_Currency.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CBR_Currency.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        public CurrenciesResponse Get(int page = 1)
        {
            using DbCurrencyContext db = new DbCurrencyContext();

            // количество записей на странице
            int pageSize = 5;

            IQueryable<Currency> src = db.Currencies;
            int cnt = src.Count();                      // всего записей в таблице
            int pageCnt = cnt / pageSize;               // всего страниц
            if (cnt % pageSize != 0) pageCnt++;

            return new CurrenciesResponse()
            {
                Count = cnt,
                Pages = pageCnt,
                CurrentPage = page,
                Valute = src.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
        }


        [Route("/currency")]
        public Currency GetById(string id = "R01235")
        {
            using DbCurrencyContext db = new DbCurrencyContext();
            return db.Currencies.Find(id);
        }
    }
}
