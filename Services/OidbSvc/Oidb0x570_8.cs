﻿using System;
using Konata.Core.Events;
using Konata.Core.Events.Model;
using Konata.Core.Packets;
using Konata.Core.Packets.Oidb.Model;
using Konata.Core.Attributes;

namespace Konata.Core.Services.OidbSvc
{
    [Service("OidbSvc.0x570_8", "Mute member in the group")]
    [EventSubscribe(typeof(GroupMuteMemberEvent))]
    public class Oidb0x570_8 : IService
    {
        public bool Parse(SSOFrame input, BotKeyStore keystore, out ProtocolEvent output)
        {
            throw new NotImplementedException();
        }

        public bool Build(Sequence sequence, GroupMuteMemberEvent input,
            BotKeyStore keystore, BotDevice device, out int newSequence, out byte[] output)
        {
            output = null;
            newSequence = sequence.NewSequence;

            var oidbRequest = new OidbCmd0x570_8(input.GroupUin,
                input.MemberUin, input.TimeSeconds);

            if (SSOFrame.Create("OidbSvc.0x570_8", PacketType.TypeB,
                newSequence, sequence.Session, oidbRequest, out var ssoFrame))
            {
                if (ServiceMessage.Create(ssoFrame, AuthFlag.D2Authentication,
                    keystore.Account.Uin, keystore.Session.D2Token, keystore.Session.D2Key, out var toService))
                {
                    return ServiceMessage.Build(toService, device, out output);
                }
            }

            return false;
        }

        public bool Build(Sequence sequence, ProtocolEvent input,
            BotKeyStore keystore, BotDevice device, out int newSequence, out byte[] output)
            => Build(sequence, (GroupMuteMemberEvent) input, keystore, device, out newSequence, out output);
    }
}
