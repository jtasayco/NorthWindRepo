﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18408
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWind.Win.ProxyDocumento {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EventArgs", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NorthWind.Entity.TbProductoBE))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NorthWind.Entity.TbClienteBE))]
    public partial class EventArgs : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyDocumento.IDocService")]
    public interface IDocService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDocService/GuardarDocumento")]
        void GuardarDocumento(NorthWind.Entity.DocumentoBE oDocumentoDTO);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDocService/GuardarDocumento")]
        System.Threading.Tasks.Task GuardarDocumentoAsync(NorthWind.Entity.DocumentoBE oDocumentoDTO);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDocServiceChannel : NorthWind.Win.ProxyDocumento.IDocService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DocServiceClient : System.ServiceModel.ClientBase<NorthWind.Win.ProxyDocumento.IDocService>, NorthWind.Win.ProxyDocumento.IDocService {
        
        public DocServiceClient() {
        }
        
        public DocServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DocServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void GuardarDocumento(NorthWind.Entity.DocumentoBE oDocumentoDTO) {
            base.Channel.GuardarDocumento(oDocumentoDTO);
        }
        
        public System.Threading.Tasks.Task GuardarDocumentoAsync(NorthWind.Entity.DocumentoBE oDocumentoDTO) {
            return base.Channel.GuardarDocumentoAsync(oDocumentoDTO);
        }
    }
}
