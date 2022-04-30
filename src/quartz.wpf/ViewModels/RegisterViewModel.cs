using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using quartz.wpf.common.AuthModel;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
using quartz.wpf.UserAuthentication;
using quartz.wpf.UserAuthentication.CreateUser;
using quartz.wpf.UserAuthentication.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace quartz.wpf.ViewModels
{
    public class RegisterViewModel: NotificationObject
    {
        private DelegateCommand _createCommand;
        private User _user;
        private string _errorsmessage;
        private PasswordBox _password;
        private IAPIClient aPIclient;

        private User _userLoginResponse;
        internal User UserLoginResponse => _userLoginResponse;

        public Action CloseWndRequest;
        public RegisterViewModel(IAPIClient aPIclient)
        {
            this.aPIclient = aPIclient;
            Password = new PasswordBox();
            User = new User();
        }

        public User User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(()=>this.User); }
        }

        public PasswordBox Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string ErrorsMessage
        {
            get { return _errorsmessage; }
            set { _errorsmessage = value; RaisePropertyChanged(() => this.ErrorsMessage); }
        }

        public DelegateCommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(async () =>
                    {
                        ErrorsMessage = "";
                        if (string.IsNullOrEmpty(User.Username) && string.IsNullOrEmpty(_password.Password))
                        {
                            ErrorsMessage = "Username and Password are required";
                            return;
                        }
                        var result = await Task.Run(() => aPIclient.Post(APIQuery.Create(AuthUrl.Register), new CreateUserRequest(this.User, _password.Password)));
                        if (result.HasData())
                        {
                            _userLoginResponse = result.Data;
                            CloseWndRequest.Invoke();
                            return;
                        }
                        ErrorsMessage = result.Message;
                    });
                }
                return _createCommand;
            }
        }
    }

}
