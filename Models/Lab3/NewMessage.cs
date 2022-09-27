namespace OOP.Models.Lab3 
{ 
    public sealed class NewMessage : Message
    {
        public string? Sender { get; set; }

        private NewMessage() {}

        public static NewMessage Create(string? sender, string? message)
        {
            return new NewMessage
            {
                Sender = string.IsNullOrWhiteSpace(sender) ? "Anonymous" : sender,
                Text = message
            };
        }
    }
}
