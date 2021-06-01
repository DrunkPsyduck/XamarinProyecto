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

        public async Task<Usuario> GetUsuarioAsync(String username, String password)
        {
            String request = "/api/Usuario/GetUsuario/" + username + "/" + password;
            Uri uri = new Uri(this.url + request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
                await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                String data =
                    await response.Content.ReadAsStringAsync();
                Usuario usuario =
                    JsonConvert.DeserializeObject<Usuario>(data);
                return usuario;
            }
            else
            {
                return null;
            }
        }

    }
}
