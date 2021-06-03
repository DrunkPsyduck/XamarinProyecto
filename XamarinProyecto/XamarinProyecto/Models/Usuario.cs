using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProyecto.Models
{
    public class Usuario
    {
        [JsonProperty("idUser")]
        public int IdUsuario { get; set; }

        [JsonProperty("userName")]
        public String Username { get; set; }

        [JsonProperty("password")]
        public String Password { get; set; }

        [JsonProperty("rol")]
        public String Rol { get; set; }

    }
}
