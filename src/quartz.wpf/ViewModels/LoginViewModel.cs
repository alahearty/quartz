using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using quartz.wpf.common.AuthModel;
using quartz.wpf.common.Client;
using quartz.wpf.UserAuthentication;
using quartz.wpf.UserAuthentication.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace quartz.wpf.ViewModels
{
    public class LoginViewModel: NotificationObject
    {
        private readonly APIClient aPIclient;
        private DelegateCommand _loginCommand;
        private User _userLoginResponse;
        internal User UserLoginResponse => _userLoginResponse;

        public Action CloseWndRequest;
        public LoginViewModel(APIClient aPIclient)
        {
            this.aPIclient = aPIclient;
            Password = new PasswordBox();
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(() => this.Username); }
        }

        private string _errorsmessage;

        public string ErrorsMessage
        {
            get { return _errorsmessage; }
            set { _errorsmessage = value; RaisePropertyChanged(() => this.ErrorsMessage); }
        }

        private PasswordBox _password;

        public PasswordBox Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public DelegateCommand LoginCommand
        {
            get
            {
                if(_loginCommand == null)
                {
                    _loginCommand = new DelegateCommand(async() =>
                    {
                        ErrorsMessage = "";
                        if(string.IsNullOrEmpty(_username) && string.IsNullOrEmpty(_password.Password))
                        {
                            ErrorsMessage = "Username and Password are required";
                            return;
                        }
                        var result = await Task.Run(()=> aPIclient.Post(APIQuery.Create(AuthUrl.Login), new UserLoginRequest(_username, _password.Password)));
                        if (result.HasData())
                        {
                            _userLoginResponse = result.Data;
                            CloseWndRequest.Invoke();
                            return;
                        }
                        ErrorsMessage = result.Message;
                    });
                }
                return _loginCommand;
            }
        }
    }
}
