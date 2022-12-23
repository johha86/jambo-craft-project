# Jambo Craft Project
[![Web API CI/CD](https://github.com/johha86/jambo-craft-project/actions/workflows/develop_trip-planner-api20221220213642.yml/badge.svg?branch=develop)](https://github.com/johha86/jambo-craft-project/actions/workflows/develop_trip-planner-api20221220213642.yml)

[![SPA CI/CD](https://github.com/johha86/jambo-craft-project/actions/workflows/azure-static-web-apps-brave-island-061325510.yml/badge.svg?branch=develop)](https://github.com/johha86/jambo-craft-project/actions/workflows/azure-static-web-apps-brave-island-061325510.yml)
## Project Description
This project is the solution for the Jambo test challenge. The main idea is using any frontend web technology with a simple backend, build a single page travel planner application.
The proposal for this test are two projects. A web application developed in Angular to present UI user, and an API backend that receive the request to populate the frontend data.

## Demo
To see the result in action just click in the following [link](https://brave-island-061325510.2.azurestaticapps.net/).

## Technologies
The following list represent the list of the tech stack for this project:
* .NET 6
* C# 10.0
* Angular 13
* ng-bootstrap
* Docker
* Automapper
* MongoDB
* Polly(Resillence library)
* xUnit
* Moq(Mocking library)

## Folders Structure
Inside the folder **trip-planner-solution** you will find the following folders:
* **infra** Contains the files for the database seeding.
* **src**   Contains the projects files for the web api,web app.
* **test**  Contains the unit tests for the web api

Also in the root folder are the docker composer files, gitignore and other files.

## How to Debug it
### Without Docker composer
1. Open the trip-planner-solution.sln files with Visual Studio.
2. Run the project trip-planner-api
3. Open a terminal and go to the folder **src\ClientApp**
4. Run **npm install**
5. Run **npm start**

### With Docker composer
1. Go to the root folder and open a terminal in this location.
2. Run docker compose up

## Project Highlight
The front end is a simple SPA based in Angular. It only contains one component to represent the data.

The back end is a .NET web api. This contains the main controller that accepts the requests from the front end. The architecture is in layers. In the bussines layer is the provider for the information necessary for the controller and the Data Access layer contains the repositories that provide the data with the information for the cities and the weather forcast.

Also, exist a background service to simulate the process of retrieve the weather forcast information from an external place. The idea is to have this execution in background retrieving the information and save it into the proper city.

Because everything ultimately fails, it was used a resillence mechanism to do retry actions.

Some unit tests where included in the solution. This unit test demostrate the use of Moq and Inline Data.

## Deployment
The project is currently deployed into Azure Cloud Provider. It use Azure Web App for the web api, and azure static web app for the SPA. Both are grouped in the same resource group and using the Free Tier to avoid charges.
The local environment use MongoDB to persist the information used, however it wasn't created any infrastructure for the database in the cloud.

## CI/CD
The static web app service was created to use Github Actions. Thanks to this, every push action on develop branch will trigger a new develop on this service.

The web app service also was configured to do a new deployment if a new push happens in develop branch.

## Further Improvements
* Implement the logic to connect to an external weather forcast service.
* Implement Mongo Realm for the schemas versioning.
* Change the Entity Id to GUID.
