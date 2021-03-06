
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinProyecto.Models;

namespace XamarinProyecto.Service
{
    public class ServiceUsuarios
    {
        private String url;
        public ServiceUsuarios()
        {
            this.url = "https://estudianteappservicioxamaml.azurewebsites.net/";
        }

        private async Task<T> CallApiAsync<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json =
                        await response.Content.ReadAsStringAsync();
                    T data =
                        JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }


        public async Task<Usuario> GetUsuarioAsync(String username, String password)
        {

            String request = "/api/Usuario/GetUsuario/" + username + "/" + password;
            Usuario usuario = await this.CallApiAsync<Usuario>(request);
            return usuario;          
        }

        public async Task<List<Horario>> GetHorario(String dia)
        {

            Usuario user = Barrel.Current.Get<Usuario>("USUARIO");
            String usuario = user.IdUsuario.ToString();
            String request = "/api/Horario/GetClasesUser/" + usuario + "/" + dia;
            List<Horario> clases = await this.CallApiAsync<List<Horario>>(request);
            return clases;
           
        }

        public async Task InsertAsignatura(int id, String asignatura, String horaEmpiece, String horaFinal, string dia)
        {
            Usuario user = Barrel.Current.Get<Usuario>("USUARIO");
            int usuario = user.IdUsuario;
            Horario horario = new Horario
            {
                IdClase = id,
                Asignatura = asignatura,
                HoraEmpiece = horaEmpiece,
                HoraFinal = horaFinal,
                Dia = dia,
                IdUsuario = usuario
            };
            String json = JsonConvert.SerializeObject(horario);
            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "​/api/Horario";
                Uri uri = new Uri(this.url + request);
                await client.PostAsync(uri, content);
            }
        }

    }
}
