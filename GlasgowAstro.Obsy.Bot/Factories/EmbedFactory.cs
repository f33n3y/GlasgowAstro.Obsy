using Discord;
using System;
using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Bot.EmbedBuilders
{
    public static class EmbedFactory
    {
        public static List<EmbedFieldBuilder> CreateEmbedList()
        {
            return new List<EmbedFieldBuilder>();
        }

        public static EmbedFieldBuilder CreateEmbedField(string name, string value)
        {
            return new EmbedFieldBuilder
            {
                Name = name,
                Value = value
            };
        }

        public static Embed CreateEmbedWithFields(string title, string footerText, string thumbnailUrl, Color colour, List<EmbedFieldBuilder> fields)
        {
            var embed = new EmbedBuilder()
                    .WithTitle(title)
                    .WithFooter(footer => footer.Text = footerText)
                    .WithThumbnailUrl(thumbnailUrl)
                    .WithCurrentTimestamp()
                    .WithColor(colour)
                    .WithFields(fields);

            return embed.Build();
        }
    }
}
