﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSE445Project3.FileUploadService1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileUploadService1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendFileName", ReplyAction="http://tempuri.org/IService/SendFileNameResponse")]
        void SendFileName(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendFileName", ReplyAction="http://tempuri.org/IService/SendFileNameResponse")]
        System.Threading.Tasks.Task SendFileNameAsync(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendFileAsStream", ReplyAction="http://tempuri.org/IService/SendFileAsStreamResponse")]
        string SendFileAsStream(System.IO.Stream fileContents);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendFileAsStream", ReplyAction="http://tempuri.org/IService/SendFileAsStreamResponse")]
        System.Threading.Tasks.Task<string> SendFileAsStreamAsync(System.IO.Stream fileContents);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StringToFile", ReplyAction="http://tempuri.org/IService/StringToFileResponse")]
        string StringToFile(string fileContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StringToFile", ReplyAction="http://tempuri.org/IService/StringToFileResponse")]
        System.Threading.Tasks.Task<string> StringToFileAsync(string fileContent);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : CSE445Project3.FileUploadService1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<CSE445Project3.FileUploadService1.IService>, CSE445Project3.FileUploadService1.IService {
        
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
        
        public void SendFileName(string fileName) {
            base.Channel.SendFileName(fileName);
        }
        
        public System.Threading.Tasks.Task SendFileNameAsync(string fileName) {
            return base.Channel.SendFileNameAsync(fileName);
        }
        
        public string SendFileAsStream(System.IO.Stream fileContents) {
            return base.Channel.SendFileAsStream(fileContents);
        }
        
        public System.Threading.Tasks.Task<string> SendFileAsStreamAsync(System.IO.Stream fileContents) {
            return base.Channel.SendFileAsStreamAsync(fileContents);
        }
        
        public string StringToFile(string fileContent) {
            return base.Channel.StringToFile(fileContent);
        }
        
        public System.Threading.Tasks.Task<string> StringToFileAsync(string fileContent) {
            return base.Channel.StringToFileAsync(fileContent);
        }
    }
}
