using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects.DTO
{
    public class FiltroLeilaoDTO
    {
        public string Termo { get; set; }
        public List<string> Categorias { get; set; }
        public bool IsEmAndamento { get; set; }
    }
}
