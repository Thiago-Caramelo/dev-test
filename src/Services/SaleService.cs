using System.Collections.Generic;
using Domain.Sale;
using Infra;

namespace Services
{
    public class SaleService
    {
        IRepository _repository;
        public SaleService(IRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ISale> GetActiveSales() {
            foreach (var sale in _repository.GetActiveSales())
            {
                switch (sale.SaleType)
                {
                    case SaleType.ExtraCheese:
                        yield return new ExtraCheese();
                    break;
                    case SaleType.ExtraHamburger:
                        yield return new ExtraHamburger();
                    break;
                    case SaleType.LighSale:
                        yield return new LightSale();
                    break;
                }
            }
        }
    }
}