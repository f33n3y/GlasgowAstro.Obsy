# GlasgowAstro.Obsy
.NET solution to get the Minor Planet Center's asteroid orbit data and make it available via an API. A work in progress!

## Status
Pre-alpha

##
- https://www.instagram.com/glasgowastro
- https://glasgowastro.co.uk

## Projects
- GlasgowAstro.Obsy.DataGrabber - AzureFunction with TimerTrigger to download and decompress MPCs data and store it.
- GlasgowAstro.Obsy.Data - Generic repository to perform CRUD operations against MongoDb.
- GlasgowAstro.Obsy.Api - WebApi with endpoints to query stored MPC data.
- GlasgowAstro.Obsy.Bot - Discord bot
