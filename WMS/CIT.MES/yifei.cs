using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Web", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="IYiFeiGatewayExbinding", Namespace="http://tempuri.org/")]
public partial class IYiFeiGatewayExservice : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    /// <remarks/>
    public IYiFeiGatewayExservice() {
        this.Url = CIT.MES.PubUtils.ERPURL;// "http://192.168.1.10:8082/soap/IYiFeiGatewayEx";
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:YiFeiGatewayExIntf-IYiFeiGatewayEx#YiFeiGatewayEx", RequestNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx", ResponseNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public string YiFeiGatewayEx(string Input) {
        object[] results = this.Invoke("YiFeiGatewayEx", new object[] {
                    Input});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginYiFeiGatewayEx(string Input, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("YiFeiGatewayEx", new object[] {
                    Input}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndYiFeiGatewayEx(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:YiFeiGatewayExIntf-IYiFeiGatewayEx#invokeSrv", RequestNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx", ResponseNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public string invokeSrv(string Input) {
        object[] results = this.Invoke("invokeSrv", new object[] {
                    Input});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininvokeSrv(string Input, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("invokeSrv", new object[] {
                    Input}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndinvokeSrv(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:YiFeiGatewayExIntf-IYiFeiGatewayEx#callbackSrv", RequestNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx", ResponseNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public string callbackSrv(string Input) {
        object[] results = this.Invoke("callbackSrv", new object[] {
                    Input});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincallbackSrv(string Input, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("callbackSrv", new object[] {
                    Input}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcallbackSrv(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:YiFeiGatewayExIntf-IYiFeiGatewayEx#syncProd", RequestNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx", ResponseNamespace="urn:YiFeiGatewayExIntf-IYiFeiGatewayEx")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public string syncProd(string Input) {
        object[] results = this.Invoke("syncProd", new object[] {
                    Input});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginsyncProd(string Input, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("syncProd", new object[] {
                    Input}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndsyncProd(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
}
