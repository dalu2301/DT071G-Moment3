using System.Text.Json;

namespace MessageBoard
{
    public class MessageHandler
    {
        private List<Message> messages = new List<Message>();
        private string fileName = @"messages.json";

        public MessageHandler()
        {
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                Console.WriteLine(jsonString);
                messages = DeserializeMessages(jsonString);
            }
        }

        public void AddMessage(Message message) 
        {
            messages.Add(message);
            SerializeMessages(messages);
        }

        public List<Message> GetMessages()
        {
            return messages;
        }

        private void SerializeMessages(List<Message> input)
        {
            string jsonString = JsonSerializer.Serialize(input);
            File.WriteAllText(fileName, jsonString);
        }

        private List<Message> DeserializeMessages(string input)
        {
            return JsonSerializer.Deserialize<List<Message>>(input)!;
        }
    }

}