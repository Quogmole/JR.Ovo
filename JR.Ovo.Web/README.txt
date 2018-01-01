This solution has been created in Visual Studio 2017 Community edition

I have used WebApi to retrieve the data from the Ovo Api. The solution uses a controller that consumes a service to return the data. Dependency injection is provided by Microsoft Unity.

The front end is a simple html page that uses javascript / jquery to call the api and print the results. 
In a real solution, the front end would be developed further and have separate css and script files. 
The front end is completely independent from the rest of the solution.

The results of the api calls can be hit at http://localhost:62701/api/customer for all results and http://localhost:62701/api/customer/be1d35af-6020-4445-9451-f13facfcfc9a to get a single result.

I have added a simple unit test to check that the data is handled by the controller as expected.

To run the solution:

Load project in visual studio
Restore NuGet packages if required
Hit f5 to run in browser
