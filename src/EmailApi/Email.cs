using System.Collections.Generic;

namespace EmailApi
{
    public class Email
    {
        public string Subject { get; set; }
        public string ToEmailAddress { get; set; }
        public IList<string> CC { get; set; } = new List<string>();
        public string Body { get; set; }
    }
}