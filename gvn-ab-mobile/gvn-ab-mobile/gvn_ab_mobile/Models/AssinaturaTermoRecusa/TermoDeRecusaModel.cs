using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace gvn_ab_mobile.Models.AssinaturaTermoRecusa
{
    public class TermoDeRecusaModel
    {
        public string NomeCompletoCidadao { get; set; }

        public string RGCidadao { get; set; }

        public List<Point> SignaturePoints { get; set; }

        public Stream SignatureImage { get; set; }

        public string SignatureStream { get; set; }
    }
}
