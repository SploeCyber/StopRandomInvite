using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;
using System;

namespace StopRandomInvite.Events.OnInvite
{
    public class Invite
    {
        [Target(GameSourceEvent.PlayerInvite, ExecutionMode.Override)]
        public void OnInvite(ShPlayer player, ShPlayer other)
        {
            if (other.isHuman && other.IsUp && player.IsMobile && !player.InOwnApartment)
            {
                other.svPlayer.CustomData.TryFetchCustomData("invitetoggle", out string Ison);
                if (String.Equals(Ison, "true", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (ShApartment apartment in player.ownedApartments.Keys)
                    {
                        if (apartment.DistanceSqr(other) <= Util.inviteDistanceSqr)
                        {
                            other.svPlayer.SvEnterDoor(apartment.ID, player, true);
                            return;
                        }
                    }
                }
                else
                {
                    player.svPlayer.SendGameMessage("〔<color=#546eff>StopRandomInvite</color>〕 |  Target has off the invitation");
                }
            }
        }
    }
}
