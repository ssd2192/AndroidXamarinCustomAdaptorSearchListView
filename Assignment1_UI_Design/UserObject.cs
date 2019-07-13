namespace Assignment1_UI_Design
{
    public class UserObject
    {
        public string email;
        public string name;
        public int image;

        public UserObject(string nameInfo, string ageInfo, int imgInfo)
        {
            email = nameInfo;
            name = ageInfo;
            image = imgInfo;
        }
    }
}