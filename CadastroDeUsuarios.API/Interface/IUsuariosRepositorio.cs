using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeUsuarios.API.Models;

namespace CadastroDeUsuarios.API.Interface
{
    public interface IUsuariosRepositorio
    {
        void Incluir(Usuarios usuarios);
        void Alterar(Usuarios usuarios);
        void Excluir(Usuarios usuarios);

        Task<Usuarios> SelecionarByPk(int id);
        Task<IEnumerable<Usuarios>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
