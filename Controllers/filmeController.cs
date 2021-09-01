using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers

{ 
    //JESUS CRISTO É O SENHOR!

    [ApiController] // definindo como controlador
    [Route("[controller]")] // especificando o cmainho como nome do controller
    public class filmeController: ControllerBase
    {
        private FilmeContext _context;  //utilizamos para acessa e salvar dados no banco

        //criando um contrutor para iniciliar *cria uma instância do filmecobext*
        public filmeController(FilmeContext context){
            _context = context;
        }
        /*
              Método antigo é manual sem o banco de dados
        private static List<filme> filmes = new List<filme>();
        private static int id = 1; // criando identificado manualmente 
        */
        
        //adicionando verbo http
        [HttpPost]
        public IActionResult AdicionarFilme([FromBody]filme filme){ //FromBody indica que as informações estão vindas no corpo da requisição
            /*filme.Id = id++; //atribuindo o identificador do meu filme
            filmes.Add(filme); */
            _context.Filmes.Add(filme); //adicionando filme no banco
            _context.SaveChanges(); // estamos falando pro banco salvar as alterações feitas
            return CreatedAtAction(nameof(RecuperarFilmesPorId), new {Id = filme.Id}, filme); //estamos passando informação onde esse filme está localizado e retornando o filme para o usúario
           
        }

        [HttpGet] //Verbo utilizado para recuperar dados
        public IEnumerable<filme> RecuperarFilmes(){ // Método antigo IEnumerable retorna uma lista que não se lmita ao list
            return _context.Filmes; // recuperando dados do banco
        }

        [HttpGet("{id}")] // estamos dizendo que esse caminho receve um id, e automaticamente irá passa-ló como parâmetro para o nosso método
        public IActionResult RecuperarFilmesPorId(int id){
           /* foreach (filme fil in filmes) // método manual
            {
                if(fil.Id == id){
                    return fil;
                }
            } */

           // return filmes.FirstOrDefault(filme => filme.Id == id); //Ele vai retorna o primeiro que encontra com o id que recebeu, se não encontra vai retorna um retorno padrão
           filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // esse filme pode ou não se nullo
           if(filme != null){
               return Ok(filme); //retornando um object result com IActionResult, 
           }else{
               return NotFound();
           }
        }

        [HttpPut("{id}")] //verbo para atualizar dados
        public IActionResult AtualizarFilme(int id, [FromBody] filme filmeNovo){
            filme filme  = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null){
                return NotFound();
            }
            filme.Titulo = filmeNovo.Titulo;
            filme.Diretor = filmeNovo.Diretor;
            filme.Genero = filmeNovo.Genero;
            filme.Duracao = filmeNovo.Duracao;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id){
            filme filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null){
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}