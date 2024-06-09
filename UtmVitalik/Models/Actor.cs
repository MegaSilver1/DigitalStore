namespace UtmVitalik.BusinessLogic.DB
{
    public class Actor
    {
       public  Actor()
        {
            
        }
        public Actor(string name, string email,string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

       

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string Role { get; set; }
    }
}