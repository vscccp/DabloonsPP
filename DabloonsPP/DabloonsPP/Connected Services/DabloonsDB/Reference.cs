﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 17.0.32811.315
// 
namespace DabloonsPP.DabloonsDB {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Dabloons_Service")]
    public partial class User : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string PasswordField;
        
        private int UserIdField;
        
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Unlocked", Namespace="http://schemas.datacontract.org/2004/07/Dabloons_Service")]
    public partial class Unlocked : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int GameCurrencyField;
        
        private int HealthTiersField;
        
        private int MapsUnlockedField;
        
        private int MoneyTiersField;
        
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int GameCurrency {
            get {
                return this.GameCurrencyField;
            }
            set {
                if ((this.GameCurrencyField.Equals(value) != true)) {
                    this.GameCurrencyField = value;
                    this.RaisePropertyChanged("GameCurrency");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HealthTiers {
            get {
                return this.HealthTiersField;
            }
            set {
                if ((this.HealthTiersField.Equals(value) != true)) {
                    this.HealthTiersField = value;
                    this.RaisePropertyChanged("HealthTiers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MapsUnlocked {
            get {
                return this.MapsUnlockedField;
            }
            set {
                if ((this.MapsUnlockedField.Equals(value) != true)) {
                    this.MapsUnlockedField = value;
                    this.RaisePropertyChanged("MapsUnlocked");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MoneyTiers {
            get {
                return this.MoneyTiersField;
            }
            set {
                if ((this.MoneyTiersField.Equals(value) != true)) {
                    this.MoneyTiersField = value;
                    this.RaisePropertyChanged("MoneyTiers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Matches", Namespace="http://schemas.datacontract.org/2004/07/Dabloons_Service")]
    public partial class Matches : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int MatchIdField;
        
        private int MoneyAccumulatedField;
        
        private char ResultField;
        
        private System.TimeSpan TimeTakenField;
        
        private int TowersBuiltField;
        
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MatchId {
            get {
                return this.MatchIdField;
            }
            set {
                if ((this.MatchIdField.Equals(value) != true)) {
                    this.MatchIdField = value;
                    this.RaisePropertyChanged("MatchId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MoneyAccumulated {
            get {
                return this.MoneyAccumulatedField;
            }
            set {
                if ((this.MoneyAccumulatedField.Equals(value) != true)) {
                    this.MoneyAccumulatedField = value;
                    this.RaisePropertyChanged("MoneyAccumulated");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan TimeTaken {
            get {
                return this.TimeTakenField;
            }
            set {
                if ((this.TimeTakenField.Equals(value) != true)) {
                    this.TimeTakenField = value;
                    this.RaisePropertyChanged("TimeTaken");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TowersBuilt {
            get {
                return this.TowersBuiltField;
            }
            set {
                if ((this.TowersBuiltField.Equals(value) != true)) {
                    this.TowersBuiltField = value;
                    this.RaisePropertyChanged("TowersBuilt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DabloonsDB.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TryLogin", ReplyAction="http://tempuri.org/IService1/TryLoginResponse")]
        System.Threading.Tasks.Task<bool> TryLoginAsync(DabloonsPP.DabloonsDB.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserByUsername", ReplyAction="http://tempuri.org/IService1/GetUserByUsernameResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetUserByUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddUser", ReplyAction="http://tempuri.org/IService1/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(DabloonsPP.DabloonsDB.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllUsers", ReplyAction="http://tempuri.org/IService1/GetAllUsersResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<DabloonsPP.DabloonsDB.User>> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateUser", ReplyAction="http://tempuri.org/IService1/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(DabloonsPP.DabloonsDB.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddUnlocked", ReplyAction="http://tempuri.org/IService1/AddUnlockedResponse")]
        System.Threading.Tasks.Task<bool> AddUnlockedAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateUnlocked", ReplyAction="http://tempuri.org/IService1/UpdateUnlockedResponse")]
        System.Threading.Tasks.Task<bool> UpdateUnlockedAsync(int userId, DabloonsPP.DabloonsDB.Unlocked unlocked);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddMatch", ReplyAction="http://tempuri.org/IService1/AddMatchResponse")]
        System.Threading.Tasks.Task<bool> AddMatchAsync(int userId, DabloonsPP.DabloonsDB.Matches match);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteMatch", ReplyAction="http://tempuri.org/IService1/DeleteMatchResponse")]
        System.Threading.Tasks.Task<bool> DeleteMatchAsync(int matchId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteUnlockables", ReplyAction="http://tempuri.org/IService1/DeleteUnlockablesResponse")]
        System.Threading.Tasks.Task<bool> DeleteUnlockablesAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteUser", ReplyAction="http://tempuri.org/IService1/DeleteUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteUserAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTotalGamesCount", ReplyAction="http://tempuri.org/IService1/GetTotalGamesCountResponse")]
        System.Threading.Tasks.Task<int> GetTotalGamesCountAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTotalMoneySpent", ReplyAction="http://tempuri.org/IService1/GetTotalMoneySpentResponse")]
        System.Threading.Tasks.Task<int> GetTotalMoneySpentAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTotalMoneyGained", ReplyAction="http://tempuri.org/IService1/GetTotalMoneyGainedResponse")]
        System.Threading.Tasks.Task<int> GetTotalMoneyGainedAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTotalTowersBuilt", ReplyAction="http://tempuri.org/IService1/GetTotalTowersBuiltResponse")]
        System.Threading.Tasks.Task<int> GetTotalTowersBuiltAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUnlocked", ReplyAction="http://tempuri.org/IService1/GetUnlockedResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.Unlocked> GetUnlockedAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTopPlayerByMoneySpent", ReplyAction="http://tempuri.org/IService1/GetTopPlayerByMoneySpentResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetTopPlayerByMoneySpentAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTopPlayerByMoneyGained", ReplyAction="http://tempuri.org/IService1/GetTopPlayerByMoneyGainedResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetTopPlayerByMoneyGainedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTopPlayerByTowersBuilt", ReplyAction="http://tempuri.org/IService1/GetTopPlayerByTowersBuiltResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetTopPlayerByTowersBuiltAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayerWithFastestGame", ReplyAction="http://tempuri.org/IService1/GetPlayerWithFastestGameResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithFastestGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayerWithMostLosses", ReplyAction="http://tempuri.org/IService1/GetPlayerWithMostLossesResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithMostLossesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayerWithMostWins", ReplyAction="http://tempuri.org/IService1/GetPlayerWithMostWinsResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithMostWinsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayerWithBestWinPercentage", ReplyAction="http://tempuri.org/IService1/GetPlayerWithBestWinPercentageResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithBestWinPercentageAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayerWithBestLossPercentage", ReplyAction="http://tempuri.org/IService1/GetPlayerWithBestLossPercentageResponse")]
        System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithBestLossPercentageAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : DabloonsPP.DabloonsDB.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<DabloonsPP.DabloonsDB.IService1>, DabloonsPP.DabloonsDB.IService1 {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Service1Client() : 
                base(Service1Client.GetDefaultBinding(), Service1Client.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService1.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), Service1Client.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<bool> TryLoginAsync(DabloonsPP.DabloonsDB.User user) {
            return base.Channel.TryLoginAsync(user);
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetUserByUsernameAsync(string username) {
            return base.Channel.GetUserByUsernameAsync(username);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(DabloonsPP.DabloonsDB.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<DabloonsPP.DabloonsDB.User>> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(DabloonsPP.DabloonsDB.User user) {
            return base.Channel.UpdateUserAsync(user);
        }
        
        public System.Threading.Tasks.Task<bool> AddUnlockedAsync(int userId) {
            return base.Channel.AddUnlockedAsync(userId);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUnlockedAsync(int userId, DabloonsPP.DabloonsDB.Unlocked unlocked) {
            return base.Channel.UpdateUnlockedAsync(userId, unlocked);
        }
        
        public System.Threading.Tasks.Task<bool> AddMatchAsync(int userId, DabloonsPP.DabloonsDB.Matches match) {
            return base.Channel.AddMatchAsync(userId, match);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteMatchAsync(int matchId) {
            return base.Channel.DeleteMatchAsync(matchId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUnlockablesAsync(int userId) {
            return base.Channel.DeleteUnlockablesAsync(userId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUserAsync(int userId) {
            return base.Channel.DeleteUserAsync(userId);
        }
        
        public System.Threading.Tasks.Task<int> GetTotalGamesCountAsync(int userId) {
            return base.Channel.GetTotalGamesCountAsync(userId);
        }
        
        public System.Threading.Tasks.Task<int> GetTotalMoneySpentAsync(int userId) {
            return base.Channel.GetTotalMoneySpentAsync(userId);
        }
        
        public System.Threading.Tasks.Task<int> GetTotalMoneyGainedAsync(int userId) {
            return base.Channel.GetTotalMoneyGainedAsync(userId);
        }
        
        public System.Threading.Tasks.Task<int> GetTotalTowersBuiltAsync(int userId) {
            return base.Channel.GetTotalTowersBuiltAsync(userId);
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.Unlocked> GetUnlockedAsync(int userId) {
            return base.Channel.GetUnlockedAsync(userId);
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetTopPlayerByMoneySpentAsync() {
            return base.Channel.GetTopPlayerByMoneySpentAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetTopPlayerByMoneyGainedAsync() {
            return base.Channel.GetTopPlayerByMoneyGainedAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetTopPlayerByTowersBuiltAsync() {
            return base.Channel.GetTopPlayerByTowersBuiltAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithFastestGameAsync() {
            return base.Channel.GetPlayerWithFastestGameAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithMostLossesAsync() {
            return base.Channel.GetPlayerWithMostLossesAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithMostWinsAsync() {
            return base.Channel.GetPlayerWithMostWinsAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithBestWinPercentageAsync() {
            return base.Channel.GetPlayerWithBestWinPercentageAsync();
        }
        
        public System.Threading.Tasks.Task<DabloonsPP.DabloonsDB.User> GetPlayerWithBestLossPercentageAsync() {
            return base.Channel.GetPlayerWithBestLossPercentageAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/Dabloons_Service/Service1/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return Service1Client.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return Service1Client.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IService1,
        }
    }
}
