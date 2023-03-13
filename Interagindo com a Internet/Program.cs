﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Interagindo_com_a_Internet
{

    class Program
    {
        static void Main(string[] args)
        {

            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                Console.WriteLine(dados.ToString());

                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                foreach(Tarefa tarefa in tarefas){
                    tarefa.Exibir();
                }

                Console.WriteLine(tarefas);

                stream.Close();
                resposta.Close();
            }

            Console.ReadLine();
        }
    }
}
