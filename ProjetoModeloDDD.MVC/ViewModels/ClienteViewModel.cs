using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    //Representar o cliente atravez de uma View Model
    //View Model não deve ter comportamentos, são só representações
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }       
        [ScaffoldColumn(false)]//Não exibe o campo na tela
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}