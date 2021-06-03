using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinProyecto.Base;
using XamarinProyecto.Service;

namespace XamarinProyecto.ViewModels
{
    public class NuevaAsignaturaViewModel : ViewModelBase
    {
        ServiceUsuarios service;

        public NuevaAsignaturaViewModel()
        {
            this.service = new ServiceUsuarios();

        }

        private int _IdClase;
        public int IdClase
        {
            get { return this._IdClase; }
            set
            {
                this._IdClase= value;
                OnPropertyChanged("IdClase");
            }
        }

        private String _Asignatura;
        public String Asignatura
        {
            get { return this._Asignatura; }
            set
            {
                this._Asignatura = value;
                OnPropertyChanged("Asignatura");
            }
        }

        private TimeSpan _HoraEmpiece;
        public TimeSpan HoraEmpiece
        {
            get { return this._HoraEmpiece; }
            set
            {
                this._HoraEmpiece = value;
                OnPropertyChanged("HoraEmpiece");
            }
        }

        private TimeSpan _HoraFinal;
        public TimeSpan HoraFinal
        {
            get { return this._HoraFinal; }
            set
            {
                this._HoraFinal= value;
                OnPropertyChanged("HoraFinal");
            }
        }


        private String _Dia;
        public String Dia
        {
            get { return this._Dia; }
            set
            {
                this._Dia = value;
                OnPropertyChanged("Dia");
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

        public String ModificarDiaNumeroCadena(String dia)
        {
            if (dia == "0")
            {
                dia = "lunes";
            }
            else if (dia == "1")
            {
                dia = "martes";
            }
            else if (dia == "2")
            {
                dia = "miercoles";
            }
            else if (dia == "3")
            {
                dia = "jueves";
            }
            else if (dia == "4")
            {
                dia = "viernes";
            }
            return dia;
        }



        public Command NuevaAsignatura
        {
            get
            {
                return new Command(async () =>
                {
                    String horaEmpiece = this.HoraEmpiece.ToString();
                    String horaFinal = this.HoraFinal.ToString();
                    this.Dia = ModificarDiaNumeroCadena(this.Dia);

                    await this.service.InsertAsignatura(this.IdClase, this.Asignatura, horaEmpiece, horaFinal, this.Dia);

                    MessagingCenter.Send
                    (App.ServiceLocator.NuevaAsignaturaViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Asignatura insertada", "OK");

                });
            }
        }
    }
}
