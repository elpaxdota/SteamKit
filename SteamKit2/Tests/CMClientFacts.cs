﻿using System;
using System.IO;
using System.Reflection;
using SteamKit2;
using SteamKit2.Internal;
using Xunit;

namespace Tests
{
    public class CMClientFacts
    {
        [Fact]
        public void GetPacketMsgReturnsPacketMsgForCryptoHandshake()
        {
            var messages = new[]
            {
                EMsg.ChannelEncryptRequest,
                EMsg.ChannelEncryptResponse,
                EMsg.ChannelEncryptResult
            };

            foreach(var emsg in messages)
            {
                var msgHdr = new MsgHdr { Msg = emsg };

                var data = Serialize(msgHdr);

                var packetMsg = CMClient.GetPacketMsg(data);
                Assert.IsAssignableFrom<PacketMsg>(packetMsg);
            }
        }

        [Fact]
        public void GetPacketMsgReturnsPacketClientMsgProtobufForMessagesWithProtomask()
        {
            var msg = MsgUtil.MakeMsg(EMsg.ClientLogOnResponse, protobuf: true);
            var msgHdr = new MsgHdrProtoBuf { Msg = msg };

            var data = Serialize(msgHdr);
            var packetMsg = CMClient.GetPacketMsg(data);
            Assert.IsAssignableFrom<PacketClientMsgProtobuf>(packetMsg);
        }

        [Fact]
        public void GetPacketMsgReturnsPacketClientMsgForOtherMessages()
        {
            var msg = MsgUtil.MakeMsg(EMsg.ClientLogOnResponse, protobuf: false);
            var msgHdr = new ExtendedClientMsgHdr { Msg = msg };

            var data = Serialize(msgHdr);
            var packetMsg = CMClient.GetPacketMsg(data);
            Assert.IsAssignableFrom<PacketClientMsg>(packetMsg);
        }

        [Fact]
        public void GetPacketMsgFailsWithNull()
        {
            var msg = MsgUtil.MakeMsg(EMsg.ClientLogOnResponse, protobuf: true);
            var msgHdr = new MsgHdrProtoBuf { Msg = msg };

            var data = Serialize(msgHdr);
            Array.Copy(BitConverter.GetBytes(-1), 0, data, 4, 4);
            var packetMsg = CMClient.GetPacketMsg(data);
            Assert.Null(packetMsg);
        }

        [Fact]
        public void ServerLookupIsClearedWhenDisconnecting()
        {
            var msg = new ClientMsgProtobuf<CMsgClientServerList>( EMsg.ClientServerList );
            msg.Body.servers.Add( new CMsgClientServerList.Server
            {
                server_type = ( int )EServerType.CM,
                server_ip = 0x7F000001, // 127.0.0.1
                server_port = 1234
            });

            var client = new DummyCMClient();
            client.HandleClientMsg( msg );

            Assert.Equal( 1, client.GetServersOfType( EServerType.CM ).Count );

            client.DummyDisconnect();
            Assert.Equal( 0, client.GetServersOfType( EServerType.CM ).Count );
        }

        [Fact]
        public void ServerLookupDoesNotAccumulateDuplicates()
        {
            var msg = new ClientMsgProtobuf<CMsgClientServerList>( EMsg.ClientServerList );
            msg.Body.servers.Add( new CMsgClientServerList.Server
            {
                server_type = ( int )EServerType.CM,
                server_ip = 0x7F000001, // 127.0.0.1
                server_port = 1234
            });

            var client = new DummyCMClient();
            client.HandleClientMsg( msg );
            Assert.Equal( 1, client.GetServersOfType( EServerType.CM ).Count );

            client.HandleClientMsg( msg );
            Assert.Equal( 1, client.GetServersOfType( EServerType.CM ).Count );
        }

        static byte[] Serialize(ISteamSerializableHeader hdr)
        {
            using (var ms = new MemoryStream())
            {
                hdr.Serialize(ms);
                return ms.ToArray();
            }
        }

        class DummyCMClient : CMClient
        {
            public DummyCMClient()
            {
                PretendEncryptionIsSetUp();
            }

            public void DummyDisconnect()
            {
                Disconnect();
                OnClientDisconnected( true );
            }

            public void HandleClientMsg( IClientMsg clientMsg )
                => OnClientMsgReceived( GetPacketMsg( clientMsg.Serialize() ) );

            void PretendEncryptionIsSetUp()
            {
                var field = typeof( CMClient ).GetField( "encryptionSetup", BindingFlags.Instance | BindingFlags.NonPublic );
                field.SetValue( this, true );
            }
        }
    }
}