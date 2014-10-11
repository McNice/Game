using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace Client
{
    public class ConnectionManager
    {
        NetClient Client;
        public List<Player> players = new List<Player>();

        public void Initialize(string hostip, string name)
        {
            NetPeerConfiguration Config = new NetPeerConfiguration("ZOMBIE");

            Client = new NetClient(Config);

            NetOutgoingMessage outmsg = Client.CreateMessage();

            Client.Start();

            outmsg.Write((byte)PacketTypes.LOGIN);

            outmsg.Write(name);

            Client.Connect(hostip, 14242, outmsg);

            bool connected = false;

            NetIncomingMessage inc;

            while (!connected)
            {
                if ((inc = Client.ReadMessage()) != null)
                {

                    switch (inc.MessageType)
                    {

                        case NetIncomingMessageType.Data:

                            if (inc.ReadByte() == (byte)PacketTypes.WORLDSTATE)
                            {

                                players.Clear();

                                int count = 0;

                                count = inc.ReadInt32();

                                for (int i = 0; i < count; i++)
                                {

                                    Player p = new Player();

                                    inc.ReadAllProperties(p);

                                    players.Add(p);
                                }

                                // When all players are added to list, start the game
                                connected = true;
                            }
                            break;
                    }
                }
            }

        }

        public void SendMessage(NetOutgoingMessage outmsg)
        {
            Client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendMovement(byte MoveY, byte MoveX)
        {
            NetOutgoingMessage outmsg = Client.CreateMessage();

            outmsg.Write((byte)PacketTypes.MOVE);

            outmsg.Write(MoveY, MoveX);

            SendMessage(outmsg);
        }

        public void ReciveMessage()
        {
            NetIncomingMessage inc;

            while ((inc = Client.ReadMessage()) != null)
            {
                if (inc.MessageType == NetIncomingMessageType.Data)
                {
                    if (inc.ReadByte() == (byte)PacketTypes.WORLDSTATE)
                    {
                        players.Clear();
                        int count = inc.ReadInt32();

                        for (int i = 0; i < count; i++)
                        {
                            Player p = new Player();
                            inc.ReadAllProperties(p);
                            players.Add(p);
                        }
                    }
                }
            }

        }

        public int PlayerCount()
        {
            return players.Count;
        }

        public ConnectionManager() { }
    }

    public class Player
    {
        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }
        public NetConnection connection { get; set; }
        public Player(string name, NetConnection conn)
        {
            this.name = name;
            connection = conn;

            x = 20;
            y = 20;
        }
        public Player() { }

    }

    enum PacketTypes
    {
        LOGIN, MOVE, WORLDSTATE
    }
}
