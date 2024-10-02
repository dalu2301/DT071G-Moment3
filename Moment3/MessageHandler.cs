using System.Text.Json;

namespace MessageBoard
{
    public class MessageHandler
    {
        // Diverse klassdefinitioner.
        private readonly List<Message> messages = [];
        private readonly string fileName = @"messages.json";

        // I konstruktorn läses JSON-filen in,
        // om den existerar, med befintliga inlägg.
        public MessageHandler()
        {
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                messages = DeserializeMessages(jsonString);
            }
        }

        // Lägger till ett nytt inlägg i formatet Message.
        public void AddMessage(Message message)
        {
            messages.Add(message);
            SerializeMessages(messages);
        }

        // Tar bort ett inlägg i listan baserat på index.
        public void DeleteMessage(int index)
        {
            messages.RemoveAt(index);
            SerializeMessages(messages);
        }

        // Returnerar en lista med samtliga befintliga inlägg.
        public List<Message> GetMessages()
        {
            return messages;
        }

        // Serialiserar listan med inlägg (till JSON) samt
        // skriver till disk (fil).
        private void SerializeMessages(List<Message> input)
        {
            string jsonString = JsonSerializer.Serialize(input);
            File.WriteAllText(fileName, jsonString);
        }

        // Gör om den serialiserade JSON-strängen till
        // en lista (List<Message>).
        private List<Message> DeserializeMessages(string input)
        {
            return JsonSerializer.Deserialize<List<Message>>(input)!;
        }
    }
}