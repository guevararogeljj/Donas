using System.Net.Http.Json;
using System.Text.Json;
using Donouts.Application.Dto.Donouts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;


namespace Donuts.Api.Test;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        GetAllDonouts.GetAllApi api = new GetAllDonouts.GetAllApi();
        HttpClient client = api.CreateClient();
        SalesDonoutsDTO dto = new SalesDonoutsDTO();
        JsonContent dtoJson = JsonContent.Create(dto);
        var response = await client.GetAsync("https://localhost:7293/api/v1/SalesDonouts/GetAll");
        
        Assert.NotNull(response);
    }
}