using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinProyecto.Base;
using XamarinProyecto.Models;
using XamarinProyecto.Service;

namespace XamarinProyecto.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        ServiceUsuarios service;
        public LoginViewModel()
        {
            this.service = new ServiceUsuarios();
        }

        public Command Login
        {
            get
            {
                return new Command(async () => {
                    
                });
            }
        }

        private String _Username;
        public String Username
        {
            get { return this._Username; }
            set
            {
                this._Username = value;
                OnPropertyChanged("Username");
            }
        }

        private String _Password;
        public String Password
        {
            get { return this._Password; }
            set
            {
                this._Password = value;
                OnPropertyChanged("Password");
            }
        }

        private String _Status;
        public String Status
        {
            get { return this._Status; }
            set
            {
                this._Status = value;
                OnPropertyChanged("Status");
            }
        }

        public Command Validar
        {
            get
            {
                return new Command(async () =>
                {
                    Usuario user = await this.service.GetUsuarioAsync(this.Username, this.Password);

                   
                    if (user != null)
                    {
                        this.Status = "Works";
                        MainPage view = new MainPage();
                        Application.Current.MainPage.Navigation.PushModalAsync(view);
                    } else
                    {
                        this.Status = "Usuario/Contraseña incorrecta";
                    }
                });
            }
        }

    }
}
