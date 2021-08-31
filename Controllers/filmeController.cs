using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;

namespace webApi.Controllers

{ 
    //JESUS CRISTO É O SENHOR!

    [ApiController] // definindo como controlador
    [Route("[controller]")] // especificando o cmainho como nome do controller
    public class filmeController: ControllerBase
    {
        private static List<filme> filmes = new List<filme>();
        private static int id = 1; // criando identificado manualmente
        
        //adicionando verbo http
        [HttpPost]
        public void AdicionarFilme([FromBody]filme filme){ //FromBody indica que as informações estão vindas no corpo da requisição
            filme.Id = id++; //atribuindo o identificador do meu filme
            filmes.Add(filme);
           
        }

        [HttpGet] //Verbo utilizado para recuperar dados
        public IEnumerable<filme> RecuperarFilmes(){ // IEnumerable retorna uma lista que não se lmita ao list
            return filmes;
        }

        [HttpGet("{id}")] // estamos dizendo que esse caminho receve um id, e automaticamente irá passa-ló como parâmetro para o nosso método
        public filme RecuperarFilmesPorId(int id){
           /* foreach (filme fil in filmes) // método manual
            {
                if(fil.Id == id){
                    return fil;
                }
            } */

            return filmes.FirstOrDefault(filme => filme.Id == id); //Ele vai retorna o primeiro que encontra com o id que recebeu, se não encontra vai retorna um retorno padrão

        }
        
    }
}