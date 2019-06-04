Codding challenge
---------------

Codding challenge is a simple application to showcase my skills in web development using dotnet core as backend and angular as front and sqlite as database .

Functional spec
---------------
- As a User, I can sign up using my email & password
- As a User, I can sign up using my email & password
- As a User, I can sign in using my email & password
- As a User, I can logout
- As a User, I can display the list of shops sorted by distance
- As a User, I can like a shop, so it can be added to my preferred shops
 - Liked shops shouldn’t be displayed on the main page

- As a User, I can dislike a shop, so it won’t be displayed within “Nearby Shops” list during the next 2 hours
- As a User, I can display the list of preferred shops
- As a User, I can remove a shop from my preferred shops list

Software Design
---------------
- The Front layer represents the UI of application.
- The Business  Layer is totally independent of other layers and frameworks contains specific business rules. It encapsulates and implements all of the use cases of the application.
- The Persistance Layer provides implementations for the Business needs .
- The API Layer expose endpoints that can be used in the front layer .

Setup environment
---------------
### Requirement 
Install the following, before starting : 

* [dotnet core 2.2](https://dotnet.microsoft.com/download)
* [NodeJS](https://nodejs.org)
### Development

#### DataBase 
sqlite database is already created and populated with data for testing, and is commited under the folder 5-Data/SQLiteDataBase
#### Backend

To install backend project dependencies, point to API folder:
```
cd [project-folder]/02-API/CodingChallengeAPI
```
then run :

dotnet restore
The backend is now ready to be launched via

```
dotnet run
```

#### FrontEnd 

To install frontend project dependencies, point to 01-Front/Coding-Challenge/ folder:

```
cd [project-folder]/01-Front/Coding-Challenge/
```
then run :
```
npm install
```
The front  is now ready to be launched via :
```
ng serve
```

### Production
#### Backend
Open 2-API\CodingChallengeAPI\appsettings.Production.json
```
{
  "ApiSettings":{
    "MediaPath":"../../5-Data/img/"
  },
  "DataBaseSettings": {
    "ConnectionsString": "Data Source=../../5-Data/SQLitedatabase/CodingChallengeDataBase.db"
  }
}
```
specify mediaPath and connectionString

Open file 2-API\CodingChallengeAPI\Properties\launchSettings.json
```
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false, 
    "anonymousAuthentication": true, 
    "iisExpress": {
      "applicationUrl": "http://localhost:13109",
      "sslPort": 44348
    }
  },
  "profiles": {
    "CodingChallengeAPI": {
      "commandName": "Project",
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
and replace localhost with production url


To install backend project dependencies, point to API folder:
```
cd [project-folder]/02-API/CodingChallengeAPI
```
then run :

dotnet restore
The backend is now ready to be published via

```
dotnet publish
```

#### FrontEnd 

To install frontend project dependencies, point to 01-Front/Coding-Challenge/ folder:

```
cd [project-folder]/01-Front/Coding-Challenge/
```
then run :
```
npm install
```
The front  is now ready to be build via :
```
ng build
```
and copy filder dist in nginx html folder


































