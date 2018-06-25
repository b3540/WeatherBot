﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherClient
{
    public class OpenWeather
    {
        public async Task<string> GetWeather()
        {
            using (var client = new HttpClient())
            {
                // http://samples.openweathermap.org/data/2.5/forecast?id=524901&appid=b1b15e88fa797225412429c1c50c122a1
                var response = await client.GetAsync(requestUri: $"https://api.openweathermap.org/data/2.5/weather?q=London,uk&appid={OpenWeatherConfig.AppId}");

                // もし、リクエストが失敗していたら
                if (!response.IsSuccessStatusCode)
                {
                    return null; // 取り敢えずnull返しておく
                }

                // レスポンスのbodyが取れる
                var json = await response.Content.ReadAsStringAsync();

                return json;
            }
        }
    }
}