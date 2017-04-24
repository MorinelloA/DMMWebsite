using DualMeetManager.Service.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMMLib;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;

namespace DualMeetManager.Service.Saving
{
    /// <summary>
    /// Summary description for MeetServerDBSvcImpl
    /// </summary>
    public class MeetServerDBSvcImpl : IMeetDBSvc
    {
        object obj1, obj2, returnedObj;
        string message;

        private void SendToServer()
        {
            TcpClient tcpClient = new TcpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1313);
            tcpClient.Connect(endPoint);
            NetworkStream stream = tcpClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            //User userToCheck = new User(txtUsername.Text, txtPassword.Text);
            CommObj co = new CommObj(message, obj1, obj2);
            bf.Serialize(stream, co);
            returnedObj = (object)bf.Deserialize(stream);
        }

        public bool AddBoysTeam(Meet meet)
        {
            message = "AddBoysTeam";
            obj1 = (object)meet;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool AddGirlsTeam(Meet meet)
        {
            message = "AddGirlsTeam";
            obj1 = (object)meet;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool AddMeet(Meet meet, string user)
        {
            message = "AddMeet";
            obj1 = (object)meet;
            obj2 = (object)user;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool AddPerformance(Meet meet, string eventName)
        {
            message = "AddPerformance";
            obj1 = (object)meet;
            obj2 = (object)eventName;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool AddPerformances(Meet meet)
        {
            message = "AddPerformances";
            obj1 = (object)meet;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool DeleteBoysTeam(int id)
        {
            message = "DeleteBoysTeam";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool DeleteGirlsTeam(int id)
        {
            message = "DeleteGirlsTeam";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool DeleteMeet(int id)
        {
            message = "DeleteMeet";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool DeletePerformance(int id, string eventName)
        {
            message = "DeletePerformance";
            obj1 = (object)id;
            obj2 = (object)eventName;
            SendToServer();

            return (bool)returnedObj;
        }

        public bool DeletePerformances(int id)
        {
            message = "DeletePerformances";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (bool)returnedObj;
        }

        public Dictionary<string, string> FindBoysTeam(int id)
        {
            message = "FindBoysTeam";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (Dictionary<string, string>)returnedObj;
        }

        public Dictionary<string, string> FindGirlsTeam(int id)
        {
            message = "FindGirlsTeam";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (Dictionary<string, string>)returnedObj;
        }

        public Meet FindMeet(int id)
        {
            message = "FindMeet";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (Meet)returnedObj;
        }

        public int FindMeetId(Meet meet)
        {
            message = "FindMeetId";
            obj1 = (object)meet;
            obj2 = null;
            SendToServer();

            return (int)returnedObj;
        }

        public Dictionary<string, List<Performance>> FindPerformances(int id)
        {
            message = "FindPerformancesDictionary";
            obj1 = (object)id;
            obj2 = null;
            SendToServer();

            return (Dictionary<string, List<Performance>>)returnedObj;
        }

        public List<Performance> FindPerformances(int id, string eventName)
        {
            message = "FindPerformancesList";
            obj1 = (object)id;
            obj2 = (object)eventName;
            SendToServer();

            return (List<Performance>)returnedObj;
        }

        public Dictionary<int, Meet> ListOfMeets(string user)
        {
            message = "ListOfMeets";
            obj1 = (object)user;
            obj2 = null;
            SendToServer();

            return (Dictionary<int, Meet>)returnedObj;
        }

        public bool ResetPrimaryKeys()
        {
            Console.WriteLine("ResetPrimaryKeys() Not yet implemented. Still works without");
            return true;
        }
    }
}