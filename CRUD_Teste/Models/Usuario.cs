using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Teste.Models
{
    public class Usuario
    {
        public long id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
    }

}