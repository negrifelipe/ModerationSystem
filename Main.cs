using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Commands;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Pathfinding;

namespace F.ModerationSystem
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("F.ModerationSystem Loaded", ConsoleColor.Red);
            Logger.Log("Discord Support: https://discord.gg/6zQVJ9p", ConsoleColor.Red);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "Invalid-Player-Name", "!color=yellow¡Invalid Player Name!/color¡" },
            { "Correct-Kick-Usage", "!color=yellow¡Kick command correct usage: /kick (player) (reason)!/color¡" },
            { "Kick-Success1", "!color=blue¡Successfully kicked:!/color¡" },
            { "Reason", "!color=blue¡reason:!/color¡" },
            { "For", "!color=blue¡for:!/color¡" },
            { "Correct-Ban-Usage", "!color=yellow¡Ban command correct usage: /ban (player) (reason) (time)!/color¡" },
            { "Ban-Success1", "!color=blue¡Successfully banned:!/color>" },
            { "Invalid-Ban-Format", "!color=yellow¡Invalid Player Name or time!/color¡" },
        };

        [RocketCommand("kick", "Kick command", "", AllowedCaller.Player)]
        [RocketCommandPermission("moderation.kick")]
        public void Kick(IRocketPlayer caller, string[] args)
        {
            var player = (UnturnedPlayer)caller;
            switch (args.Length)
            {
                case 1:
                    var p = UnturnedPlayer.FromName(args[0]);
                    if (p != null)
                    {
                        UnturnedChat.Say(caller, Translate("Kick-Success1").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + args[0], UnityEngine.Color.white, true);
                        p.Kick(Main.Instance.Configuration.Instance.NoReason);

                        Functions.SendToDiscord2(Convert.ToString(player.CSteamID), player.DisplayName, args[0], Main.Instance.Configuration.Instance.NoReason);
                    }
                    else
                        UnturnedChat.Say(caller, Translate("Invalid-Player-Name").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>'), UnityEngine.Color.white, true);
                    break;
                case 2:
                    var pa = UnturnedPlayer.FromName(args[0]);
                    if (pa != null)
                    {
                        pa.Kick(args[1]);
                        UnturnedChat.Say(caller, Translate("Kick-Success1").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + args[0] + " " + Translate("Reason").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + args[1], UnityEngine.Color.white, true);
                        Functions.SendToDiscord2(Convert.ToString(player.CSteamID), player.DisplayName, args[0], args[1]);
                    }
                    else
                        UnturnedChat.Say(caller, Translate("Invalid-Player-Name").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>'), UnityEngine.Color.white, true);
                    break;
                default:
                    UnturnedChat.Say(caller, Translate("Correct-Kick-Usage").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>'), UnityEngine.Color.white, true);
                    break;
            }
        }
        [RocketCommand("ban", "Ban command", "", AllowedCaller.Player)]
        [RocketCommandPermission("moderation.ban")]
        public void Ban(IRocketPlayer caller, string[] command)
        {
            var player = (UnturnedPlayer)caller;
            switch (command.Length)
            {
                case 2:
                    var pa = UnturnedPlayer.FromName(command[0]);
                    if (pa != null)
                    {
                        pa.Ban(command[1], Main.Instance.Configuration.Instance.DefaultBanTime);
                        UnturnedChat.Say(caller, Translate("Ban-Success1").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + command[0] + " " + Translate("Reason").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + command[1] + " " + Translate("For").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + Main.Instance.Configuration.Instance.DefaultBanTime.ToString(), UnityEngine.Color.white, true);
                        Functions.SendToDiscord3(Convert.ToString(player.CSteamID), player.DisplayName, command[0], Main.Instance.Configuration.Instance.DefaultBanTime.ToString(), command[1]);
                    }
                    else
                        UnturnedChat.Say(caller, Translate("Invalid-Player-Name").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>'), UnityEngine.Color.white, true);
                    break;
                case 3:
                    var p = UnturnedPlayer.FromName(command[0]);
                    if (p != null)
                    {
                        p.Ban(command[1], Convert.ToUInt32(command[2]));
                        UnturnedChat.Say(caller, Translate("Ban-Success1").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + command[0] + " " + Translate("Reason").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + command[1] + " " + Translate("For").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>') + command[2], UnityEngine.Color.white, true);
                        Functions.SendToDiscord3(Convert.ToString(player.CSteamID), player.DisplayName, command[0], command[2], command[1]);
                    }
                    else
                        UnturnedChat.Say(caller, Translate("Invalid-Ban-Format").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>'), UnityEngine.Color.white, true);
                    break;
                default:
                    UnturnedChat.Say(caller, Translate("Correct-Ban-Usage").Replace('{', '"').Replace('}', '"').Replace('!', '<').Replace('¡', '>'), UnityEngine.Color.white, true);
                    break;
            }
        }
        protected override void Unload()
        {
            Instance = null;
        }
    }
}
