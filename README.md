# GlasgowAstro.Obsy
A .NET Core Discord bot and API for retrieving asteroid orbit data from the Minor Planet Center. A work in progress!

## Status
Pre-alpha

##
- https://www.instagram.com/glasgowastro
- https://glasgowastro.co.uk

## Projects
- GlasgowAstro.Obsy.Service - Contains various services to retrieve MPC data.
- GlasgowAstro.Obsy.Api - API with endpoints calling upon the asteroid services.
- GlasgowAstro.Obsy.Bot - A Discord bot with commands to retrieve MPC data via the Obsy API.
- GlasgowAstro.Obsy.Tests - Unit and integration tests for the Obsy API and its services.
- [POC. Not currently in use] GlasgowAstro.Obsy.DataGrabber - Azure Function with TimerTrigger to download MPC's asteroid orbits and parameters and store it.
- [POC. Not currently in use] GlasgowAstro.Obsy.Data - DAL with generic repository to perform CRUD operations against MongoDb.
