﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Serviço.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Serviço
{
    public class ViaCEPServico
    {
        public static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject < Endereco > (Conteudo); //Converte Conteudo em um objto do tipo Endereco

            if (end.cep == null) return null;   


            return end;
        }
    }
}
