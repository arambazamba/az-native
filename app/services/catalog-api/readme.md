# catalog-api

[catalog-api](/app/services/catalog-api/) provides a REST API to manage a food catalog.

`appsettings.json`:

```json
{
    "Azure": {    
        "KeyVault": "https://foodvault-dev.vault.azure.net/",
        "EventGridKey": "<EventGridKey>",
        "EventGridEP": "<EventGridEP>",
        "AppReg": {
            "TenantId": "d92b247e-90e0-4469-a129-6a32866c0d0a",
            "ClientId": "b509d389-361a-447b-afb2-97cc8131dad6",
            "Instance": "https://login.microsoftonline.com/",
            "cacheLocation": "localStorage"
        }
    },
    "ApplicationInsights": {
        "ConnectionString": "InstrumentationKey=0a945124-73ac-4295-98b0-5116df276b7d;IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/"
    },
    "FoodCatalogApi": {
        "Title": "Food Catalog Api",
        "AuthEnabled": false,
        "UseAppConfig": false,
        "UseSQLite": true,
        "UseManagedIdentity": false,
        "ConnectionStrings": {
            "SQLiteDBConnection": "Data Source=./food.db",
            "SQLServerConnection": "Data Source=localhost;Initial Catalog=food-db;Persist Security Info=True;User ID=sa;Password='TiTp4SQL@dmin'"
        }    
    },
    "FeatureManagement":{
        "PublishEvents" : false,
        "UseHealthChecks" : false,
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft": "Warning",
            "Microsoft.Hosting.Lifetime": "Information"
        }
    }    
}

```