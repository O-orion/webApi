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
        
        //adicionando verbo http
        [HttpPost]
        public void AdicionarFilme([FromBody]filme filme){ //FromBody indica que as informações estão vindas no corpo da requisição
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
        
    }
}