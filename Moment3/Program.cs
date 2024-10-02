
// Jag är medveten om att ett informationsmeddelande
// finns gällande Namespace. Jag ville ha ett mer 
// beskrivade Namespace, så jag ändrade från Moment 3
// till MessageBoard.
namespace MessageBoard
{
    internal class Program
    {
        static void Main()
        {
            // Smidigt att det numera räcker med att skapa en
            // ny instans med enbart new(), så länge variabeln
            // är starkt typad.
            MessageHandler messageHandler = new();

            // Loppar ad infinitum tills användaren själv 
            // avslutar programmet med hjälp av "x".
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine(
                    """
                    *** En Gästbok ***
                
                    [1] Lägg till ett inlägg
                    [2] Ta bort ett inlägg

                    [X] Avsluta

                    """);

                // Skapar ett meddelandeindex för senare
                // användning för borttag av aktuellt inlägg.
                int messageIndex = 0;

                // Loopar igenom listan och skriver ut befintliga
                // (om några) inlägg på skärmen.
                foreach (Message message in messageHandler.GetMessages())
                {
                    Console.WriteLine(
                        $"""
                        Id: {messageIndex}
                        Namn: {message.User}
                        Meddelande: {message.Content}

                        """);

                    messageIndex++;
                }

                // Hanterar den tangent som används av användaren.
                int pressedKey = (int)Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    // På min dator blir tangent 1 -> 49 och NumPad 1 -> 97.
                    case 49:
                    case 97:
                        Console.CursorVisible = true;
                        Console.Write("Ange namn: ");
                        string? user = Console.ReadLine();
                        Console.Write("Ange innehåll: ");
                        string? content = Console.ReadLine();

                        if ((!String.IsNullOrEmpty(user)) && (!String.IsNullOrEmpty(content)))
                        {
                            // Skapar "kontraktet" redan här, det vill säga att
                            // AddMessage endast godkänner typen Message. 
                            Message newMessage = new()
                            {
                                User = user,
                                Content = content
                            };
                            messageHandler.AddMessage(newMessage);
                        } 
                        else
                        {
                            Console.WriteLine("Både namn och innehåll måste vara korrekt ifyllda.");
                            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        break;
                    // På min dator blir tangent 2 -> 50 och NumPad 2 -> 98.
                    case 50:
                    case 98:
                        Console.CursorVisible = true;
                        Console.Write("Ange nummer på inlägg att ta bort: ");
                        string? messageToDelete = Console.ReadLine();

                        try
                        {
                            if (!String.IsNullOrEmpty(messageToDelete))
                            {
                                // Alternativt sätt att konvertera...
                                // messageHandler.DeleteMessage(Int32.Parse(messageToDelete));
                                messageHandler.DeleteMessage(Convert.ToInt32(messageToDelete));
                            }
                        }
                        catch (Exception)
                        {
                            // Gör det enkelt för oss, nämligen att allt, förutom
                            // korrekt indexnummer, genererar samma felmeddelande.
                            Console.WriteLine("Inlägget du försöker ta bort existerar inte.");
                            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        break;
                    case 88:
                        // Användaren har tryckt på tangenten "x", avsluta programmet.
                        Environment.Exit(0);
                        break;
                    default:
                        // Hoppa ur Switch, och fortsätt loopa tills
                        // en accepterad tangenttryckning sker.
                        break;
                }
            }
        }
    }
}
