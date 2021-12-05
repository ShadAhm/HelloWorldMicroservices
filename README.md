A application that can greet a planet

# The problem 

There is a need for an application with an ability to greet a planet. Default output:

```Hello, world!```

1. This message should be received by anyone within a planet. For practicality, this application needs to reach to as wide an audience base as possible. It should NOT be designed to require individual installations on user machines. Access should be possible without authentication/authorization. 
1. The `Hello` portion of the message should not make any assumption on cultures. While "Hello" is a reasonable default, the application should be extensible to support any other type of greeting such a `hola` and `hai`.
1. The `World` portion of the message should not make any assumption on planets. We should possibly be able to deploy this application on other planets without needing to modify the code. 
1. Whenever possible, refer to a planet as their endonym. E.g: do not use "Earth" when addressing planet Earth as "world" is the preferred name for the locals.

# The solution

HelloWorldMicroservices is a distributed-system application. It consists mainly of the front-end web app, and two microservices - Greetings API and Planets API. An API gateway sits between the front-end and web services.



## Technologies used:

| Service      | Technologies |
| ----------- | ----------- |
| Front-end      | [Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0)       |
| API Gateway   | [Ocelot](https://github.com/ThreeMammals/Ocelot)        |
| Greetings API  | [ASP.NET Core Minimal API](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)        |
| Planets API   | ASP.NET Core        |

# Limitations

## Inter-planetary support

This application is designed with the assumption that the server will always be deployed on the same planet as it's users. Due to the current known limits of information speed, we do not think it would be practical for a message to travel through space to another planet.

Therefore it is recommended that a new instance of this application is installed for all planets that needs it, each instance should then only serve local requests. Maintainers of Planets API can use `planets.json` to commit information of new planets to the codebase, and then use `appsettings.json` to point to the host planet.

## Persistence storage

We currently use Planet API's `planets.json` file to store the list of planets currently inhabited by humans. As this is a small list that is expected grow slowly, we do not think any high-capacity persistance storage is necessary.

However if human civilisation expansion is ramping up an alarming rate, we might need to change it. Please create an issue when that happens.