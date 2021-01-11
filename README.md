# CleanCodeOchTestbarKod-Labb4
# Elvis Sahlén & Charlotte Magnusson

Vi har byggt en SPA som visar dig ett par kort från Magic the Gathering. Du kan välja att klicka på en av dem för att rösta på vilket du föredrar. Datan sparas i en JSON-fil i en av våra tre microservices. Man får också se ett citat från ett slumpmässigt Magic the Gathering-kort efter man röstat, och dessutom procentfördelningen mellan korten baserat på alla röster som gjorts.

Vi har tre microservices som är självstående APIer. Dessa används av vårt front-end-projekt som är en SPA. Front-enden får datan genom att kalla på metoder i en back-end-klass som ligger i samma projekt. I denna klassen kallas de olika APIerna för att få datan som krävs för att appen ska fungera.

En av våra microservices är en kalkylator, som innehåller en funktion som tar in två siffror och ger tillbaka procentfördelningen mellan siffrorna. Detta används i front-enden för att kunna få ut en procentfördelning av röster mellan ett par kort. Detta skulle förstås i praktiken kunna användas för vad som helst i framtiden, och har byggts med detta i åtanke.

Magic the Voting API är en av våra microservices som innehåller data för par av Magic the Gathering-kort och dess röstfördelning. Det är byggt med REST-standard som gör det enkelt att få ut slumpmässiga par av kort och att lägga till en röst på ett specifikt par. Detta sparas i en JSON-fil då det är enkelt och tar lite plats.

Magic the Quotes API är vår tredje microservice som innehåller en lista av citat från Magic the Gathering-kort som också sparas i en JSON-fil. Denna är också byggt med REST-standard som låter dig få ut ett slumpmässigt citat från JSON-filen.
