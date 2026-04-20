using Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Infra;

namespace Repositorio
{
    public class ContasBancariasRepository
    {
        private readonly DataContext _dataContext;

        public ContasBancariasRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InserirAsync(ContaBancaria contaBancaria)
        {
            _dataContext.Add(contaBancaria);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<ContaBancaria>> BuscarContasAsync()
        {
            return await _dataContext.ContasBancarias.ToListAsync();
        }

        public async Task<ContaBancaria> BuscarContaPorIdAsync(int id)
        {
            return await _dataContext.ContasBancarias.FindAsync(id)
                   ?? throw new Exception($"Conta com id {id} não encontrada.");
        }

        public async Task DeletarAsync(int id)
        {
            var conta = await _dataContext.ContasBancarias.FindAsync(id);
            if (conta == null) return;
            _dataContext.ContasBancarias.Remove(conta);
            await _dataContext.SaveChangesAsync();
        }

        public async Task InserirMovimentoAsync(Movimento movimento)
        {
            _dataContext.Movimentos.Add(movimento);
            _dataContext.ContasBancarias.Update(movimento.ContaBancaria);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Movimento>> BuscarMovimentosPorContaAsync(int contaId)
        {
            return await _dataContext.Movimentos
                .Where(m => m.ContaBancariaId == contaId)
                .ToListAsync();
        }
    }
}