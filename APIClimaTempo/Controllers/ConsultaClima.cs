using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIClimaTempo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaClima : ControllerBase
    {
        // GET: api/<ConsultaClima>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConsultaClima>/5
        [HttpGet("consultaCidade/{cidade}")]
        public async Task<IActionResult> BuscarCidade(string cidade)
        {

            cidade = "sao paulo";
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

            string apiUrlBusca = "http://servicos.cptec.inpe.br/XML/cidade/" + idCidade + "/previsao.xml";
            string[] Requisicao = new string[18];

            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(apiUrlBusca))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    string codigo = "";
                    string Cidade = "";
                    string UF = "";
                    string Atualizacao = "";
                    string dia = "";
                    string tempo = "";
                    string maxima = "";
                    string minima = "";
                    string iuv = "";
                    string codigo2 = "";
                    string Cidade2 = "";
                    string dia2 = "";
                    string tempo2 = "";
                    string maxima2 = "";
                    string minima2 = "";
                    string iuv2 = "";
                    string dia3 = "";
                    string tempo3 = "";
                    string maxima3 = "";
                    string minima3 = "";
                    string iuv3 = "";
                    string dia4 = "";
                    string tempo4 = "";
                    string maxima4 = "";
                    string minima4 = "";
                    string iuv4 = "";

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

                            else if (dia == "")
                            {
                                dia = readerResultado.Value;
                            }

                            else if (tempo == "")
                            {
                                tempo = readerResultado.Value;
                            }

                            else if (maxima == "")
                            {
                                maxima = readerResultado.Value;
                            }

                            else if (minima == "")
                            {
                                minima = readerResultado.Value;
                            }

                            else if (iuv == "")
                            {
                                iuv = readerResultado.Value;
                            }

                            if (iuv != "")
                            {
                                // dia 2 -------------------------------------------------------------------
                                if (codigo2 == "")
                                {
                                    codigo2 = readerResultado.Value;
                                }

                                if (Cidade2 == "")
                                {
                                    Cidade2 = readerResultado.Value;
                                }

                                //////////////// data 2

                                else if (dia2 == "")
                                {
                                    dia2 = readerResultado.Value;
                                }

                                ////////tempo2
                                else if (tempo2 == "")
                                {
                                    tempo2 = readerResultado.Value;
                                }

                                /////maxima2
                                else if (maxima2 == "")
                                {
                                    maxima2 = readerResultado.Value;
                                }

                                /////////minima2
                                else if (minima2 == "")
                                {
                                    minima2 = readerResultado.Value;
                                }

                                ////////iuv2
                                else if (iuv2 == "")
                                {
                                    iuv2 = readerResultado.Value;
                                }

                                ////data3
                                else if (dia3 == "")
                                {
                                    dia3 = readerResultado.Value;
                                }

                                ///////tempo3
                                else if (tempo3 == "")
                                {
                                    tempo3 = readerResultado.Value;
                                }

                                ///////tempo3
                                else if (iuv3 == "")
                                {
                                    iuv3 = readerResultado.Value;
                                }

                                if (iuv3 != "")
                                {

                                    if (maxima3 == "")
                                    {
                                        maxima3 = readerResultado.Value;
                                    }

                                    ///////////dia4
                                    else if (minima3 == "")
                                    {
                                        minima3 = readerResultado.Value;
                                    }

                                    ///////maxima3
                                    else if (iuv4 == "")
                                    {
                                        iuv4 = readerResultado.Value;
                                    }

                                    //////////minima3
                                    else if (dia4 == "")
                                    {
                                        dia4 = readerResultado.Value;
                                    }

                                    /////////tempo4
                                    else if (tempo4 == "")
                                    {
                                        tempo4 = readerResultado.Value;
                                    }

                                    else if (maxima4 == "")
                                    {
                                        maxima4 = readerResultado.Value;
                                    }

                                    else if (minima4 == "")
                                    {
                                        minima4 = readerResultado.Value;
                                    }
                                }
                            }
                        }

                        Requisicao[0] = Cidade;
                        Requisicao[1] = UF;
                        Requisicao[2] = dia;
                        Requisicao[3] = tempo;
                        Requisicao[4] = maxima;
                        Requisicao[5] = minima;
                        Requisicao[6] = dia2;
                        Requisicao[7] = tempo2;
                        Requisicao[8] = maxima2;
                        Requisicao[9] = minima2;
                        Requisicao[10] = dia3;
                        Requisicao[11] = tempo3;
                        Requisicao[12] = maxima3;
                        Requisicao[13] = minima3;
                        Requisicao[14] = dia4;
                        Requisicao[15] = tempo4;
                        Requisicao[16] = maxima4;
                        Requisicao[17] = minima4;

                    }
                }
            }

            //List<Clima> clima = new List<Clima>();

            //clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[2], Requisicao[3], Requisicao[4], Requisicao[5]));
            //clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[6], Requisicao[7], Requisicao[8], Requisicao[9]));
            //clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[10], Requisicao[11], Requisicao[12], Requisicao[13]));
            //clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[14], Requisicao[15], Requisicao[16], Requisicao[17]));

            //var options = new JsonSerializerOptions
            //{
            //    //Lê valores numéricos definidos como string e escreve valores numéricos como strings
            //    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
            //    //Identa o JSON gerado
            //    WriteIndented = true,
            //    //Ignora propriedades com valor nulo ou padrão
            //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            //};

            //var json = JsonSerializer.Serialize(clima, options);

            return Ok(Requisicao);

        }   

        // GET api/<ConsultaClima>/5
        [HttpGet("{cidade}")]
        public async Task<IActionResult> Get(string idCidade)
        {
            //string apiUrl = "http://servicos.cptec.inpe.br/XML/cidade/244/previsao.xml";

            string apiUrlBusca = "http://servicos.cptec.inpe.br/XML/cidade/" + idCidade + "/previsao.xml";
           
            string[] Requisicao = new string[18];

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrlBusca))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    string codigo = "";
                    string Cidade = "";
                    string UF = "";
                    string Atualizacao = "";
                    string dia = "";
                    string tempo = "";
                    string maxima = "";
                    string minima = "";
                    string iuv = "";
                    string codigo2 = "";
                    string Cidade2 = "";
                    string dia2 = "";
                    string tempo2 = "";
                    string maxima2 = "";
                    string minima2 = "";
                    string iuv2 = "";
                    string dia3 = "";
                    string tempo3 = "";
                    string maxima3 = "";
                    string minima3 = "";
                    string iuv3 = "";
                    string dia4 = "";
                    string tempo4 = "";
                    string maxima4 = "";
                    string minima4 = "";
                    string iuv4 = "";

                    String URLString = apiUrlBusca;
                    XmlTextReader reader = new XmlTextReader(URLString);
                    while (reader.Read())
                    {
                        // Do some work here on the data.
                        if (reader.Value != "")
                        {
                            Console.WriteLine(reader.Value);
                            if (codigo == "")
                            {
                                codigo = reader.Value;
                            }

                            else if (Cidade == "")
                            {
                                Cidade = reader.Value;
                            }

                            else if (UF == "")
                            {
                                UF = reader.Value;
                            }

                            else if (Atualizacao == "")
                            {
                                Atualizacao = reader.Value;
                            }

                            else if (dia == "")
                            {
                                dia = reader.Value;
                            }

                            else if (tempo == "")
                            {
                                tempo = reader.Value;
                            }

                            else if (maxima == "")
                            {
                                maxima = reader.Value;
                            }

                            else if (minima == "")
                            {
                                minima = reader.Value;
                            }

                            else if (iuv == "")
                            {
                                iuv = reader.Value;
                            }

                            if (iuv != "")
                            {
                                // dia 2 -------------------------------------------------------------------
                                if (codigo2 == "")
                                {
                                    codigo2 = reader.Value;
                                }

                                if (Cidade2 == "")
                                {
                                    Cidade2 = reader.Value;
                                }

                                //////////////// data 2

                                else if (dia2 == "")
                                {
                                    dia2 = reader.Value;
                                }

                                ////////tempo2
                                else if (tempo2 == "")
                                {
                                    tempo2 = reader.Value;
                                }

                                /////maxima2
                                else if (maxima2 == "")
                                {
                                    maxima2 = reader.Value;
                                }

                                /////////minima2
                                else if (minima2 == "")
                                {
                                    minima2 = reader.Value;
                                }

                                ////////iuv2
                                else if (iuv2 == "")
                                {
                                    iuv2 = reader.Value;
                                }

                                ////data3
                                else if (dia3 == "")
                                {
                                    dia3 = reader.Value;
                                }

                                ///////tempo3
                                else if (tempo3 == "")
                                {
                                    tempo3 = reader.Value;
                                }

                                ///////tempo3
                                else if (iuv3 == "")
                                {
                                    iuv3 = reader.Value;
                                }

                                if (iuv3 != "")
                                {

                                    if (maxima3 == "")
                                    {
                                        maxima3 = reader.Value;
                                    }

                                    ///////////dia4
                                    else if (minima3 == "")
                                    {
                                        minima3 = reader.Value;
                                    }

                                    ///////maxima3
                                    else if (iuv4 == "")
                                    {
                                        iuv4 = reader.Value;
                                    }

                                    //////////minima3
                                    else if (dia4 == "")
                                    {
                                        dia4 = reader.Value;
                                    }

                                    /////////tempo4
                                    else if (tempo4 == "")
                                    {
                                        tempo4 = reader.Value;
                                    }

                                    else if (maxima4 == "")
                                    {
                                        maxima4 = reader.Value;
                                    }

                                    else if (minima4 == "")
                                    {
                                        minima4 = reader.Value;
                                    }
                                }
                            }
                        }

                        Requisicao[0] = Cidade;
                        Requisicao[1] = UF;
                        Requisicao[2] = dia;
                        Requisicao[3] = tempo;
                        Requisicao[4] = maxima;
                        Requisicao[5] = minima;
                        Requisicao[6] = dia2;
                        Requisicao[7] = tempo2;
                        Requisicao[8] = maxima2;
                        Requisicao[9] = minima2;
                        Requisicao[10] = dia3;
                        Requisicao[11] = tempo3;
                        Requisicao[12] = maxima3;
                        Requisicao[13] = minima3;
                        Requisicao[14] = dia4;
                        Requisicao[15] = tempo4;
                        Requisicao[16] = maxima4;
                        Requisicao[17] = minima4;

                    }
                }
            }

            List<Clima> clima = new List<Clima>();

            clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[2], Requisicao[3], Requisicao[4], Requisicao[5]));
            clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[6], Requisicao[7], Requisicao[8], Requisicao[9]));
            clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[10], Requisicao[11], Requisicao[12], Requisicao[13]));
            clima.Add(new Clima(Requisicao[0], Requisicao[1], Requisicao[14], Requisicao[15], Requisicao[16], Requisicao[17]));

            Console.WriteLine(clima);
            return Ok(clima);

        }


        // POST api/<ConsultaClima>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsultaClima>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultaClima>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
