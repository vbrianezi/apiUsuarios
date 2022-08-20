using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using CadastroDeUsuarios.API.Interface;
using CadastroDeUsuarios.API.Models;

namespace CadastroDeUsuarios.API.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly CadastroDeUsuariosContext _context;

        public UsuariosRepositorio(CadastroDeUsuariosContext context)
        {
            _context = context;
        }

        public void Alterar(Usuarios usuarios)
        {
            _context.Entry(usuarios).State = EntityState.Modified;
        }

        public void Excluir(Usuarios usuarios)
        {
            _context.Usuarios.Remove(usuarios);
        }

        public void Incluir(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Usuarios> SelecionarByPk(int id)
        {
            return await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync(); ;
        }

        public async Task<IEnumerable<Usuarios>> SelecionarTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
