using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace AbountCORS.WCFService
{
    [ServiceContract(SessionMode = SessionMode.Required,
      CallbackContract = typeof(ICalculatorDuplex))]
    public interface ISampleContract
    {

    }
}