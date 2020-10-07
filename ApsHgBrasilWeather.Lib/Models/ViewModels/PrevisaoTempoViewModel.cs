using ApsHgBrasilWeather.Lib.Models.RestModels.HgBrasil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApsHgBrasilWeather.Lib.Models.ViewModels
{
    public class PrevisaoTempoViewModel
    {
        public PrevisaoTempoAtual PrevisaoTempoAtual { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Selecione um estado")]
        public string EstadoSelecionado { get; set; }

        public List<SelectListItem> Estados { get; set; }

        [Display(Name = "Município")]
        [Required(ErrorMessage = "Selecione um Município")]
        public string MunicipioSelecionado { get; set; }

        public List<SelectListItem> Municipios { get; set; }

        public PrevisaoTempoViewModel()
        {
            Estados = new List<SelectListItem>(GetEstados());
            Estados.Insert(0, new SelectListItem() { Text = "(Selecione uma opção)", Value = "" });

            Municipios = new List<SelectListItem>();
            Municipios.Insert(0, new SelectListItem() { Text = "(Selecione uma opção)", Value = "" });
        }

        private List<SelectListItem> GetEstados()
        {
            List<SelectListItem> estados = new List<SelectListItem>()
            {
                 new SelectListItem(){ Text = "AC", Value = "AC"},

                 new SelectListItem(){ Text = "AL", Value = "AL"},

                 new SelectListItem(){ Text = "AP", Value = "AP"},

                 new SelectListItem(){ Text = "AM", Value = "AM"},

                 new SelectListItem(){ Text = "BA", Value = "BA"},

                 new SelectListItem(){ Text = "CE", Value = "CE"},

                 new SelectListItem(){ Text = "ES", Value = "ES"},

                 new SelectListItem(){ Text = "GO", Value = "GO"},

                 new SelectListItem(){ Text = "MA", Value = "MA"},

                 new SelectListItem(){ Text = "MT", Value = "MT"},

                 new SelectListItem(){ Text = "MS", Value = "MS"},

                 new SelectListItem(){ Text = "MG", Value = "MG"},

                 new SelectListItem(){ Text = "PA", Value = "PA"},

                 new SelectListItem(){ Text = "PB", Value = "PB"},

                 new SelectListItem(){ Text = "PR", Value = "PR"},

                 new SelectListItem(){ Text = "PE", Value = "PE"},

                 new SelectListItem(){ Text = "PI", Value = "PI"},

                 new SelectListItem(){ Text = "RJ", Value = "RJ"},

                 new SelectListItem(){ Text = "RN", Value = "RN"},

                 new SelectListItem(){ Text = "RS", Value = "RS"},

                 new SelectListItem(){ Text = "RO", Value = "RO"},

                 new SelectListItem(){ Text = "RR", Value = "RR"},

                 new SelectListItem(){ Text = "SC", Value = "SC"},

                 new SelectListItem(){ Text = "SP", Value = "SP"},

                 new SelectListItem(){ Text = "SE", Value = "SE"},

                 new SelectListItem(){ Text = "TO", Value = "TO"}
            };

            return estados;
        }
    }
}
