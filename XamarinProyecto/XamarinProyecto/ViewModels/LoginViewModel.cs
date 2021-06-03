using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinProyecto.Base;
using XamarinProyecto.Models;
using XamarinProyecto.Service;
using XamarinProyecto.Views;

namespace XamarinProyecto.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        ServiceUsuarios service;

        public LoginViewModel()
        {
            this.service = new ServiceUsuarios();
          
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

        private String _Ocupado;
        public String Ocupado
        {
            get { return this._Ocupado; }
            set
            {
                this._Ocupado = value;
                OnPropertyChanged("Ocupado");
            }
        }



        public Command Validar
        {
            get
            {
                return new Command(async () =>
                {
                    this.Ocupado = "True";
                    this.Status = "";
                    Usuario user = await this.service.GetUsuarioAsync(this.Username, this.Password);
                    
                    if (user != null)
                    {
                        Barrel.Current.Add("USUARIO", user, TimeSpan.FromMinutes(20));
                        Barrel.Current.Add("USUARIOID", user.IdUsuario, TimeSpan.FromMinutes(20));
                        HorarioView view = new HorarioView();
                        
                        await Application.Current.MainPage.Navigation.PushModalAsync(view);
                    } else
                    {
                        this.Ocupado = "False";
                        this.Status = "Usuario/Contraseña incorrecta";
                    }
                });
            }
        }

    }
}
