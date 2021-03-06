﻿
namespace NomadCode.BotFramework
{
    using Newtonsoft.Json;
    using NomadCode.BotFramework;
    using System.Linq;

    /// <summary>
    /// Channel account information for a conversation
    /// </summary>
    public partial class ConversationAccount
    {
        /// <summary>
        /// Initializes a new instance of the ConversationAccount class.
        /// </summary>
        public ConversationAccount()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ConversationAccount class.
        /// </summary>
        /// <param name="isGroup">Is this a reference to a group</param>
        /// <param name="id">Channel id for the user or bot on this channel
        /// (Example: joe@smith.com, or @joesmith or 123456)</param>
        /// <param name="name">Display friendly name</param>
        public ConversationAccount(bool? isGroup = default(bool?), string id = default(string), string name = default(string))
        {
            IsGroup = isGroup;
            Id = id;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets is this a reference to a group
        /// </summary>
        [JsonProperty(PropertyName = "isGroup")]
        public bool? IsGroup { get; set; }

        /// <summary>
        /// Gets or sets channel id for the user or bot on this channel
        /// (Example: joe@smith.com, or @joesmith or 123456)
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets display friendly name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
