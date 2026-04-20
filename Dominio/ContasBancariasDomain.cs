using Entidades;
using Repositorio;

namespace Dominio
{
    public class ContasBancariasDomain
    {
        private readonly ContasBancariasRepository _contasBancariasRepository;

        public ContasBancariasDomain(ContasBancariasRepository repository)
        {
            _contasBancariasRepository = repository;
        }

        public async Task InserirAsync(ContaBancaria contaBancaria)
        {
            if (string.IsNullOrWhiteSpace(contaBancaria.Titular))
                throw new Exception("Falta informar o titular.");

            if (string.IsNullOrWhiteSpace(contaBancaria.NumeroConta))
                throw new Exception("Falta informar o número da conta.");

            await _contasBancariasRepository.InserirAsync(contaBancaria);
        }

        public async Task<List<ContaBancaria>> BuscarContasAsync()
            => await _contasBancariasRepository.BuscarContasAsync();

        public async Task<ContaBancaria> BuscarContaPorIdAsync(int id)
            => await _contasBancariasRepository.BuscarContaPorIdAsync(id);

        public async Task DeletarAsync(int id)
            => await _contasBancariasRepository.DeletarAsync(id);

        public async Task<ExtratoDto> BuscarExtratoAsync(int contaId)
        {
            var conta = await _contasBancariasRepository.BuscarContaPorIdAsync(contaId);
            var movimentos = await _contasBancariasRepository.BuscarMovimentosPorContaAsync(contaId);
            return new ExtratoDto(conta, movimentos);
        }

        public async Task InserirMovimentoAsync(Movimento movimento)
        {
            if (movimento.Valor <= 0)
                throw new Exception("O valor do movimento deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(movimento.Descricao))
                throw new Exception("Falta informar a descrição do movimento.");

            var conta = await _contasBancariasRepository.BuscarContaPorIdAsync(movimento.ContaBancariaId);

            switch (movimento.TipoMovimento)
            {
                case EnumTipoMovimento.Saida when conta.Saldo < movimento.Valor:
                    throw new Exception("Saldo insuficiente.");
                case EnumTipoMovimento.Saida:
                    conta.Saldo -= movimento.Valor;
                    break;
                default:
                    conta.Saldo += movimento.Valor;
                    break;
            }

            movimento.ContaBancaria = conta;
            await _contasBancariasRepository.InserirMovimentoAsync(movimento);
        }
    }
}