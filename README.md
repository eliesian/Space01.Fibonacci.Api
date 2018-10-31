### Space01.Fibonacci.Api
Test task for C# .Net Backend Developer

#### Setup Instructions
1) Clone the repo
2) Edit MsSqlConnectionString in the the appsettings.json file 
3) Build the solution using: ``` dotnet build ```
4) Change directory to Space01.Fibonacci.ApixSpace01.Fibonacci.Api and run the api using: ```dotnet run```
5) Navigate a browser to http://localhost:53235/api/fibonacci/1/1 This request will build and populate the database and return the first fibonacci number.

#### Usage
The last two numbers in the URL are the first and last numbers in a range. By default there are 10000 fibonacci numbers are generated on startup, so the following requests are possible:
* http://localhost:53235/api/fibonacci/1/1 - returns the first fibonacci number
* http://localhost:53235/api/fibonacci/1000/1000 - returns the 1000th fibonacci number
* http://localhost:53235/api/fibonacci/1/100 - returns the first 100 fibonacci numbers
* http://localhost:53235/api/fibonacci/3000/4000 - returns 1000 fibonacci numbers between 3000 and 4000
* http://localhost:53235/api/fibonacci/10000/10000 - returns the 10000th fibonacci number
* and so on

#### Demo
A demo version with 10000 generated fibonacci numbers is available at: https://fibonacci.azurewebsites.net/api/fibonacci/1/100

