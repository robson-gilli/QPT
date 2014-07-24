using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ActiveMQConsumerWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IActiveMQListener" in both code and config file together.
    [ServiceContract]
    public interface IActiveMQConsumerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "StartListen/{maxConcurrency}")]
        string StartListen(string maxConcurrency);

        [OperationContract]
        [WebGet(UriTemplate = "StopListen")]
        bool StopListen();

        [OperationContract]
        [WebGet(UriTemplate = "TestSingleton")]
        int TestSingleton();
    }
}
