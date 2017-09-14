# ASP.NET Core 2.0 SignalR Basic Demo App

This application is a very basic working demonstration of using the ASP.NET Core 2.0 version of SignalR with an ASP.NET Core Razor Pages web application.
The aim of the demo app is to show the basic configuration and manual steps required to get the solution working.

## Windows 7 Warning!
This demo app was built on a Windows 7 PC, which means IIS Express doesn't support WebSockets, as such I forced the transport mode to be `ServerSentEvents` on line 25 of the Index.cshtml file.  Most people will want to change that back to Websockets - if I've understood things correctly the SignalR client will then choose the best supported protocol based on the browser.  I needed to force it to ServerSentEvents events because my browser supported web sockets but IIS Express running on Windows 7 doesn't


## Obtaining the SignalR Package

The solution contains the Microsoft.AspNetCore.SignlarR (1.0.0-alpha1-26969) NuGet package.  This was obtained using the following steps:

##### Set up a new package source so it's possible to obtain the alpha .NET Core versions of SignalR
-  Open the NuGet Package Manager Sources Dialogue (Tools > NuGet Package Manager > Packages Manager Settings, then select Package Sources)
-  Click the [+] button next to Available Package Sources to add a new package source
-  A new entry is created named "Package source", edit the name to something more friendly, e.g. .NET Core Alpha Packages
-  Set the source to: https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json
-  Then click "Update" to save your new package source

##### Adding the SignalR package to the solution
-  Open NuGet Package Manager as normal, on the right side change the "Package Source" setting to the one you just added.  Now when you search for SignalR you should be able to find the above AspNetCore.SignalR package.

## Obtaining the SignlarR Client
The SignalR javascript client was obtained crudely using node package manager.

Open up the Node.js command prompt and navigate to the solution directory.
Run these commands
```
npm install msgpack5
npm install @aspnet/signalr-client --registry https://dotnet.myget.org/f/aspnetcore-ci-dev/npm/
```
Navigate into the `node_modules` folder and drill down through `@aspnet` > `signalr-client` > `dist` > `browser` and grab out the signalr-client.js (or .min.js version).
This file can then be added to the solution.

I'm aware this is not how to use a package manager properly, but I just can't be dealing with all this package manager rubbish just to get a javascript file - It's probably my ignorance, sorry!!


