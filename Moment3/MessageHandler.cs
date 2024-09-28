using System.Text.Json;

namespace MessageBoard
{
    public class MessageHandler
    {
        private readonly List<Message> messages = [];
        private readonly string fileName = @"messages.json";

        public MessageHandler()
        {
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                messages = DeserializeMessages(jsonString);
            }
        }

        public void AddMessage(Message message)
        {
            messages.Add(message);
            SerializeMessages(messages);
        }

        public void DeleteMessage(int index)
        {
            messages.RemoveAt(index);
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