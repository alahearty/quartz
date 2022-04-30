using Microsoft.Practices.Unity;
using quartz.wpf.common.AuthModel;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
using quartz.wpf.ViewModels;
using quartz.wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace quartz.wpf.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private User _user;
        private string _bearer;
        private readonly IUnityContainer unityContainer;

        public User User => _user;

        public bool IsAuthenticated => ! string.IsNullOrEmpty(BearerToken);

        public string BearerToken => _bearer;

        public AuthenticationService(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public bool? Login()
        {
            var wnd = new Window
            {
                Title = "SEPAL",
                SizeToContent =SizeToContent.WidthAndHeight,
                Content =unityContainer.Resolve<Login>()
            };
            if (wnd.ShowDialog() == true)
            {
                var vm = (wnd.Content as Control).DataContext as LoginViewModel;
                this._bearer = vm.UserLoginResponse.Token;
                return true;
            }
            return null;
        }

        public void Logout()
        {
            this._bearer = null;
            this._user = null;
        }

        public void Register()
        {
            var wnd = new Window
            {
                Title = "SEPAL",
                SizeToContent = SizeToContent.WidthAndHeight,
                Content = unityContainer.Resolve<Register>()
            };
            if (wnd.ShowDialog() == true)
            {
                var vm = (wnd.Content as Control).DataContext as RegisterViewModel;
                this._bearer = vm.UserLoginResponse.Token;
                MessageBox.Show("Account created successfully.");
            }
        }
    }
}
