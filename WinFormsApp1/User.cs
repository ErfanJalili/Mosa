namespace WinFormsApp1
{
    public partial class WelcomeAdminFrm
    {
        public class User 
        {
            public User(string text, string selectedText)
            {
                Name = text;
                Role = selectedText;
            }

            public string Name { get; set; }
            public string Role { get; set; }
            
        }
    }
}
