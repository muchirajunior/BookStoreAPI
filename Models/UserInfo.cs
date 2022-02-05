namespace BookStore.Models{
    public class UserInfo{

        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string token { get; set; }

        public UserInfo(User user,string token){
            this.id=user.id;
            this.name=user.name;
            this.username=user.username;
            this.email=user.email;
            this.token=token;
        }
    }
}