using Newtonsoft.Json;
using System;

namespace ShComp.TrelloNet.Models
{
    public class Card
    {
        public string Id { get; set; }

        public DateTimeOffset DateLastActivity { get; set; }

        public DateTimeOffset? Due { get; set; }

        public bool DueComplete { get; set; }

        public string Name { get; set; }

        [JsonProperty("idMembers")]
        public string[] MemberIds { get; set; }

        [JsonProperty("idLabels")]
        public string[] LabelIds { get; set; }

        public object checkItemStates { get; set; }
        public bool closed { get; set; }
        public string desc { get; set; }
        public object descData { get; set; }
        public string idBoard { get; set; }
        public string idList { get; set; }
        public object[] idMembersVoted { get; set; }
        public int idShort { get; set; }
        public object idAttachmentCover { get; set; }
        public bool manualCoverAttachment { get; set; }
        public int pos { get; set; }
        public string shortLink { get; set; }
        public Badges badges { get; set; }
        public object[] idChecklists { get; set; }
        public Label[] labels { get; set; }
        public string shortUrl { get; set; }
        public bool subscribed { get; set; }
        public string url { get; set; }
    }

    public class Badges
    {
        public int votes { get; set; }
        public Attachmentsbytype attachmentsByType { get; set; }
        public bool viewingMemberVoted { get; set; }
        public bool subscribed { get; set; }
        public string fogbugz { get; set; }
        public int checkItems { get; set; }
        public int checkItemsChecked { get; set; }
        public int comments { get; set; }
        public int attachments { get; set; }
        public bool description { get; set; }
        public DateTimeOffset? Due { get; set; }
        public bool DueComplete { get; set; }
    }

    public class Attachmentsbytype
    {
        public Trello trello { get; set; }
    }

    public class Trello
    {
        public int board { get; set; }
        public int card { get; set; }
    }

    public class Label
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }
}
