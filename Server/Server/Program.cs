using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace Server
{
    class Program
    {
        static NetServer Server;
        static NetPeerConfiguration Config;

        static void Main(string[] args)
        {

            #region ServerConfigs
            Config = new NetPeerConfiguration("ZOMBIE");

            Config.Port = 14242;

            Config.MaximumConnections = 4;

            Config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

            Server = new NetServer(Config);

            Server.Start();

            Console.WriteLine("Server Started");

            NetIncomingMessage inc;

            DateTime time = DateTime.Now;

            TimeSpan timeToPass = new TimeSpan(0, 0, 0, 0, 4);

            Console.WriteLine("Waiting for connections");
            #endregion


            #region GameConfigs

            List<Player> players = new List<Player>();


            #endregion


            while (true)
            {
                if ((inc = Server.ReadMessage()) != null)
                {
                    switch (inc.MessageType)
                    {
                        case NetIncomingMessageType.ConnectionApproval:

                            if (inc.ReadByte() == (byte)PacketTypes.LOGIN)
                            {
                                Console.WriteLine("Incoming LOGIN");

                                inc.SenderConnection.Approve();

                                players.Add(new Player(inc.ReadString(), inc.SenderConnection));

                                NetOutgoingMessage outmsg = Server.CreateMessage();

                                outmsg.Write((byte)PacketTypes.WORLDSTATE);

                                outmsg.Write(players.Count);

                                foreach (Player p in players)
                                {
                                    outmsg.WriteAllProperties(p);
                                }

                                Server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);

                            }
                            break;

                        case NetIncomingMessageType.Data:
                            if (inc.ReadByte() == (byte)PacketTypes.MOVE)
                            {
                                foreach (Player p in players)
                                {
                                    if (p.connection != inc.SenderConnection)
                                        continue;

                                    byte y = inc.ReadByte();
                                    byte x = inc.ReadByte();

                                    if ((byte)MoveY.UP == y && (byte)MoveX.NONE == x) {
                                        p.y--;
                                    }
                                    if ((byte)MoveY.UP == y && (byte)MoveX.RIGHT == x) {
                                        p.y--;
                                        p.x++;
                                    }
                                    if ((byte)MoveY.NONE == y && (byte)MoveX.RIGHT == x) {
                                        p.x++;
                                    }
                                    if ((byte)MoveY.DOWN == y && (byte)MoveX.RIGHT == x) {
                                        p.y++;
                                        p.x++;
                                    }
                                    if ((byte)MoveY.DOWN == y && (byte)MoveX.NONE == x) {
                                        p.y++;
                                    }
                                    if ((byte)MoveY.DOWN == y && (byte)MoveX.LEFT == x) {
                                        p.y++;
                                        p.x--;
                                    }
                                    if ((byte)MoveY.NONE == y && (byte)MoveX.LEFT == x) {
                                        p.x--;
                                    }
                                    if ((byte)MoveY.UP == y && (byte)MoveX.LEFT == x) {
                                        p.y--;
                                        p.x--;
                                    }

                                    NetOutgoingMessage outmsg = Server.CreateMessage();

                                    outmsg.Write((byte)PacketTypes.WORLDSTATE);

                                    outmsg.Write(players.Count);

                                    foreach (Player p2 in players)
                                    {
                                        outmsg.WriteAllProperties(p2);
                                    }

                                    Server.SendMessage(outmsg, Server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                                    break;
                                }
                            }
                            break;

                        case NetIncomingMessageType.StatusChanged:
                            Console.WriteLine(inc.SenderConnection.ToString() + " status changed. " + (NetConnectionStatus)inc.SenderConnection.Status);
                            if (inc.SenderConnection.Status == NetConnectionStatus.Disconnected || inc.SenderConnection.Status == NetConnectionStatus.Disconnecting)
                            {
                                foreach (Player p in players)
                                {
                                    if (p.connection == inc.SenderConnection)
                                    {
                                        players.Remove(p);
                                        break;
                                    }
                                }
                            }
                            break;
                    }
                }

                if ((time + timeToPass) < DateTime.Now)
                {

                    if (Server.ConnectionsCount != 0)
                    {
                        NetOutgoingMessage outmsg = Server.CreateMessage();

                        outmsg.Write((byte)PacketTypes.WORLDSTATE);

                        outmsg.Write(players.Count);

                        foreach (Player p in players)
                        {
                            outmsg.WriteAllProperties(p);
                        }

                        Server.SendMessage(outmsg, Server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                    }
                    time = DateTime.Now;
                }
            }
        }

        class Player
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
        }

        enum PacketTypes
        {
            LOGIN, MOVE, WORLDSTATE
        }

        enum MoveY
        {
            UP,
            DOWN,
            NONE
        }

        enum MoveX
        {
            RIGHT,
            LEFT,
            NONE
        }
    }
}
