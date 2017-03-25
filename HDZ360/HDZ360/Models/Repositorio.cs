using HDZ360.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HDZ360.Models
{
    public class Repositorio
    {
        public async Task<List<Imovel>> GetImoveis()
        {
            var Service = new Services.AzureService<Imovel>();
            var Items = await Service.GetTable();
            return Items.ToList();
        }
    }
}
