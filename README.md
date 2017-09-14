# ASP.NET Core 2.0 SignalR Basic Demo App

This application is a very basic working demonstration of using the ASP.NET Core 2.0 version of SignalR with an ASP.NET Core Razor Pages web application.
The aim of the demo app is to show the basic configuration and manual steps required to get the solution working.

## Getting Set Up

### Before the solution will build you need to obtain the SignalR NuGet Package

The solution contains the Microsoft.AspNetCore.SignlarR (1.0.0-alpha1-26969) NuGet package.  This can be obtained using the following steps:

##### Set up a new package source so it's possible to obtain the alpha .NET Core versions of SignalR
-  Open the NuGet Package Manager Sources Dialogue (Tools > NuGet Package Manager > Packages Manager Settings, then select Package Sources)
-  Click the [+] button next to Available Package Sources to add a new package source
-  A new entry is created named "Package source", edit the name to something more friendly, e.g. .NET Core Alpha Packages
-  Set the source to: https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json
-  Then click "Update" to save your new package source

##### Adding the SignalR package to the solution
-  Open NuGet Package Manager as normal, on the right side change the "Package Source" setting to the one you just added.  Now when you search for SignalR you should be able to find the above AspNetCore.SignalR package.

### Obtaining the SignlarR Client
The SignalR javascript client was obtained crudely using node package manager.  It's already included in the `wwwroot/lib/signalr` folder so you don't need to do anything to get the file, however, below are the steps you can follow if you want to obtain the js file yourself.

Open up the Node.js command prompt and navigate to the solution directory.
Run these commands
```
npm install msgpack5
npm install @aspnet/signalr-client --registry https://dotnet.myget.org/f/aspnetcore-ci-dev/npm/
```
Navigate into the `node_modules` folder and drill down through `@aspnet` > `signalr-client` > `dist` > `browser` and grab out the signalr-client.js (or .min.js version).
This file can then be added to the solution.

I'm aware this is not how to use a package manager properly, but I just can't be dealing with all this package manager rubbish just to get a javascript file - It's probably my ignorance, sorry!!

### .Net Core 2.0
If you haven't already ensure you've got .Net Core 2.0 installed
https://www.microsoft.com/net/download/core


## What's What

The `Hubs` folder contains a simple `DemoHub` class

The `startup.cs` file contains the basic configuration to get things kicked off, e.g.
```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSignalR();
        }
```
and
```
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWebSockets();
            app.UseSignalR(builder =>
                builder.MapHub<DemoHub>("demo")
            );
		// remaining configuration code follows...
```

The `Pages` folder contains the Index.cshtml file with the necessary example Javascript to wire up the client side

The `wwwroot/lib/signalr` directory contains the client side javascript file.

That's basically it.

NOTE: This Index.cshtml.cs Razor PageModel that sits under the Index.cshtml file also includes some additional, non essential code, to show a rough example of kicking off a SignalR event from the server to clients.


## Windows 7 Warning!
If you run this demo on a Windows 7 PC, which means IIS Express doesn't support WebSockets, you may need to force the transport mode to be `ServerSentEvents` on line 25 of the Index.cshtml file.

## Disclaimer
I am completely new to using SignalR, so apologies if this demo implements any bad practices!!  It's one of those technologies I've been aware of for years but just never got around to trying out.
