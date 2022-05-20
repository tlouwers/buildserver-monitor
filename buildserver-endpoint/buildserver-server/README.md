
# Overview
This folder contains a single Visual Studio 2013 (Community) C# solution, which has both a Server and Client application. The Server is used to control the endpoint (the device), the Client mimics the endpoint and is used for testing.

## Server
Application to which 1 or more Clients can connect. When sending commands it will send them to all Clients.

## Client
Application used for testing. Functionality mimics the endpoint. It is used (mainly) to test the API required to control the endpoint.

## packages
This is the MetroModernUI nupkg package, see here: https://www.nuget.org/packages/metromodernui. It is used to pimp the UI a bit.
