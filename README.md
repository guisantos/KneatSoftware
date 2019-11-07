# Kneat Software Test
>Version 1.0

The purpose of this project is to calculate the amount of stops to resupply each starships from Star Wars would take to make the distance from planets.

Solution will take as input the distance in MGLT (Mega Lights), and calculate it using the MGTL/hour and the time the starship can travel without the need to resupply.

>**FORMULA:** STOPS = (Distance / (MGLT * Consumables in hours))
>
>Distance - User input in MGLT
>
>MGLT - Starship MGLT (distance starship can travel in an hour)
>
>Consumables in hours - Starship Consumables can be in days, weeks, months or years. We need convert then to hours before calculate

# Output example
**Distance(MGLT): 1000000**

| Starship | Stops |
|:---: |:--:|
| Y-wing | 74 | 
| Millennium Falcon | 9 | 
| Rebel Transport | 11 | 

# Nuget Packages
The library **[Newtonsoft.Json (12.0.2)](https://www.newtonsoft.com/json)** was used to parse JSON to C# Object.

For the Unit Tests the open source library **[xUnit (2.4.0)](https://xunit.net/)** was used.

Both of them are included in the project solution, so Visual Studio will restore then for you, if it doesn't happen, go to **Tools** > **Nuget Package Manager** > **Manage Nuget Package for Solution** and install from there.

# **Requirements**
1. Visual Studio 2017 or higher (or vscode with plugins)
2. Microsoft .NET Core 2.2
3. Internet Connection

# **Solution Architect**
The solution is divided in 6 different projects:
1. Kneat.Application
   
   The startup project, receives the input and delivery the output.
2. Kneat.Business
   
   Responsable for the business of the application, calculate the amount of stops, convert starship consumables to hours, validate the input and if the starship consumables is right.
3. Kneat.Domain
   
   Responsable for the class models Starship and StarshipHeader which are a mirror of the JSON received from the API.
4. Kneat.Helper
   
   Where are the Custom Exceptions and also an Extension class with strings that are used across the application.
5. Kneat.Services
   
   Layer where the application request the starships from the API.
6. Kneat.Tests
   
    Where are the Unit Tests, tests are spplited in three different classes, ApiTest, MGLTTest and InputTest.

# How to use
1. Git clone https://github.com/guisantos/KneatSoftware.git
2. Open Kneat.sln
3. Press F5 or Build the application
4. Wait for the build process and a console will open

Application ask you to input the distance in Mega light

![input]

Now, connect to the webservice [SWAPI](https://swapi.co/)

![webservice]

And finally you get the output, a list of starships and the amount of stops.

![output]

After that you can choose to close the application or input another distance.

# Kneat.Tests Layer
Here you can find all the tests, there're 12 different available tests, convering the code from the user point to the output.

![tests]

>You can access this menu by going to **Test** > **Windows** > **Test Explorer**

I've made an extensive use of the powerful xUnit library, in order to get the most code coverage and also different cenarios to test.

## Example:
**ConvertConsumablesToHoursTest** receive 3 different cases to test, each one with differente consumables that're available in the API.

**ConsumableWrongFormatTest_ShouldThrowConsumableWrongFormatException** is used to test if the method used to validate the Starship consumables are correct. In this case we pass a wrong consumable and we excepct to **Throw** the **ConsumableWrongFormatException** (which are in the Namespace *Kneat.Helper.CustomException*) 

![tests2]

-------------

[input]: <resources/input.JPG>
[webservice]: <resources/webservice.JPG>
[output]: <resources/output.JPG>
[tests]: <resources/tests.JPG>
[tests2]: <resources/tests2.JPG>
