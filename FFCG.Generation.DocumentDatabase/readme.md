Projektet består av två projekttyper:

### FFCG.Generation.DocumentDatabase
Type: Class Library

Det här projektet innehåller C#-representationerna av dokumenten i databasen

### FFCG.Generation.DocumentDatabase.RavenDB
Type: Console Application

Superenkelt projekt som kopplar upp sig mot dokumentdatabasen (`DocumentStore`) och öppnar en session mot den. En `Session` kan ses som en anslutning mot databasen som är per request.

## Ladda ner Raven
Gå till http://ravendb.net och välj Downloads. Fyll i formuläret och ladda sedan ner `Zip` från rutan till höger. Obs! Det kan vara bra att högerklicka och välja "Unblock" innan man packar upp zip-filen.

Packa upp zip-filen till valfri katalog och starta sedan powershell. Starta:

```
> C:\RavenDB-Build-30100\Server\Raven.Server.exe
```

Nu är servern startad. Öppna en webbläsare och gå till http://localhost:8080. Första gången finns det inga databaser och ni kommer bli omdedd att skapa en. Döp den till "Demo".

Gå till Tasks och välj "Generate sample data".

Nu kan ni köra ovanstående applikation!
