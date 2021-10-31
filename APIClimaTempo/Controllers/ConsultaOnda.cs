using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace APIClimaTempo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaOnda : ControllerBase
    {

        // GET api/<ConsultaOnda>/5
        [HttpGet("consultaOnda/{cidade}")]
        public async Task<IActionResult> BuscarCidade(string cidade)
        {

            //cidade = "Rio de Janeiro"; //utilizar este exemplo chumbado ao código para testar a funcionalidade
            cidade = cidade.Replace(" ", "%20");

            string codigoXml = "";
            string CidadeConsulta = "";
            string uf = "";
            string idCidade = "";

            string apiUrl = " http://servicos.cptec.inpe.br/XML/listaCidades?city=" + cidade;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    String URLString = apiUrl;
                    XmlTextReader reader = new XmlTextReader(URLString);

                    while (reader.Read())
                    {

                        if (reader.Value != "")
                        {

                            if (codigoXml == "")
                            {
                                codigoXml = reader.Value;
                            }

                            else if (CidadeConsulta == "")
                            {
                                CidadeConsulta = reader.Value;
                            }

                            else if (uf == "")
                            {
                                uf = reader.Value;
                            }

                            else if (idCidade == "")
                            {
                                idCidade = reader.Value;
                            }

                        }

                    }
                }
            }

            string apiUrlBusca = "http://servicos.cptec.inpe.br/XML/cidade/" + idCidade + "/dia/0/ondas.xml";
            //string apiUrlBusca = "http://servicos.cptec.inpe.br/XML/cidade/241/dia/0/ondas.xml";
            string[] Requisicao = new string[20];

            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(apiUrlBusca))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    string codigo = "";
                    string Cidade = "";
                    string UF = "";
                    string Atualizacao = "";
                    string manha = "";
                    string agitação = "";
                    string altura = "";
                    string direção = "";
                    string vento = "";
                    string vento_dir = "";
                    string tarde = "";
                    string agitação2 = "";
                    string altura2 = "";
                    string direção2 = "";
                    string vento2 = "";
                    string vento_dir2 = "";
                    string noite = "";
                    string agitação3 = "";
                    string altura3 = "";
                    string direção3 = "";
                    string vento3 = "";
                    string vento_dir3 = "";
                    string erro1 = "";
                    string erro2 = "";
                    string erro3 = "";

                    String URLStringResultado = apiUrlBusca;
                    XmlTextReader readerResultado = new XmlTextReader(URLStringResultado);
                    while (readerResultado.Read())
                    {
                        // Do some work here on the data.
                        if (readerResultado.Value != "")
                        {
                            Console.WriteLine(readerResultado.Value);
                            if (codigo == "")
                            {
                                codigo = readerResultado.Value;
                            }

                            else if (Cidade == "")
                            {
                                Cidade = readerResultado.Value;
                            }

                            else if (UF == "")
                            {
                                UF = readerResultado.Value;
                            }

                            else if (Atualizacao == "")
                            {
                                Atualizacao = readerResultado.Value;
                            }

                            else if (manha == "")
                            {
                                manha = readerResultado.Value;
                            }

                            else if (agitação == "")
                            {
                                agitação = readerResultado.Value;
                            }

                            else if (altura == "")
                            {
                                altura = readerResultado.Value;
                            }

                            else if (direção == "")
                            {
                                direção = readerResultado.Value;
                            }

                            else if (vento == "")
                            {
                                vento = readerResultado.Value;
                            }

                            else if (vento_dir == "")
                            {
                                vento_dir = readerResultado.Value;
                            }

                            if (vento_dir != "")
                            {
                                // dia 2 -------------------------------------------------------------------
                                if (erro1 == "")
                                {
                                    erro1 = readerResultado.Value;
                                }

                                if (erro2 == "")
                                {
                                    erro2 = readerResultado.Value;
                                }

                                ////////////////tarde

                                else if (tarde == "")
                                {
                                    tarde = readerResultado.Value;
                                }

                                /////agitação
                                else if (agitação2 == "")
                                {
                                    agitação2 = readerResultado.Value;
                                }

                                /////////altura
                                else if (altura2 == "")
                                {
                                    altura2 = readerResultado.Value;
                                }

                                ////////direção
                                else if (direção2 == "")
                                {
                                    direção2 = readerResultado.Value;
                                }

                                ////vento
                                else if (vento2 == "")
                                {
                                    vento2 = readerResultado.Value;
                                }

                                ///////direção do vento
                                else if (vento_dir2 == "")
                                {
                                    vento_dir2 = readerResultado.Value;
                                }
                                                                
                                if (vento_dir2 != "")
                                {

                                    if (erro3 == "")
                                    {
                                        erro3 = readerResultado.Value;
                                    }

                                    ///////////noite
                                    else if (noite == "")
                                    {
                                        noite = readerResultado.Value;
                                    }

                                    ///////agitação
                                    else if (agitação3 == "")
                                    {
                                        agitação3 = readerResultado.Value;
                                    }

                                    //////////altura
                                    else if (altura3 == "")
                                    {
                                       altura3 = readerResultado.Value;
                                    }

                                    /////////direção
                                    else if (direção3 == "")
                                    {
                                        direção3 = readerResultado.Value;
                                    }

                                    else if (vento3 == "")
                                    {
                                        vento3 = readerResultado.Value;
                                    }

                                    else if (vento_dir3 == "")
                                    {
                                        vento_dir3 = readerResultado.Value;
                                    }
                                }
                            }
                        }

                        Requisicao[0] = Cidade;
                        Requisicao[1] = UF;
                        Requisicao[2] = manha;
                        Requisicao[3] = agitação;
                        Requisicao[4] = altura;
                        Requisicao[5] = direção;
                        Requisicao[6] = vento;
                        Requisicao[7] = vento_dir;
                        Requisicao[8] = tarde;
                        Requisicao[9] = agitação2;
                        Requisicao[10] = altura2;
                        Requisicao[11] = direção2;
                        Requisicao[12] = vento2;
                        Requisicao[13] = vento_dir2;
                        Requisicao[14] = noite;
                        Requisicao[15] = agitação3;
                        Requisicao[16] = altura3;
                        Requisicao[17] = direção3;
                        Requisicao[18] = vento3;
                        Requisicao[19] = vento_dir3;

                    }
                }
            }                       

            return Ok(Requisicao);

        }

    }
}
