using Core.Models;
using Newtonsoft.Json;
using System.Text;
using System;

namespace App;

public interface IService
{
    Task PostAsync(List<AddTelemetryViewModel> telemetries);
}


public class Service : IService
{
    public async Task PostAsync(List<AddTelemetryViewModel> telemetries)
    {
        using var _httpClient = new HttpClient();

        string baseUrl = "http://localhost:5001";
        string url = baseUrl + "/api/devices/1/telemetry";
        var json = JsonConvert.SerializeObject(telemetries);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, data);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Data sent!");
            return;
        }
        
        throw new Exception(response.StatusCode.ToString());
    }
}