# ModerationSystem
ModerationSystem Plugin allows you to  use /ban /kick commands with a discord webhook and with an easy configuration

In a near future i will add more commands like freeze unfreeze and other stuff

F.Plugins Discord: https://discord.gg/8zded6r

# Configuration file
```
<?xml version="1.0" encoding="utf-8"?>
<Config xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <DiscordWebHookLink>Your DiscordWebHookURL</DiscordWebHookLink>
  <NoReason>No reason provided</NoReason>
  <DefaultBanTime>0</DefaultBanTime>
</Config>
```
# Translation file
```
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="Invalid-Player-Name" Value="!color=yellow¡Invalid Player Name!/color¡" />
  <Translation Id="Correct-Kick-Usage" Value="!color=yellow¡Kick command correct usage: /kick (player) (reason)!/color¡" />
  <Translation Id="Kick-Success1" Value="!color=blue¡Successfully kicked:!/color¡" />
  <Translation Id="Reason" Value="!color=blue¡reason:!/color¡" />
  <Translation Id="For" Value="!color=blue¡for:!/color¡" />
  <Translation Id="Correct-Ban-Usage" Value="!color=yellow¡Ban command correct usage: /ban (player) (reason) (time)!/color¡" />
  <Translation Id="Ban-Success1" Value="!color=blue¡Successfully banned:!/color&gt;" />
  <Translation Id="Invalid-Ban-Format" Value="!color=yellow¡Invalid Player Name or time!/color¡" />
</Translations>
```
# Permissions
Ban: ``moderation.ban``

Kick: ``moderation.kick``
# WebHook preview

https://i.imgur.com/EOvE923.png (You can customize the webhook name and photo)
