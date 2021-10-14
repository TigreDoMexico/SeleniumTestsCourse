using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects.DTO
{
    public class LeilaoDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double ValorInicial { get; set; }
        public string Categoria { get; set; }
        public DateTime InicioPregao { get; set; }
        public DateTime TerminoPregao { get; set; }
        public string Imagem { get; set; }
    }
}
