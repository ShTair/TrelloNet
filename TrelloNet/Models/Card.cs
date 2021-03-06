﻿using Newtonsoft.Json;
using System;

namespace ShComp.TrelloNet.Models
{
    public class Card
    {
        public string Id { get; set; }

        [JsonProperty("dateLastActivity")]
        public DateTimeOffset LastActivityDate { get; set; }

        public DateTimeOffset? Due { get; set; }

        [JsonProperty("dueComplete")]
        public bool IsCompleted { get; set; }

        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("idMembers")]
        public string[] MemberIds { get; set; }

        [JsonProperty("idLabels")]
        public string[] LabelIds { get; set; }

        [JsonProperty("customFieldItems")]
        public CustomFieldItem[] CustomFieldItems { get; set; }

        public object checkItemStates { get; set; }
        public bool closed { get; set; }
        public object descData { get; set; }
        public string idBoard { get; set; }
        public string idList { get; set; }
        public object[] idMembersVoted { get; set; }
        public int idShort { get; set; }
        public object idAttachmentCover { get; set; }
        public bool manualCoverAttachment { get; set; }
        public double pos { get; set; }
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
        public object trello { get; set; }
    }

    public class Label
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }

    public class CustomFieldItem
    {
        public string Id { get; set; }

        [JsonProperty("idValue")]
        public string ValueId { get; set; }

        [JsonProperty("idCustomField")]
        public string CustomFieldId { get; set; }

        public string idModel { get; set; }
        public string modelType { get; set; }
    }
}
