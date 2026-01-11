using Prism.Commands;
using Prism.Mvvm;
using quartz.wpf.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace quartz.wpf.ViewModels
{
    public class ShellViewModel: BindableBase
    {
        private readonly IAuthenticationService authenticationService;

        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand LogoutCommand { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }
        public DelegateCommand CreateAccountCommand { get; private set; }

        internal Action CloseWindowRequest;

        public ShellViewModel(IAuthenticationService authenticationService)
        {
            InitCommands();
            this.authenticationService = authenticationService;
            Update_login_logout_status();
        }

        private bool _showLoginButton;

        public bool ShowLoginButton
        {
            get { return _showLoginButton; }
            set { _showLoginButton = value; RaisePropertyChanged(() => ShowLoginButton); }
        }

        private bool _showLogoututton;

        public bool ShowLogoutButton
        {
            get { return _showLogoututton; }
            set { _showLogoututton = value;RaisePropertyChanged(() => ShowLogoutButton); }
        }

        private void InitCommands()
        {
            LoginCommand = new DelegateCommand(() => { authenticationService.Login(); Update_login_logout_status(); });
            LogoutCommand = new DelegateCommand(() => { authenticationService.Logout(); Update_login_logout_status(); });
            ExitCommand = new DelegateCommand(() => CloseWindowRequest.Invoke());
            CreateAccountCommand = new DelegateCommand(() => { authenticationService.Register(); Update_login_logout_status(); });
        }
        private void Update_login_logout_status()
        {
            ShowLoginButton = !authenticationService.IsAuthenticated;
            ShowLogoutButton = authenticationService.IsAuthenticated;
        }
    }
}
