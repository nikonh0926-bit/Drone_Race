using System.Text.Json;

public class GetWeatherStatus
{
    

    public async static Task<double> GetWeather(string endpoint, HttpClient client)
    {
        try 
        {
            var response = await client.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(content);

            JsonElement root = document.RootElement;

            JsonElement timeseries = root
                .GetProperty("properties")
                .GetProperty("timeseries");

            JsonElement firstForeCast = timeseries[0];

            JsonElement details = firstForeCast
                .GetProperty("data")
                .GetProperty("instant")
                .GetProperty("details");

            double windSpeeds = details
                .GetProperty("wind_speed")
                .GetDouble();

            double rain = firstForeCast
                .GetProperty("data")
                .GetProperty("next_1_hours")
                .GetProperty("details")
                .GetProperty("precipitation_amount")
                .GetDouble();

            return SelectMultiplier(windSpeeds, rain);
        }

        // api error
        catch (HttpRequestException)
        {
            return 5;
        }
        // client timeout
        catch (TaskCanceledException)
        {
            return 5;
        }
        // format exception
        catch (JsonException)
        {
            return 5;
        }
    }

    static double SelectMultiplier(double windSpeed, double rain)
    {
        double windSpeedMultiplier = windSpeed 
        switch
        {
            >= 10 => 2.0,
            >= 3  => 1.5,
            _     => 1.0
        };
        double rainMultiplier = rain
        switch
        {
            >= 15 => 2.0,
            >= 8  => 1.5,
            _     => 1.0
        };

        return rainMultiplier * windSpeedMultiplier;
    }
    
}