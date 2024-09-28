namespace MessageBoard
{
    internal class Program
    {
        static void Main()
        {
            MessageHandler messageHandler = new MessageHandler();

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

                int messageIndex = 0;
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
                            Message newMessage = new()
                            {
                                User = user,
                                Content = content
                            };
                            messageHandler.AddMessage(newMessage);
                        }

                        break;
                    // På min dator blirtangent 2 -> 50 och NumPad 1 -> 98.
                    case 50:
                    case 98:
                        Console.CursorVisible = true;
                        Console.Write("Ange nummer på inlägg att ta bort: ");
                        string? messageToDelete = Console.ReadLine();

                        try
                        {
                            if (!String.IsNullOrEmpty(messageToDelete))
                            {
                                messageHandler.DeleteMessage(Convert.ToInt32(messageToDelete));
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Inlägget du försöker ta bort existerar inte.");
                            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
