﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSE445Project3.CredentialsService1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CredentialsService1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SubmitUserCredentials", ReplyAction="http://tempuri.org/IService/SubmitUserCredentialsResponse")]
        string SubmitUserCredentials(string user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SubmitUserCredentials", ReplyAction="http://tempuri.org/IService/SubmitUserCredentialsResponse")]
        System.Threading.Tasks.Task<string> SubmitUserCredentialsAsync(string user, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : CSE445Project3.CredentialsService1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<CSE445Project3.CredentialsService1.IService>, CSE445Project3.CredentialsService1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SubmitUserCredentials(string user, string password) {
            return base.Channel.SubmitUserCredentials(user, password);
        }
        
        public System.Threading.Tasks.Task<string> SubmitUserCredentialsAsync(string user, string password) {
            return base.Channel.SubmitUserCredentialsAsync(user, password);
        }
    }
}
