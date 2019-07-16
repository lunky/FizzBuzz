# FizzBuzz

### Prerequisites
Whether you’re using Windows, OS X, or Linux, you can follow this example 
by using either an IDE and its build tools, or by using the the [.NET Core SDK command line tools](https://dotnet.microsoft.com/download).

### Build and run
Then you can either run from source or compile. Running from source is straightforward:

    dotnet run

Compiling to IL is done using:

    dotnet build

This will drop an IL assembly in `./bin/[configuration]/[framework]/[binary name]`
that you can run using `dotnet bin/[configuration]/[framework]/[binaryname.dll]`.

For more details, refer to the [documentation](https://aka.ms/dotnet-cli-docs).

### Building from source

If you are building from source, take note that the build depends on NuGet packages hosted on MyGet, so if it is down, the build may fail. If that happens, you can always see the [MyGet status page](http://status.myget.org/) for more info.

### Questions and comments

For all feedback, use the Issues on this repository.
