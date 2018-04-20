using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;


namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim(); //Trim remove espaços iniciais e finais da string
            //TODO - Validações
            if (isValidCEP(cep) == true)
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {



                        RESULTADO.Text = string.Format("Endereço: {3} {0}, {1} {2}", end.bairro, end.localidade, end.uf, end.logradouro);

                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado:" + cep, "OK");
                    }
                }
                catch (Exception W)
                {
                    DisplayAlert("ERRO CRÍTICO", W.Message, "OK");

                }
                
            }
            else
            {

            }
           

              //throw new NotImplementedException();
        }

        private Boolean isValidCEP(string cep)
        {
            Boolean valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO","CEP inválido! O CEP deve conter 8 números","OK");
                valido = false;     
            }

            int NovoCEP = 0;

            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter apenas números", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
