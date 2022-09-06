$ver = "1.4.6.19"
$apiKey = "oy***jq"
dotnet clean .\Tangsem.Suite.Core.sln
dotnet build .\Tangsem.Suite.Core.sln --configuration=release /property:Version=$ver


$prjs = @(
  "Tangsem.Common",
  "Tangsem.Data",
  "Tangsem.NHibernate",
  "Tangsem.NHibernate.Postgres",
  "Tangsem.Identity",
  "Tangsem.Web.Mvc",
  "Tangsem.OpenApi.Extensions",

  "Tangsem.Generator.Metadata",
  "Tangsem.Generator.Metadata.Postgres",
  "Tangsem.Generator")
#$prjs = @("Tangsem.Generator")

$prjs.ForEach({
  dotnet nuget push --source https://api.nuget.org/v3/index.json --api-key $apiKey .\projects\$_\bin\release\$_.$ver.symbols.nupkg --skip-duplicate
})
