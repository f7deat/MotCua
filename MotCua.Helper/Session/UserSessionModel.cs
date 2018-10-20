using System;

namespace MotCua.Helper.Session
{
    [Serializable]
    public class UserSessionModel
    {
        public int UserId { get; set; }
        public string Groups { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
    }
}
