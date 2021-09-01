using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;

namespace StopRandomInvite.Commands.InviteToggle
{
    internal class InviteToggle : IScript
    {
        public InviteToggle()
        {
            CommandHandler.RegisterCommand("invitetoggle", new Action<ShPlayer, string>(OnInviteToggle), null, null);
        }

        public void OnInviteToggle(ShPlayer player, string input)
        {
            if (String.Equals(input, "on", StringComparison.OrdinalIgnoreCase))
            {
                player.svPlayer.CustomData.AddOrUpdate("invitetoggle", "true");
                player.svPlayer.SendGameMessage("〔<color=#546eff>StopRandomInvite</color>〕 |  Now everyone can invite you to their home");
            }
            else if (String.Equals(input, "off", StringComparison.OrdinalIgnoreCase))
            {
                player.svPlayer.CustomData.AddOrUpdate("invitetoggle", "false");
                player.svPlayer.SendGameMessage("〔<color=#546eff>StopRandomInvite</color>〕 |  Now no one will be able to invite you to their home");
            }
            else
            {
                player.svPlayer.SendGameMessage("〔<color=#546eff>StopRandomInvite</color>〕 |  Param must be 'on' or 'off' only");
            }
        }
    }

}
