# Multifabriken - kimkristianssonJU

Kim Kristiansson

Inlämningsuppgift WU21

2021-11-17

## Funktioner och struktur

**Det finns en hel del kod som inte har med uppfyllandet av kraven på uppgiften att göra. Därför utesluter jag dem funktionerna och klasserna i denna delen och tar med de mest väsentliga i reflektionsdelen istället.**

### Superklassen Product

Alla produktklasser (`Candy`, `Car`, `Tofu`, och `Twine`) härstammar från superklassen `Product`, som enbart finns till för att generalisera produkterna i koden.

`Product` innehåller två _klassmedlemmar_ som går i arv till senare subklasser och förväntas att _överskrivas_:

- `ProduktType` - En _egenskap_ som ger information om vilken typ av produkt det är, så som _bil_, _snöre_, _tofu_ eller _godis_.

- `PrintInformation()` - En _metod_ som skriver ut all information som användaren har angett för produkten.

_Konstruktorn_ till _klassen_ `Product` är angiven som `protected`, vilket förhindrar att objekt skapas med denna klass.

#### Subklasser

Subklasserna till superklassen `Product` är de klasser som representerar alla produkter som Multifabriken AB säljer. Klasser tydliggör vad som särskiljer de olika produkterna åt genom deras attribut.
Subklasserna innehåller alla de attribut som är nödvändiga för att uppfylla kraven på uppgiften, även en konstruktor som tillhandahåller de värden som användaren anger.

Dessa subklasser (`Candy`, `Car`, `Tofu`, och `Twine`) är också angivna som `protected` för att förhindra att objekt inte skapas på fel sätt.

#### Subklasserna Console

`ConsoleCandy`, `ConsoleCar`, `ConsoleTofu`, och `ConsoleTwine` är subklasser till varje produkt. Dessa klasser är till för att uppvisa en visuell representation av produkterna.

Klasserna ärver både från klassen `Product` och från klasserna av respektive produkt.

De nedärvda medlemmarna från superklassen `Product` nyttjas här, samt några ytterligare metoder och _fält_ som är knutna till den specifika produkten.

Namnet `Console` används för att tydliggöra att klassen är till för att skriva i konsolfönstret.

### Session

När programmet startas så skapas omedelbart ett `Session`-objekt. Detta objekt ska, som namnet antyder, representera en användares session i programmet. Där lagras all data som användaren har angett. Klassens främsta attribut är `shoppingCart` som är en `Dictionary` med `KeyValuePair<string,<List<Product>>`.

_Strängen_ som `shoppingCart` tar emot i sin `KeyValuePair` är till för den _sträng_ som _egenskapen_ `ProductType` tillhandahåller i subklasserna till `Product`

Med ett objekt från `Session` så tillkommer också metoden `PrintOutCart()` som skriver på ett tillfredställande sätt ut vad användaren har lagt i sin order och nyttjar de medlemmar som kommer med från `Console`-klasserna.

### Produkt Utilities

**_OBS!_** Klassen `Utility` har ingenting med dessa klasser att göra.

- `CandyUtility`

- `CarUtility`

- `TofuUtility`

- `TwineUtility`

Dessa fyra klasser är de mest centrala klasserna i programmet. De mest väsentliga bidragen för programmets funktion är de `Get`-_metoder_ som tillkommer objekten.

#### Get-metoder

`Get`-_metoderna_ skapar det mesta av interaktiviteten för programmet där användaren anger de nödvändiga uppgifter om produkten som som programmet förväntar sig. _Metoderna_ tar emot användarens värden och returnerar omvandlad data för specifika produkter.

### CreateNew-metoder

Värdena som returneras ur `get`-metoderna från de ovan nämnda `Utility`-klasserna tas emot i de olika `CreateNew`-metoderna i klassen `Program`. De objekten för de specifika produkterna skapas därmed via de input-värden som användaren har angett.

`Get`-metoderna förväntas alltid att returnera korrekta värden, då kontroller utförs i metoden som förhindrar otillåten data att hamna i konstruktorn.

Här läggs också den nya produkten in i en `Dictionary`, kallad `shoppingCart`, via en metod som kontrollerar ifall denna `Dictionary`innehåller typen sen tidigare, annars skapas ett nytt `KeyValuePair` i `shoppingCart.`

## Reflektion

Jag har gjort en liknande övning som denna sen tidigare. Jag kan dock inte minnas i vilket sammanhang, eller om det ens var i språket C#. Men ett C-baserat språk var det med all säkerhet. Och eftersom jag har tidigare erfarenhet med C# så kände jag mig trygg med att lösa uppgiften.

När jag väl började arbeta med programmet så gick jag in för att experimentera med de delar av språket som jag tidigare aldrig har utforskat. Flera av dessa personligt outforskade sidor av C# fick jag med: `Enum`, `Random`, och `Regex`. Jag hade också _delegater_ i åtanke, men jag började känna mig trött på att felsöka kod efter `Regex`- expeditionen.

I efterhand nu så känner jag att programmet formades tanklöst efter mina små experiment.

Det finns flera exempel där, med lite fingertoppskänsla, funktioner hade kunnat återanvändas. Ett gott exempel på det är alla de `Get`-metoder som finns i Utility-klasserna. De är näst intill lika. Det som skiljer dem är oftast bara en iteration, `if-sats`, eller returneringstypen.

Så med lite mer putsning på åbäket hade jag nog kunnat göra den delen av programmet lite mer abstrakt än vad den är och där med göra programmet mer robust och framtidssäker.

Men å andra sidan, om perspektivet landar på användarupplevelsen istället för strukturen så tycker jag att programmet har en relativt hög standard.

Det finns dock fler funktioner att tillägga, och som det finns utrymme för i den nuvarande strukturen. Till exempel en möjlighet att skriva `cancel` i konsolfönstret för att avbryta en pågående beställning. Det är faktiskt uppdukat för det i `Program`-klassens `CreateNew`-_metoder_.

Men jag inser att jag började i fel ända av programmet. Istället för att fokusera på att göra strukturen så bra och tydlig som möjligt så tog min nyfikenhet över och fokusen hamnade på estetiska funktioner snarare än praktiska. Detta är ett misstag jag gladeligen gör under en utbildning snarare än i ett skarpt läge.

Anledningen till att jag satte `Product`-klassens konstruktor till `protected` av var att den inte skulle kunna användas överhuvudtaget då den i sig inte innehar de nödvändiga funktionerna till att vara användbar. Och anledningen till att jag satte konstruktorerna i dess subklasser `Candy`, `Car`, `Tofu`, och `Twine` till `protected` var av ungefär samma anledning.

Den struktur jag har i dessa klasser är byggstenar till de sista klasserna i ledet, som är `Console`-klasserna (`ConsoleCandy`, `ConsoleCar`, osv). Jag är osäker på om detta är ett korrekt sätt att bygga klasser på, jag skulle gärna vilja ha feedback på det.

Men jag satte även attributen till `protected` i produktklasserna. Min tanke med det var att vidareutveckla dessa klasser till att använda `properties` för att hantera data som är kopplade till objekten. Men som programmet ser ut nu så var det ingen nödvändighet att lägga till.

Hur som helst så känner jag att jag fick en hel del hjärngympa av att sätta mig in i dessa obekanta områden. För min del så fick jag hitta sätt att utmana mig själv på, vilket jag i efterhand är nöjd med. Jag vet att `Regex` är vida spritt bland flera andra språk, inte minst JavaScript. Även `Enum` kan komma väl till användning vid framtida tillfällen.
Jag är medveten om att detta program är bortom ramarna för vad denna uppgiften handlade om, men den uppfyller alla krav som gavs. Jag får vara nöjd med det.

Om en ny person skulle överta projektet så skulle hen nog klara sig rätt bra med att skapa nya produkter. Allt som krävs är att skapa tre nya klasser. Låt oss säga att 'cykel' skulle läggas till. Då krävs det bara att skapa tre klasser: `Bicycle`, `ConsoleBicycle`, och `BicycleUtility`. Det är inte nödvändigt för en ny utvecklare att skapa visuella ASCII-representationer åt en cykel i form, utan det finns utrymme för att avstå från det.
Den nya klassen `Bicycle` bör ha en konstruktor som tillger data till klassens attribut. `ConsoleBicycle` bör ha en konstruktor som kan vara tom, men som tar emot parametrar som passas över till `Bicycle` genom _nyckelordet_ `base()` för att skapa ett nytt objekt. `ConsoleBicycle` bör också innehålla en `PrintInformation()` metod som ska presentera relevanta uppgifter om den cykel som användaren har beställt. Sedan krävs det metoder i `BicycleUtility` för att kontrollera användaren inmatningar. Efter det är den nya produkten klar att användas via en `CreateNew`-metod i `Program`.

## Övrigt

_Här nedan följer lite kommentarer om några områden i koden som inte var nödvändiga för att få programmet att nå upp till kraven. Jag hade inte blivit ledsen om du slutade läsa här :)_

### InHouse

Eftersom uppgiftens krav inte var specifik med att det skulle finnas en fixerad lista eller inte av färger, modeller, smaker, eller kryddor så tog jag mig friheten att göra fixerade listor. Likt verkligheten så tyckte jag att det skulle finnas ett lager, så jag skapade en statisk klass som heter `InHouse`.

### Enum

#### Colors

Eftersom `ConsoleColor` i .NET är `Enum` så kändes det självklart att arbeta med det som ett visuellt verktyg till att ge färg åt det annars så dystra konsolfönstret. Jag ville dynamiskt ge färg åt de produkter användaren hade valt; en blå bil skulle vara blå, och ett rött snöre skulle vara rött. Min egna `Enum Colors` är alltså baserad på `ConsoleColor` och översätts bara vid användning.

#### Flavours

Smakerna till godiset är likaså baserat på `ConsoleColor` och återge en specifik färg baserat på den smak du anger. Färgen är ganska självklart förknippade med smakerna; blåbär är blått, lakrits är svart, osv.

### Regex

Förkortning av `RegularExpressions`. Är en klass som på enkelt sätt identifierar fraser, ord, symboler, mm. i en text.

Kan liknas vid att du trycker `CTRL+F` eller `⌘+F` i en browser och söker det du vill ha.

Regex var det första jag började experimentera med. Det kom in när jag ville verifiera om användaren har matat in registreringsnumret rätt till bilen. Det fungerade utmärkt och jag kunde till och med tillåta både nya (ABC 12X) och gamla (ABC 123) registreringsnummer med bara enkla små rader kod.

Efter att ha upptäckt denna guldgruva så gick jag loss på alla möjligheter det gav mig. Jag kunde färga godiset till olika färger och så vidare. Men också använda mig av det för att identifiera måttenheter och volymenheter så som millimeter, centiliter, liter, mm. Uppgiften krävde dock att liter skulle anges som volymenhet på tofu, så det fick bli liter. Snöre där emot går att ange dm ifall man vill, programmet kommer att översätta värdet till cm.

### Random

Jag fick en föreställning om att alla godisbitar skulle placeras ut slumpmässigt framför godispåsen när man har valt sitt godis. Den idéen skrotade jag eftersom jag inte fick godisbitarna riktigt på plats. Istället så plockar en funktion bort slumpvalda godisbitar från ASCII-strängarna och lämnar så många bitar som användaren har angett (ponerat att användaren har angett mindre än 12 bitar, annars visas bara 12).

När både `Random` och `Regex` var på plats så kändes det som att en Gott och Blandat-påse skulle passa in. Så jag kombinerade dem till att färglägga slumpvalda godisbitar.

De funktioner som jag har använt mig av finns alla i den statiska klassen `RandomAsciiCandy`.

Jag hade en målbild av att göra dessa funktioner mer generella. Men slutprodukten blev ändå att den är starkt knuten till endast ett ASCII-mönster.

### Statiska klasser

Jag försökte vara försiktig med att använda mig av för hårt knutna statiska klasser, det vill säga att jag ville att funktionerna i dessa klasser skulle vara generella och abstrakta. Men jag beslutade ändå att göra en del av dessa funktioner hårt knutna till specifika inputs, vilket är en negativ produkt av min ostabila struktur i programmet.
