FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

ARG Version  
ARG NugetKey 

ENV version=$Version nugetkey=$NugetKey nugeturl="https://api.nuget.org/v3/index.json"

# Copy csproj and restore as distinct layers
COPY . .

RUN dotnet build ./RazorComponents.sln /p:Version=$Version -c Release #--no-restore  
RUN dotnet pack ./src/Majunga.RazorModal/*.csproj /p:Version=$Version -c Release --no-restore --no-build -o /sln/artifacts

#RUN dotnet test ./tests/Unit.Majunga.RazorModal.Tests/*.csproj
ENTRYPOINT dotnet nuget push /sln/artifacts/Majunga.RazorModal.$version.nupkg --source $nugeturl --api-key $nugetkey
