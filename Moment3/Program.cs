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

                if (pressedKey == 49)
                {
                    Message newMessage = new()
                    {
                        User = "Satan",
                        Content = "Evil rules!"
                    };
                    messageHandler.AddMessage(newMessage);
                }

                if (pressedKey == 88)
                {
                    Environment.Exit(0);
                }
            }


        }
    }
}
