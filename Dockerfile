FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

ARG Version  
ARG NUGET_KEY
ARG NUGET_URL=https://api.nuget.org/v3/index.json

# Copy csproj and restore as distinct layers
COPY src/Majunga.RazorModal/*.csproj ./src/Majunga.RazorModal/
COPY tests/Unit.Majunga.RazorModal.Tests/*.csproj ./tests/Unit.Majunga.RazorModal.Tests/
COPY ./RazorComponents.sln ./
#RUN dotnet restore ./RazorComponents.sln

# Copy everything else and build
COPY . ./
RUN dotnet build ./RazorComponents.sln /p:Version=$Version -c Release #--no-restore  
RUN dotnet pack ./src/Majunga.RazorModal/*.csproj /p:Version=$Version -c Release --no-restore --no-build -o /sln/artifacts

RUN dotnet test ./tests/Unit.Majunga.RazorModal.Tests/*.csproj

ENTRYPOINT ["dotnet", "nuget", "push", "/sln/artifacts/*.nupkg"]
CMD ["--source", $NUGET_URL]
CMD ["--api-key", $NUGET_KEY]