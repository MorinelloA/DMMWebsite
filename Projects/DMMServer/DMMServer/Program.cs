using DMMServer.Business.Managers;
//using DMMServer.Domain;
using DMMLib;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
//using DMMServer.Service.SocketSvc;
using System.Threading;

namespace DMMServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = null;
            try
            {
                int portNum = 1313;
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(ipAddr, portNum);

                listener.Start();

                while(true)
                {
                    Console.WriteLine("Waiting for connection...");
                    TcpClient tcpClient = listener.AcceptTcpClient();

                    //Start Multithread stuff
                    TCPClientServer ss = new TCPClientServer(tcpClient);
                    Thread thread = new Thread(new ThreadStart(ss.Run));
                    thread.Start();
                    //End Multithread stuff

                    //Moved to TCPClientServer class
                    /*
                    NetworkStream stream = tcpClient.GetStream();

                    BinaryFormatter bf = new BinaryFormatter();
                    bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    object o = bf.Deserialize(stream);
                    CommObj commobj = o as CommObj;
                    Console.WriteLine("new " + commobj.command + " request");
                    if(commobj.command == "AuthenticateUser")
                    {
                        Console.WriteLine("Authenticating User");
                        try
                        {
                            User myUser = (User)commobj.myObject;
                            ServerMgr sm = new ServerMgr();
                            //IdentityUser iu = sm.AuthenticateUser(myUser.username, myUser.password);
                            bool iu = sm.AuthenticateUser(myUser.username, myUser.password);

                            if(iu)
                            {
                                Console.WriteLine(myUser.username + " Authenticated");
                            }
                            else
                            {
                                Console.WriteLine(myUser.username + " NOT Authenticated");
                            }

                            bf.Serialize(stream, iu); //May not be correct
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Exception: " + e);
                        }
                    }
                    else if(commobj.command == "CreateUser")
                    {
                        Console.WriteLine("Creating New User");
                        try
                        {
                            User myUser = (User)commobj.myObject;
                            ServerMgr sm = new ServerMgr();
                            //IdentityResult ir = sm.CreateUser(myUser.username, myUser.password);
                            bool ir = sm.CreateUser(myUser.username, myUser.password);

                            if (ir)
                            {
                                Console.WriteLine(myUser.username + " Created");
                            }
                            else
                            {
                                Console.WriteLine(myUser.username + " NOT Created");
                            }

                            bf.Serialize(stream, ir);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Exception: " + e);
                        }
                    }
                    */

                    //This SHOULD be needed. Taken out for testing
                    //tcpClient.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: " + e);
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
