using CadastroDeUsuarios.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.API.Interface
{
    public interface IEscolaridadeRepositorio
    {
        Task<Escolaridade> SelecionarByPk(int id);
        Task<IEnumerable<Escolaridade>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}

