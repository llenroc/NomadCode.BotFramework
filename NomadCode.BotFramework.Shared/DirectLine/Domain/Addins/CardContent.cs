﻿using System.Collections.Generic;

using Newtonsoft.Json;

#if __IOS__
using AttributedString = Foundation.NSAttributedString;
#elif __ANDROID__
using AttributedString = Android.Text.SpannableStringBuilder;
#endif

namespace NomadCode.BotFramework
{
	// generic class to deserialize attachment content into
	public class CardContent
	{
		AttributedString _attributedText;
		public AttributedString AttributedText => _attributedText ?? (_attributedText = Text?.GetMessageAttributedString ());

		AttributedString _attributedTitle;
		public AttributedString AttributedTitle => _attributedTitle ?? (_attributedTitle = Title?.GetAttachmentTitleAttributedString ());

		AttributedString _attributedSubtitle;
		public AttributedString AttributedSubtitle => _attributedSubtitle ?? (_attributedSubtitle = Subtitle?.GetAttachmentSubtitleAttributedString ());


		// maybe set content type to know if the images are hero or thumbnail?

		[JsonProperty (PropertyName = "title")]
		public string Title { get; set; }

		public bool HasTitle => !string.IsNullOrEmpty (Title);

		/// <summary>
		/// Gets or sets subtitle of the card
		/// </summary>
		[JsonProperty (PropertyName = "subtitle")]
		public string Subtitle { get; set; }

		public bool HasSubtitle => !string.IsNullOrEmpty (Subtitle);

		/// <summary>
		/// Gets or sets text for the card
		/// </summary>
		[JsonProperty (PropertyName = "text")]
		public string Text { get; set; }

		public bool HasText => !string.IsNullOrEmpty (Text);


		IList<CardImage> _images;

		/// <summary>
		/// Gets or sets array of images for the card
		/// </summary>
		[JsonProperty (PropertyName = "images")]
		public IList<CardImage> Images
		{
			get => _images ?? (_images = Image != null ? new List<CardImage> { new CardImage (Image.Url, Image.Alt) } : null);
			set => _images = value;
		}

		public bool HasImages => Images?.Count > 0;

		/// <summary>
		/// Gets or sets thumbnail placeholder
		/// </summary>
		[JsonProperty (PropertyName = "image")]
		public ThumbnailUrl Image { get; set; }

		/// <summary>
		/// Gets or sets set of actions applicable to the current card
		/// </summary>
		[JsonProperty (PropertyName = "buttons")]
		public IList<CardAction> Buttons { get; set; }

		public bool HasButtons => Buttons?.Count > 0;

		/// <summary>
		/// Gets or sets this action will be activated when user taps on the
		/// card itself
		/// </summary>
		[JsonProperty (PropertyName = "tap")]
		public CardAction Tap { get; set; }
	}
}
