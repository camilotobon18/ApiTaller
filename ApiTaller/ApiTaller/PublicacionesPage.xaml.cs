using ClasesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiTaller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicacionesPage : ContentPage
    {
        public PublicacionesPage()
        {
            InitializeComponent();
            CargarPublicaciones();
        }

        private async Task CargarPublicaciones()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("192.168.1.59");

            //se debe declarar el metodo async
            var request = await client.GetAsync("/api/Publicaciones");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserealizeObject<List<Publicacion>>(responseJson);
                listPublicacion.ItemSource = response;
            }
        }

    }
}