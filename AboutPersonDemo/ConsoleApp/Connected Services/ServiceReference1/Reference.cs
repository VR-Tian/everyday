﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICalculatorDuplex", CallbackContract=typeof(ConsoleApp.ServiceReference1.ICalculatorDuplexCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ICalculatorDuplex {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculatorDuplex/Upload")]
        void Upload(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculatorDuplex/Upload")]
        System.Threading.Tasks.Task UploadAsync(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorDuplex/Subscribe", ReplyAction="http://tempuri.org/ICalculatorDuplex/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorDuplex/Subscribe", ReplyAction="http://tempuri.org/ICalculatorDuplex/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="http://tempuri.org/ICalculatorDuplex/Unsubscribe", ReplyAction="http://tempuri.org/ICalculatorDuplex/UnsubscribeResponse")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="http://tempuri.org/ICalculatorDuplex/Unsubscribe", ReplyAction="http://tempuri.org/ICalculatorDuplex/UnsubscribeResponse")]
        System.Threading.Tasks.Task UnsubscribeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorDuplexCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculatorDuplex/SendMsgToClient")]
        void SendMsgToClient(string serviceMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorDuplexChannel : ConsoleApp.ServiceReference1.ICalculatorDuplex, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorDuplexClient : System.ServiceModel.DuplexClientBase<ConsoleApp.ServiceReference1.ICalculatorDuplex>, ConsoleApp.ServiceReference1.ICalculatorDuplex {
        
        public CalculatorDuplexClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CalculatorDuplexClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CalculatorDuplexClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorDuplexClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorDuplexClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Upload(string msg) {
            base.Channel.Upload(msg);
        }
        
        public System.Threading.Tasks.Task UploadAsync(string msg) {
            return base.Channel.UploadAsync(msg);
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
    }
}
