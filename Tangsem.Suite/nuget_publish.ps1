dotnet clean .\Tangsem.Suite.Core.sln
dotnet build .\Tangsem.Suite.Core.sln --configuration=release

# API KEY: https://www.nuget.org/account/apikeys
$nugetApiKey = "*******cfe"
$ver = "1.3.2"

$prjs = @("Tangsem.Common", "Tangsem.Data", "Tangsem.NHibernate", "Tangsem.Identity", "Tangsem.Web.Mvc")

$prjs.ForEach({
  dotnet nuget push .\projects\$_\bin\Release\$_.$ver.nupkg -s https://api.nuget.org/v3/index.json -k $nugetApiKey
})
