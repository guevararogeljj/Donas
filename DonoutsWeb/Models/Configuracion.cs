using Donouts.Application.Dto.Donouts;

namespace DonoutsWeb.Models
{
    public class Configuracion
    {
        public List<SalesDonoutsDTO> salesDonouts  { get; set; }  = new List<SalesDonoutsDTO>();
        public List<String> SelectedProductsFilter { get; set; } = new List<String>();
    }
}
