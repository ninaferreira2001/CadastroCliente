using CadastroClientes.Data;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Repository
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _context.Cliente
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
           await _context.Cliente.AddAsync(cliente);
           await _context.SaveChangesAsync();

            return cliente;
        }
        public async Task<Cliente> UpdateCliente(Cliente clienteAlterado)
        {
            _context.Entry(clienteAlterado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return clienteAlterado;
        }
        public async void DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
