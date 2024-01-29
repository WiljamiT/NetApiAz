# .NET Core Web API

.NET Core Web API deployed on Azure App Service.

- **API Base URL**: `XXX.azurewebsites.net`

## API Endpoints

### Weather Forecast

#### Get Weather Forecast

- **Endpoint**: `/WeatherForecast`
- **Method**: GET
- **Description**: Retrieve the weather forecast data.

## CORS Configuration

The API is configured to allow cross-origin requests from specific domains.

- **Allowed Origins**:
  - `http://localhost:3000` (for local development)
  - `https://XXX.azurewebsites.net` (for production)
