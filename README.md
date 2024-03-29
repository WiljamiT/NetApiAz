# .NET Core Web API

**start**: `docker-compose up`

[.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0) 
deployed on 
[Azure App Service](https://azure.microsoft.com/en-us/products/app-service).

- **API Base URL**: `XXX.azurewebsites.net`

## API Endpoints

### Weather Forecast

#### Get Weather Forecast

- **Endpoint**: `/WeatherForecast`
- **Method**: GET
- **Description**: Retrieve the weather forecast data.

### Customer Operations

#### Get Customers

- **Endpoint**: `/api/Data/customers`
- **Method**: GET
- **Description**: Retrieve a list of customers.

#### Add Customer

- **Endpoint**: `/api/Data/addcustomer`
- **Method**: POST
- **Description**: Add a new customer to the db.
- **Request Body**:
  ```json
  {
    "FirstName": "Jaakko",
    "LastName": "Teppo",
    "Email": "Jaska.Tepi@example.com"
  }
  ```

#### Delete Customer

- **Endpoint**: `/api/Data/deletecustomer/{id}`
- **Method**: DELETE
- **Description**: Remove customer from the db.
- **Parameters**: {id} (int): ID of the customer to be removed.

#### Update Customer

- **Endpoint**: `/api/Data/updatecustomer/{id}`
- **Method**: PUT
- **Description**: Update the details of an existing customer.
- **Parameters**: {id} (int): ID of the customer to be updated.
- **Request Body**:
  ```json
  {
    "FirstName": "Jaska",
    "LastName": "Tepi",
    "Email": "Jaska.Tepi123@example.com"
  }
  ```
## CORS Configuration

The API is configured to allow cross-origin requests from specific domains.

- **Allowed Origins**:
  - `http://localhost:3000` (for local development)
  - `https://XXX.azurewebsites.net` (for production)
