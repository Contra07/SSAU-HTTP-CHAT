using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Chat
    {
        public int id { get; set; }
        public int chatId { get; set; }
        public string text { get; set; }
        public Author author { get; set; }
        public string createdAt { get; set; }
        public bool isRead { get; set; }
        public object isPinned { get; set; }
        public bool isImportant { get; set; }
        public List<object> links { get; set; }

        public class Author
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    }

}
