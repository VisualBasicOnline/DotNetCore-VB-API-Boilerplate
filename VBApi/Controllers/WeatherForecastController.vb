Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Logging 

<ApiController>
<Route("[controller]")>
Public Class WeatherForecastController
    Inherits ControllerBase

    Private Shared ReadOnly Summaries As String() =
                                {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
                                 "Scorching"}

    Private ReadOnly _logger As ILogger(Of WeatherForecastController)

    Public Sub New(ByVal logger As ILogger(Of WeatherForecastController))
        _logger = logger
    End Sub

    <HttpGet("GetWeatherForecast")>
    Public Function GetForecast() As IEnumerable(Of WeatherForecastViewModel)

        Return Enumerable.Range(1, 5).
            Select(
                Function(index) New WeatherForecastViewModel With 
                      {
                      .ForecastDate  = DateTime.Now.AddDays(index),
                      .TemperatureC = Random.Shared.Next(- 20, 55),
                      .Summary = Summaries(Random.Shared.Next(Summaries.Length))
                      }
                ).ToArray()
    End Function
End Class
