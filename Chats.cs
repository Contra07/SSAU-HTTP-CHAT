using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Chats
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string avatar { get; set; }
        public List<ChatMember> chatMembers { get; set; }
        public LastMessage lastMessage { get; set; }
        public string createdAt { get; set; }
        public string lastActivity { get; set; }
        public Creator creator { get; set; }
        public bool isArchive { get; set; }
        public bool isDisableNotification { get; set; }
        public int isImportant { get; set; }
        public int unreadMessagesCount { get; set; }

        public class Author
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class ChatMember
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Creator
        {
            public int id { get; set; }
            public bool isTeacher { get; set; }
        }

        public class LastMessage
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
        }
    }
    

    


}
