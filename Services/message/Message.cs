namespace BookStore.Services{

    public class Message{
        public string msg {get; set;}
        public dynamic data {get; set;}

        public Message(string message)=> msg=message;
    }
}