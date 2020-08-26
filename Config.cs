using Rocket.API;

namespace F.ModerationSystem
{
    public class Config : IRocketPluginConfiguration
    {
        public string DiscordWebHookLink;
        public string NoReason;
        public uint DefaultBanTime;

        public void LoadDefaults()
        {
            DiscordWebHookLink = "Your DiscordWebHookURL";
            NoReason = "No reason provided";
            DefaultBanTime = 0;
        }
    }
}
