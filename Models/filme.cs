using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public class filme
    {

    //comando pra cria migrations: Add-Migration <nome da migração>
    [Key] // declarando que essa é minha chave primaria para o banco de dados
    [Required] // dissendo que ela é obrigatória
    public int Id {get; set;}

    [Required(ErrorMessage = "O campo Titulo é obigatório")] //anotando que esse campo é obrigatório
     public string Titulo {get; set;}

    [Required(ErrorMessage = "O campo Diretor é obrigatório")]
     public string Diretor {get; set;}

    [Required (ErrorMessage = "O campo Genero é obrigatório")]
    [StringLength(30, ErrorMessage ="O gênero não pode passar de 30 caracteres")]
     public string Genero {get; set;} 

    [Range(1, 600, ErrorMessage ="O campo Duracação é obrigatório")]
     public int Duracao {get; set;}  
    }
}