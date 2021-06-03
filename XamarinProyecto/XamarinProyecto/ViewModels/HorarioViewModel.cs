using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinProyecto.Base;
using XamarinProyecto.Models;
using XamarinProyecto.Service;
using XamarinProyecto.Views;

namespace XamarinProyecto.ViewModels
{
    public class HorarioViewModel:ViewModelBase
    {
        ServiceUsuarios service;

        public HorarioViewModel()
        {
            this.service = new ServiceUsuarios();

        }

        private ObservableCollection<Horario> _ListaHorario;
        public ObservableCollection<Horario> ListaHorario
        {
            get { return this._ListaHorario; }
            set
            {
                this._ListaHorario = value;
                OnPropertyChanged("ListaHorario");
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
            } else if (dia == "1")
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

        public Command GetHorario
        {
            get
            {
                return new Command(async () =>
                {
                    
                    this.Ocupado = "True";
                    this.Dia = ModificarDiaNumeroCadena(this.Dia);

                    if (this.Dia == "")
                    {
                        this.Status = "Día no válido";
                    }
                    else
                    {

                        List<Horario> horario = await this.service.GetHorario(Dia);
                        if (horario != null)
                        {
                            this.Status = "Not null";
                            this.ListaHorario = new ObservableCollection<Horario>(horario);
                             
                            if (this.ListaHorario.Count == 0)
                            {
                                this.Status = "No tienes ninguna clase el " + this.Dia;
                            }
                            else
                            {
                                this.Status = "Tienes " + this.ListaHorario.Count.ToString() + " asignatura el " + this.Dia; 
                            }
                            this.Ocupado = "False";
                        }
                        else
                        {
                            this.Status = "null";
                            this.Ocupado = "False";
                        }
                    }
                });
            }
        }

        public Command NuevaAsignatura
        {
            get
            {
                return new Command(async () =>
                {
                    NuevoAsignaturaView view = new NuevoAsignaturaView();

                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
