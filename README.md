# DT071G - Moment 3

## Instruktioner

+ Skapa en gästbok som en konsolapplikation med möjlighet att lägga till en post, ta bort en valfri post samt visa alla poster.
+ Ett enklare menysystem hanterar del val som ska kunna genomföras.
+ Lägg till inlägg ska ge dig valet att mata in ägare samt det nya inlägget. Desa fält får ej vara tomma.
+ Ta bort inlägg ska fråga efter valt index(till vänster i listan av inlägg på bild ovan) att ta bort innan radering av inlägget.
+ Inläggen ska innehålla två fält, "ägare till inlägget" samt texten för "inlägget"
+ Gästbokens inlägg ska serialiseras/deserialiseras samt sparas på fil antingen binärt eller som json, så att tidigare inmatad data finns lagrad.
+ Felhantering i form av en kontroll så att inmatningsfält inte är tomma.
+ Efter varje genomfört menyval ska skärmen skrivas om. Detta sker enklast genom att man "rensar" konsolen och sedan ritar/skriver om den.