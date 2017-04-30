using DMMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMMWCFLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        bool AuthenticateUser(string username, string password);

        [OperationContract]
        bool CreateUser(string username, string password);

        [OperationContract]
        bool AddMeet(Meet meet, string user);

        [OperationContract]
        int FindMeetId(Meet meet);

        [OperationContract]
        Meet FindMeet(int id);

        [OperationContract]
        bool DeleteMeet(int id);

        [OperationContract]
        bool AddBoysTeam(Meet meet);

        [OperationContract]
        Dictionary<string, string> FindBoysTeam(int id);

        [OperationContract]
        bool DeleteBoysTeam(int id);

        [OperationContract]
        bool AddGirlsTeam(Meet meet);

        [OperationContract]
        Dictionary<string, string> FindGirlsTeam(int id);

        [OperationContract]
        bool DeleteGirlsTeam(int id);

        [OperationContract]
        bool AddPerformances(Meet meet);

        [OperationContract]
        bool AddPerformance(Meet meet, string eventName);

        [OperationContract]
        Dictionary<string, List<Performance>> FindPerformancesDictionary(int id);

        [OperationContract]
        List<Performance> FindPerformancesList(int id, string eventName);

        [OperationContract]
        bool DeletePerformances(int id);

        [OperationContract]
        bool DeletePerformance(int id, string eventName);

        [OperationContract]
        Dictionary<int, Meet> ListOfMeets(string user);

        [OperationContract]
        bool ResetPrimaryKeys();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DMMWCFLib.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
