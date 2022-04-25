# Digital Pizza API

## Stephen K. Davis
| Email | Website | Twitter | LinkedIn | GitHub |
|-------|---------|---------|----------|--------|
| [stephenkdavis@outlook.com](mailto:stephenkdavis@outlook.com) | [stephendavis.io](https://stephendavis.io/) | [StephenDavisIO](https://twitter.com/StephenDavisIO) | [StephenKyleDavis](https://www.linkedin.com/in/stephenkyledavis/) | [stephenkdavis](https://github.com/stephenkdavis) |

## Given Outline
We would like you to create a RESTful service using .NET Core 2+ to be consumed by a pizza delivery app.<br/>
This service should implement proper CRUD for an entity called "Order" - ideally using Entity Framework.<br/>
Feel free to create any other entities you see fit and use whatever libraries you'd like. Exercise your creativity!

## Technology Stack
This project was created using .NET 6. .NET 6 is the next major Long Term Support release from Microsoft. As .NET Core 3.1 will reach the End of Support on 3 December 2022, Microsoft is encouraging people to transition to .NET 6 for longer term support. The .NET support tables can be found [here](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core). This project also uses the local Microsoft SQL Server that is supported within Visual Studio.
<br/>
As .NET has built in Swagger UI support for Web APIs, I left this enabled. If this was to go to production and get utilized, Swagger UI must be disabled for security reasons.

## Run Instructions
1. Make sure you have .NET 6 installed. It can be found [here](https://dotnet.microsoft.com/en-us/download)
2. Clone this repository
3. Open the .sln project using Visual Studio 2022. It can be found [here](https://visualstudio.microsoft.com/vs/)
4. Restore the NuGet dependancy packages.
5. Run this command in the Developer PowerShell Terminal: `dotnet ef database update;` <br/>This sets up the local database using a migration script
6. Run using Visual Studio or press F5 on the keyboard (using default Visual Studio keybindings)

## Preset User Accounts
| Role | Username | Password | Bearer Token (expires on 16 April 2023) |
|------|----------|----------|--------------|
| Manager | manager@test.com | digitalpizza | `bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Im1hbmFnZXJAdGVzdC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJFbXBsb3llZSIsImV4cCI6MTY4MTY2MTUxMywiaXNzIjoiRGlnaXRhbCBQaXp6YSBBUEkifQ.HtM6YU5pa0bSaSV99XUhgoyqpsw-MetLbgqgzrRpodA` |
| Cook | cook@test.com | digitalpizza | `bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiMiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImNvb2tAdGVzdC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJFbXBsb3llZSIsImV4cCI6MTY4MTY2MTU1MCwiaXNzIjoiRGlnaXRhbCBQaXp6YSBBUEkifQ.DcbbLHalmvlkypSwn6lYqbMyLWFmIuRlXwtMQ5WzCNY` |
| Driver | driver@test.com | digitalpizza | `bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiMyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImRyaXZlckB0ZXN0LmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkVtcGxveWVlIiwiZXhwIjoxNjgxNjYxNTY2LCJpc3MiOiJEaWdpdGFsIFBpenphIEFQSSJ9.SQn43Qgj1zc6sN9kAIhTpLNDTb61OfYslwJFnlrYdhg` |
| Customer | customer@test.com | digitalpizza| `bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiNCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImN1c3RvbWVyQHRlc3QuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ3VzdG9tZXIiLCJleHAiOjE2ODE2NjE1ODEsImlzcyI6IkRpZ2l0YWwgUGl6emEgQVBJIn0.rUxObC6NW2jDHrH4aXCfslNfFV9NbuqW0Qjnfc1ED3Y` |

## API Routes
### Account
#### [HttpGet] - Details :lock:
This route requires a JWT passed through the header. This route will proceed to pull the user information from the database and return it as an array made up of various data transfer objects. This array contains the personal details of the user, the customer loyality rewards count (if customer is signed in), employee information (if employee is signed in), and their addresses associated with the account.

#### [HttpPost] - Create :unlock:
This route takes in a Customer data transfer object. It verifies the email address and phone number are available to be used in the database and creates the new customer. It returns a success or error message.

#### [HttpPost] - LogIn :unlock:
This route takes in a LogIn data transfer object. It searches the database for an account associated with the provided email address and password. If a match is found it creates a JSON Web Token and returns that token. If no match is found, it returns a BadRequest with a message saying no user found.

#### [HttpPut] - Update/Password :lock:
This route requires a JWT passed through the header. It also takes in a PasswordChange data transfer object. It verifies the two passwords in that dto, and proceeds to change the user password. It gets the user id number from the JWT in the header.

#### [HttpPut] - Update/Email :lock:
This route requires a JWT passed through the header. It also takes in an EmailAddress data transfer object. It gets the user id number from the JWT in the header. It verifies the email is not already in use by a different account. If the email is free, it updated the user account with that new email otherwise it return an error message.

#### [HttpPut] - Update/Phone :lock:
This route requires a JWT passed through the header. It also takes in a PhoneNumber data transfer object. It gets the user id number from the JWT in the header. It verifies the phone number is not already in use by a different account. It also checks to make sure the provided phone number meets the preset regex format. If the email is free, it updated the user account with that new email otherwise it return an error message.

#### [HttpDelete] - Delete :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also verifies the signed in user is a type "customer" as only customers can delete their accounts. It then proceeds to delete the records associated with that account, but does not remove the past orders of the provided account.

### Order
#### [HttpGet] - Retrieve :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also takes in an id number passed as a parameter. If the id number is less than 1, it returns an error message. It then proceeds to check the role type of the account signed in. If the account is of type "employee", this method will return the order details. If the account is of type "customer", it will check if that customer has an order matching the id number provided. If the order is associated with this customer, it will return the order, otherwise return an error.

#### [HttpGet] - History :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also checks the account type is "customer". It will return a list of all past orders to be displayed to the user. This list will contain the order id number, the timestamp and the total only.

#### [HttpPost] - Create :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also checks the account type is "customer". It takes in an Order data transfer object. This method then calculates the total of the order and records it to the associated tables in the database. It returns Ok with a success message or a BadRequest with an error message.

#### [HttpPut] - Update :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also checks the account type is "employee". It takes in a OrderUpdate data transfer object. It locates the order associated with the update, and sets the order status to the associated values. It also leaves an update message with the last associated activity.

#### [HttpDelete] - Delete :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also checks the account type is "employee" and the employee is a "manager" role. As only managers should be able to delete orders, this route checks the user has the necessary permissions. If so, the order id number that is passed in will be deleted from all associated tables. If the user does not have the necessary permissions, an error message will be returned.

### Pizza
#### [HttpGet] - Preset :unlock:
This route returns a list of all preset pizza combinations offered by the restaurant.

### Topping
#### [HttpGet] - List :unlock:
This route returns a list of all available toppings offered by the restaurant.

#### [HttpGet] - Categories :unlock:
This route returns a list of topping categories.

#### [HttpPost] - Create :lock:
This route requires a JWT passed through the header. It gets the user id number from the JWT in the header. It also checks the account type is "employee". It takes in a Topping data transfer object and saves the new topping to the database. It returns a success or error message.
