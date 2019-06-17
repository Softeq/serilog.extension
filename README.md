![Azure DevOps builds](https://dev.azure.com/eugenypetlakh/serilog.extension/_apis/build/status/Softeq.serilog.extension?branchName=master)
![NuGet](https://img.shields.io/nuget/v/Softeq.Serilog.Extension.svg)

# Serilog extention

Netstandard exntetions for Serilog. Use to collect logs and to monitor application.

## Usage
Handle exception in middleware:
1. Log error
```csharp

            _logger.Event("UnhandledExceptionCaughtByMiddleware")
                   .With.Exception(ex)
                   .Message("Exception was caught by exception handling middleware. Status code = {StatusCode}; error code = {ErrorCode}", statusCode, errorCode)
                   .AsError();
```
2. Log fatal
```csharp
            _logger.Event("UnhandledExceptionCaughtByMiddleware")
                .With.Exception(ex)
                .Message("Exception was caught by exception handling middleware. Status code = {StatusCode}; error code = {ErrorCode}", statusCode, errorCode)
                .AsFatal();
```
3. Log information
```csharp
          _logger.Event("Information")
                .With.Message(" Status code = {StatusCode}; error code = {ErrorCode}", statusCode, errorCode)
                .AsInformation();
```
4. Log debug
```csharp
           _logger.Event("Debug information")
                .With.Message("{StatusCode}; error code = {ErrorCode}", statusCode, errorCode)
                .AsDebug();
````

## Configuration

Serilog section in appsettings.json

```json
"Serilog": {
    "MinimumLevel": "Debug",
    "ApplicationName": "Softeq.NetKit.Chat",
    "FileSizeLimitMBytes": 100,
    "EnableLocalFileSink": "True"
  }
```
## About

This project is maintained by [Softeq Development Corp.](https://www.softeq.com/)
We specialize in .NET core applications.

 - [Facebook](https://web.facebook.com/Softeq.by/)
 - [Instagram](https://www.instagram.com/softeq/)
 - [Twitter](https://twitter.com/Softeq)
 - [Vk](https://vk.com/club21079655).

## Contributing

We welcome any contributions.

## License

The Serilog extention project is available for free use, as described by the [LICENSE](/LICENSE) (MIT).
