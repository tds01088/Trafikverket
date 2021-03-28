# Trafikverket
Trafikverket  Console application based on Clean Architecture


Uppgift Gå till https://api.trafikinfo.trafikverket.se/ och registrera ett konto. Därefter letar du reda på exempelkod för hur man ansluter och skapar en konsolapplikation som kommunicerar med Trafikverkets öppna API. När du bekantat dig med hur det fungerar så skapa följande:

· En konsolapplikation som kan kommunicera med det öppna API:et

· Applikationen skall göra en förfrågan till API:et om alla kameror som finns utsatta, dvs. objecttype="Camera" skall efterfrågas.

· Applikationen skall spara svaret och skapa upp en lista eller motsvarande med kameraobjekt, dvs. varje kamera som dyker upp i svaret skall sparas i minnet som ett klassobjekt du själv specificerar. Exempel kan vara class Camera eller liknande.

· Efter körning av programmet skrivs det ut i konsolen antal kameror som fanns med i svaret samt hur många av dessa som har ”direction: 90”

Uppgift 2

I denna uppgift ska ni skapa en view och en procedurer. Vi har bifogat skript (gjort för MS SQL server) för att skapa 3 tabeller och fylla de 3 tabellerna med information. Denna uppgift kan lösa utan ha tillgång till en databas. Alla uppgifter finns i dokumentet.

A

Skapa en vy i SQL som omfattar all information från de 3 tabellerna. Du ska koppla samman dessa tre tabeller. Svaret från view ska ge mig firstname, lastname, betyg och title

B

Skapa en procedur som hämtar vilka elever som har betyg större än 92. I svaret ska namn finnas med.