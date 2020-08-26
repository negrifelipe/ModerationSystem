using System.ComponentModel;
using System.Net;
using System;
using System.Text;
using System.Runtime.CompilerServices;

namespace F.ModerationSystem
{
	public static class Functions
	{
		public static Main Instance;

		public static void SendToDiscord2(string caller, string displayname, string kicked, string reason)
		{
			var discordWebHookLink = Main.Instance.Configuration.Instance.DiscordWebHookLink;
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(discordWebHookLink);
			var f = "{ \"content\": \"" + "[KICK] Moderator: **``" +displayname + "``**(" + caller + ") kicked: ``" + kicked + "`` reason: ``" + reason + "``" + "\"}";
			var bytes = Encoding.ASCII.GetBytes(f);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.ContentLength = (long)bytes.Length;
			using (var requestStream = httpWebRequest.GetRequestStream())
			{
				requestStream.Write(bytes, 0, bytes.Length);
			}
			httpWebRequest.GetResponse();
		}

		public static void SendToDiscord3(string caller, string displayname, string banned, string time, string reason)
		{
			var discordWebHookLink = Main.Instance.Configuration.Instance.DiscordWebHookLink;
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(discordWebHookLink);
			var f = "{ \"content\": \"" + "[BAN] Moderator: **``" + displayname + "``**(" + caller + ") banned: ``" + banned + "`` reason: ``" + reason + "`` for: ``" + time + "``" + "\"}";
			var bytes = Encoding.ASCII.GetBytes(f);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.ContentLength = (long)bytes.Length;
			using (var requestStream = httpWebRequest.GetRequestStream())
			{
				requestStream.Write(bytes, 0, bytes.Length);
			}
			httpWebRequest.GetResponse();
		}
	}
}
