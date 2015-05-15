﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HydraWebClient.HydraConfigurationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerBindingConfiguration", Namespace="http://schemas.datacontract.org/2004/07/HydraService")]
    [System.SerializableAttribute()]
    public partial class ServerBindingConfiguration : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Net.IPAddress AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EnableSslField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EnforceTLSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PortField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Net.IPAddress Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool EnableSsl {
            get {
                return this.EnableSslField;
            }
            set {
                if ((this.EnableSslField.Equals(value) != true)) {
                    this.EnableSslField = value;
                    this.RaisePropertyChanged("EnableSsl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool EnforceTLS {
            get {
                return this.EnforceTLSField;
            }
            set {
                if ((this.EnforceTLSField.Equals(value) != true)) {
                    this.EnforceTLSField = value;
                    this.RaisePropertyChanged("EnforceTLS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Port {
            get {
                return this.PortField;
            }
            set {
                if ((this.PortField.Equals(value) != true)) {
                    this.PortField = value;
                    this.RaisePropertyChanged("Port");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerSubnetConfiguration", Namespace="http://schemas.datacontract.org/2004/07/HydraService")]
    [System.SerializableAttribute()]
    public partial class ServerSubnetConfiguration : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Net.IPAddress AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SizeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Net.IPAddress Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Size {
            get {
                return this.SizeField;
            }
            set {
                if ((this.SizeField.Equals(value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LocalUser", Namespace="http://schemas.datacontract.org/2004/07/HydraService")]
    [System.SerializableAttribute()]
    public partial class LocalUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MailboxField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mailbox {
            get {
                return this.MailboxField;
            }
            set {
                if ((object.ReferenceEquals(this.MailboxField, value) != true)) {
                    this.MailboxField = value;
                    this.RaisePropertyChanged("Mailbox");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerConfig", Namespace="http://schemas.datacontract.org/2004/07/HydraCore")]
    [System.SerializableAttribute()]
    public partial class ServerConfig : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BannerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GreetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServerNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Banner {
            get {
                return this.BannerField;
            }
            set {
                if ((object.ReferenceEquals(this.BannerField, value) != true)) {
                    this.BannerField = value;
                    this.RaisePropertyChanged("Banner");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Greet {
            get {
                return this.GreetField;
            }
            set {
                if ((object.ReferenceEquals(this.GreetField, value) != true)) {
                    this.GreetField = value;
                    this.RaisePropertyChanged("Greet");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServerName {
            get {
                return this.ServerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ServerNameField, value) != true)) {
                    this.ServerNameField = value;
                    this.RaisePropertyChanged("ServerName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HydraConfigurationService.IConfigurationService")]
    public interface IConfigurationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/SetProperty", ReplyAction="http://tempuri.org/IConfigurationService/SetPropertyResponse")]
        void SetProperty(string name, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/SetProperty", ReplyAction="http://tempuri.org/IConfigurationService/SetPropertyResponse")]
        System.Threading.Tasks.Task SetPropertyAsync(string name, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetServerBindings", ReplyAction="http://tempuri.org/IConfigurationService/GetServerBindingsResponse")]
        HydraWebClient.HydraConfigurationService.ServerBindingConfiguration[] GetServerBindings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetServerBindings", ReplyAction="http://tempuri.org/IConfigurationService/GetServerBindingsResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration[]> GetServerBindingsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/GetServerBindingResponse")]
        HydraWebClient.HydraConfigurationService.ServerBindingConfiguration GetServerBinding(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/GetServerBindingResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration> GetServerBindingAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/AddServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/AddServerBindingResponse")]
        HydraWebClient.HydraConfigurationService.ServerBindingConfiguration AddServerBinding(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/AddServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/AddServerBindingResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration> AddServerBindingAsync(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/UpdateServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/UpdateServerBindingResponse")]
        HydraWebClient.HydraConfigurationService.ServerBindingConfiguration UpdateServerBinding(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/UpdateServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/UpdateServerBindingResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration> UpdateServerBindingAsync(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/DeleteServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/DeleteServerBindingResponse")]
        bool DeleteServerBinding(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/DeleteServerBinding", ReplyAction="http://tempuri.org/IConfigurationService/DeleteServerBindingResponse")]
        System.Threading.Tasks.Task<bool> DeleteServerBindingAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetSubnets", ReplyAction="http://tempuri.org/IConfigurationService/GetSubnetsResponse")]
        HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration[] GetSubnets();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetSubnets", ReplyAction="http://tempuri.org/IConfigurationService/GetSubnetsResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration[]> GetSubnetsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetSubnet", ReplyAction="http://tempuri.org/IConfigurationService/GetSubnetResponse")]
        HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration GetSubnet(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetSubnet", ReplyAction="http://tempuri.org/IConfigurationService/GetSubnetResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration> GetSubnetAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/AddSubnet", ReplyAction="http://tempuri.org/IConfigurationService/AddSubnetResponse")]
        HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration AddSubnet(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/AddSubnet", ReplyAction="http://tempuri.org/IConfigurationService/AddSubnetResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration> AddSubnetAsync(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/UpdateSubnet", ReplyAction="http://tempuri.org/IConfigurationService/UpdateSubnetResponse")]
        HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration UpdateSubnet(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/UpdateSubnet", ReplyAction="http://tempuri.org/IConfigurationService/UpdateSubnetResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration> UpdateSubnetAsync(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/DeleteSubnet", ReplyAction="http://tempuri.org/IConfigurationService/DeleteSubnetResponse")]
        bool DeleteSubnet(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/DeleteSubnet", ReplyAction="http://tempuri.org/IConfigurationService/DeleteSubnetResponse")]
        System.Threading.Tasks.Task<bool> DeleteSubnetAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetLocalUsers", ReplyAction="http://tempuri.org/IConfigurationService/GetLocalUsersResponse")]
        HydraWebClient.HydraConfigurationService.LocalUser[] GetLocalUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetLocalUsers", ReplyAction="http://tempuri.org/IConfigurationService/GetLocalUsersResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser[]> GetLocalUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/GetLocalUserResponse")]
        HydraWebClient.HydraConfigurationService.LocalUser GetLocalUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/GetLocalUserResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser> GetLocalUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/AddLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/AddLocalUserResponse")]
        HydraWebClient.HydraConfigurationService.LocalUser AddLocalUser(HydraWebClient.HydraConfigurationService.LocalUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/AddLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/AddLocalUserResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser> AddLocalUserAsync(HydraWebClient.HydraConfigurationService.LocalUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/UpdateLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/UpdateLocalUserResponse")]
        HydraWebClient.HydraConfigurationService.LocalUser UpdateLocalUser(HydraWebClient.HydraConfigurationService.LocalUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/UpdateLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/UpdateLocalUserResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser> UpdateLocalUserAsync(HydraWebClient.HydraConfigurationService.LocalUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/DeleteLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/DeleteLocalUserResponse")]
        bool DeleteLocalUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/DeleteLocalUser", ReplyAction="http://tempuri.org/IConfigurationService/DeleteLocalUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteLocalUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetServerConfig", ReplyAction="http://tempuri.org/IConfigurationService/GetServerConfigResponse")]
        HydraWebClient.HydraConfigurationService.ServerConfig GetServerConfig();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/GetServerConfig", ReplyAction="http://tempuri.org/IConfigurationService/GetServerConfigResponse")]
        System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerConfig> GetServerConfigAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/SetServerConfig", ReplyAction="http://tempuri.org/IConfigurationService/SetServerConfigResponse")]
        bool SetServerConfig(HydraWebClient.HydraConfigurationService.ServerConfig config);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConfigurationService/SetServerConfig", ReplyAction="http://tempuri.org/IConfigurationService/SetServerConfigResponse")]
        System.Threading.Tasks.Task<bool> SetServerConfigAsync(HydraWebClient.HydraConfigurationService.ServerConfig config);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConfigurationServiceChannel : HydraWebClient.HydraConfigurationService.IConfigurationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConfigurationServiceClient : System.ServiceModel.ClientBase<HydraWebClient.HydraConfigurationService.IConfigurationService>, HydraWebClient.HydraConfigurationService.IConfigurationService {
        
        public ConfigurationServiceClient() {
        }
        
        public ConfigurationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConfigurationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConfigurationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConfigurationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SetProperty(string name, string value) {
            base.Channel.SetProperty(name, value);
        }
        
        public System.Threading.Tasks.Task SetPropertyAsync(string name, string value) {
            return base.Channel.SetPropertyAsync(name, value);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerBindingConfiguration[] GetServerBindings() {
            return base.Channel.GetServerBindings();
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration[]> GetServerBindingsAsync() {
            return base.Channel.GetServerBindingsAsync();
        }
        
        public HydraWebClient.HydraConfigurationService.ServerBindingConfiguration GetServerBinding(int id) {
            return base.Channel.GetServerBinding(id);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration> GetServerBindingAsync(int id) {
            return base.Channel.GetServerBindingAsync(id);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerBindingConfiguration AddServerBinding(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding) {
            return base.Channel.AddServerBinding(binding);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration> AddServerBindingAsync(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding) {
            return base.Channel.AddServerBindingAsync(binding);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerBindingConfiguration UpdateServerBinding(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding) {
            return base.Channel.UpdateServerBinding(binding);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerBindingConfiguration> UpdateServerBindingAsync(HydraWebClient.HydraConfigurationService.ServerBindingConfiguration binding) {
            return base.Channel.UpdateServerBindingAsync(binding);
        }
        
        public bool DeleteServerBinding(int id) {
            return base.Channel.DeleteServerBinding(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteServerBindingAsync(int id) {
            return base.Channel.DeleteServerBindingAsync(id);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration[] GetSubnets() {
            return base.Channel.GetSubnets();
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration[]> GetSubnetsAsync() {
            return base.Channel.GetSubnetsAsync();
        }
        
        public HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration GetSubnet(int id) {
            return base.Channel.GetSubnet(id);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration> GetSubnetAsync(int id) {
            return base.Channel.GetSubnetAsync(id);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration AddSubnet(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet) {
            return base.Channel.AddSubnet(subnet);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration> AddSubnetAsync(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet) {
            return base.Channel.AddSubnetAsync(subnet);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration UpdateSubnet(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet) {
            return base.Channel.UpdateSubnet(subnet);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration> UpdateSubnetAsync(HydraWebClient.HydraConfigurationService.ServerSubnetConfiguration subnet) {
            return base.Channel.UpdateSubnetAsync(subnet);
        }
        
        public bool DeleteSubnet(int id) {
            return base.Channel.DeleteSubnet(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteSubnetAsync(int id) {
            return base.Channel.DeleteSubnetAsync(id);
        }
        
        public HydraWebClient.HydraConfigurationService.LocalUser[] GetLocalUsers() {
            return base.Channel.GetLocalUsers();
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser[]> GetLocalUsersAsync() {
            return base.Channel.GetLocalUsersAsync();
        }
        
        public HydraWebClient.HydraConfigurationService.LocalUser GetLocalUser(int id) {
            return base.Channel.GetLocalUser(id);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser> GetLocalUserAsync(int id) {
            return base.Channel.GetLocalUserAsync(id);
        }
        
        public HydraWebClient.HydraConfigurationService.LocalUser AddLocalUser(HydraWebClient.HydraConfigurationService.LocalUser user) {
            return base.Channel.AddLocalUser(user);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser> AddLocalUserAsync(HydraWebClient.HydraConfigurationService.LocalUser user) {
            return base.Channel.AddLocalUserAsync(user);
        }
        
        public HydraWebClient.HydraConfigurationService.LocalUser UpdateLocalUser(HydraWebClient.HydraConfigurationService.LocalUser user) {
            return base.Channel.UpdateLocalUser(user);
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.LocalUser> UpdateLocalUserAsync(HydraWebClient.HydraConfigurationService.LocalUser user) {
            return base.Channel.UpdateLocalUserAsync(user);
        }
        
        public bool DeleteLocalUser(int id) {
            return base.Channel.DeleteLocalUser(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteLocalUserAsync(int id) {
            return base.Channel.DeleteLocalUserAsync(id);
        }
        
        public HydraWebClient.HydraConfigurationService.ServerConfig GetServerConfig() {
            return base.Channel.GetServerConfig();
        }
        
        public System.Threading.Tasks.Task<HydraWebClient.HydraConfigurationService.ServerConfig> GetServerConfigAsync() {
            return base.Channel.GetServerConfigAsync();
        }
        
        public bool SetServerConfig(HydraWebClient.HydraConfigurationService.ServerConfig config) {
            return base.Channel.SetServerConfig(config);
        }
        
        public System.Threading.Tasks.Task<bool> SetServerConfigAsync(HydraWebClient.HydraConfigurationService.ServerConfig config) {
            return base.Channel.SetServerConfigAsync(config);
        }
    }
}