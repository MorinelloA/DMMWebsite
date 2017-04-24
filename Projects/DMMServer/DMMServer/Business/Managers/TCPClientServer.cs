using DMMLib;
using DMMServer.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DMMServer.Business.Managers
{
    public class TCPClientServer
    {
        private TcpClient tcpClient = null;
        public TCPClientServer(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }

        public void Run()
        {
            NetworkStream stream = tcpClient.GetStream();

            BinaryFormatter bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            object o = bf.Deserialize(stream);
            CommObj commobj = o as CommObj;
            Console.WriteLine("new " + commobj.command + " request");
            if (commobj.command == "AuthenticateUser")
            {
                Console.WriteLine("Authenticating User");
                try
                {
                    User myUser = (User)commobj.myObject;
                    ServerMgr sm = new ServerMgr();
                    //IdentityUser iu = sm.AuthenticateUser(myUser.username, myUser.password);
                    bool iu = sm.AuthenticateUser(myUser.username, myUser.password);

                    if (iu)
                    {
                        Console.WriteLine(myUser.username + " Authenticated");
                    }
                    else
                    {
                        Console.WriteLine(myUser.username + " NOT Authenticated");
                    }

                    bf.Serialize(stream, iu); //May not be correct
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "CreateUser")
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
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if(commobj.command == "AddMeet")
            {
                Console.WriteLine("Add Meet");
                try
                {
                    //bool AddMeet(Meet meet, string user);
                    Meet meet = (Meet)commobj.myObject;
                    string user = commobj.myObject2.ToString();

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool result = mdbm.AddMeet(meet, user);

                    if (result)
                    {
                        Console.WriteLine("Meet for " + user + " Added");
                    }
                    else
                    {
                        Console.WriteLine("Problem adding Meet for " + user + " Added");
                    }

                    bf.Serialize(stream, result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "FindMeetId")
            {
                Console.WriteLine("Find Meet ID");
                try
                {
                    //int FindMeetId(Meet meet);
                    Meet meet = (Meet)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    int meetID = mdbm.FindMeetId(meet);

                    Console.WriteLine("Meet found, ID:" + meetID);

                    bf.Serialize(stream, meetID);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "FindMeet")
            {
                Console.WriteLine("Find Meet");
                try
                {
                    //Meet FindMeet(int id);
                    int meetID = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    Meet myMeet = mdbm.FindMeet(meetID);

                    Console.WriteLine("Meet found at:" + meetID);

                    bf.Serialize(stream, myMeet);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "DeleteMeet")
            {
                //public bool DeleteMeet(int id)
                Console.WriteLine("Delete Meet");
                try
                {
                    //Meet FindMeet(int id);
                    int meetID = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didDelete = mdbm.DeleteMeet(meetID);

                    Console.WriteLine("Meet deleted? " + didDelete);

                    bf.Serialize(stream, didDelete);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "AddBoysTeam")
            {
                //public bool AddBoysTeam(Meet meet)
                Console.WriteLine("Add Boys Team");
                try
                {
                    //Meet FindMeet(int id);
                    Meet meet = (Meet)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didAdd = mdbm.AddBoysTeam(meet);

                    Console.WriteLine("Meet added? " + didAdd);

                    bf.Serialize(stream, didAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "FindBoysTeam")
            {
                //public Dictionary<string, string> FindBoysTeam(int id)
                Console.WriteLine("Find Boys Team");
                try
                {
                    //Meet FindMeet(int id);
                    int id = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    Dictionary<string, string> boysTeam = mdbm.FindBoysTeam(id);

                    Console.WriteLine("Meet Dictionary Created and being sent");

                    bf.Serialize(stream, boysTeam);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "DeleteBoysTeam")
            {
                //public bool DeleteBoysTeam(int id)
                Console.WriteLine("Delete Boys Team");
                try
                {
                    //Meet FindMeet(int id);
                    int id = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didDelete = mdbm.DeleteBoysTeam(id);

                    Console.WriteLine("Meet Deleted at: " + id);

                    bf.Serialize(stream, didDelete);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "AddGirlsTeam")
            {
                //public bool AddGirlsTeam(Meet meet)
                Console.WriteLine("Add Girls Team");
                try
                {
                    //Meet FindMeet(int id);
                    Meet meet = (Meet)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didAdd = mdbm.AddGirlsTeam(meet);

                    Console.WriteLine("Meet added? " + didAdd);

                    bf.Serialize(stream, didAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "FindGirlsTeam")
            {
                //public Dictionary<string, string> FindGirlsTeam(int id)
                Console.WriteLine("Find Girls Team");
                try
                {
                    //Meet FindMeet(int id);
                    int id = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    Dictionary<string, string> girlsTeam = mdbm.FindGirlsTeam(id);

                    Console.WriteLine("Meet Dictionary Created and being sent");

                    bf.Serialize(stream, girlsTeam);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "DeleteGirlsTeam")
            {
                //public bool DeleteGirlsTeam(int id)
                Console.WriteLine("Delete Girls Team");
                try
                {
                    //Meet FindMeet(int id);
                    int id = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didDelete = mdbm.DeleteGirlsTeam(id);

                    Console.WriteLine("Meet Deleted at: " + id);

                    bf.Serialize(stream, didDelete);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "AddPerformances")
            {
                //public bool AddPerformances(Meet meet)
                Console.WriteLine("Add Performances");
                try
                {
                    Meet meet = (Meet)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didAdd = mdbm.AddPerformances(meet);

                    Console.WriteLine("Performances Added? " + didAdd);

                    bf.Serialize(stream, didAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "AddPerformance")
            {
                //public bool AddPerformance(Meet meet, string eventName)
                Console.WriteLine("Add Performance");
                try
                {
                    Meet meet = (Meet)commobj.myObject;
                    string eventName = commobj.myObject2.ToString();

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didAdd = mdbm.AddPerformance(meet, eventName);

                    Console.WriteLine("Performances Added? " + didAdd);

                    bf.Serialize(stream, didAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "FindPerformancesDictionary")
            {
                //public Dictionary<string, List<Performance>> FindPerformances(int id)
                Console.WriteLine("Find Performances - List");
                try
                {
                    int id = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    Dictionary<string, List<Performance>> myDictionary = mdbm.FindPerformances(id);

                    Console.WriteLine("Dictionary of Performances added and being sent");

                    bf.Serialize(stream, myDictionary);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "FindPerformancesList")
            {
                //public List<Performance> FindPerformances(int id, string eventName)
                Console.WriteLine("Find Performancess - Dictionary");
                try
                {
                    int id = (int)commobj.myObject;
                    string eventName = commobj.myObject2.ToString();

                    MeetDBMgr mdbm = new MeetDBMgr();
                    List<Performance> myList = mdbm.FindPerformances(id, eventName);

                    Console.WriteLine("List of Performances added and being sent");

                    bf.Serialize(stream, myList);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "DeletePerformances")
            {
                //public bool DeletePerformances(int id)
                Console.WriteLine("Delete Performances");
                try
                {
                    int id = (int)commobj.myObject;

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didDelete = mdbm.DeletePerformances(id);

                    Console.WriteLine("Performances deleted? " + didDelete);

                    bf.Serialize(stream, didDelete);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "DeletePerformance")
            {
                //public bool DeletePerformance(int id, string eventName)
                Console.WriteLine("Delete Performance");
                try
                {
                    int id = (int)commobj.myObject;
                    string eventName = commobj.myObject2.ToString();

                    MeetDBMgr mdbm = new MeetDBMgr();
                    bool didDelete = mdbm.DeletePerformance(id, eventName);

                    Console.WriteLine("Performance deleted? " + didDelete);

                    bf.Serialize(stream, didDelete);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else if (commobj.command == "ListOfMeets")
            {
                //public Dictionary<int, Meet> ListOfMeets(string user)
                Console.WriteLine("List Of Meets");
                try
                {
                    string user = commobj.myObject.ToString();

                    MeetDBMgr mdbm = new MeetDBMgr();
                    Dictionary<int, Meet> listOfMeets = mdbm.ListOfMeets(user);

                    Console.WriteLine("List of meets gathered and being sent");

                    bf.Serialize(stream, listOfMeets);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }
            else
            {
                Console.WriteLine(commobj.command + " command not found in TCPClientServer");
            }
            
            tcpClient.Close();
        }
    }
}
