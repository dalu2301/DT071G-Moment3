namespace MessageBoard
{
    public class Message
    {
        // Använder Auto Property för att eliminera varningar
        // i koden, annars så hade en vanlig Property med
        // Get och Set kanske varit mer beskrivande.
        public string? User { get; set; }
        public string? Content { get; set; }
    }
}
