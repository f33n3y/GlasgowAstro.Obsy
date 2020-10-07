# GlasgowAstro.Obsy
.NET Core solution to get the Minor Planet Center's asteroid orbit data and make it available via Discord Bot & API. A work in progress!

## Status
Pre-alpha

##
- https://www.instagram.com/glasgowastro
- https://glasgowastro.co.uk

## Projects
- GlasgowAstro.Obsy.DataGrabber - Azure Function with TimerTrigger to download MPC's data and store it.
- GlasgowAstro.Obsy.Data - DAL with generic repository to perform CRUD operations against MongoDb.
- GlasgowAstro.Obsy.Service - Contains asteroid service which calls repository to retrieve MPC data.
- GlasgowAstro.Obsy.Api - API with endpoints calling the asteroid service.
- GlasgowAstro.Obsy.Bot - A Discord bot with commands to retrieve MPC data via the Obsy API

Bot -> API -> Service -> Data
