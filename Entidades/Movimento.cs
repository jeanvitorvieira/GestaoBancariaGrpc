namespace Entidades
{
    public record InserirMovimentoDto(int ContaBancariaId, decimal Valor, EnumTipoMovimento TipoMovimento, string Descricao);
    public record ExtratoDto(ContaBancaria Conta, List<Movimento> Movimentos);
    
    public class Movimento
    {
        public int Id { get; set; }
        public int ContaBancariaId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ContaBancaria ContaBancaria { get; set; } = null!;
        public decimal Valor { get; set; }
        public EnumTipoMovimento TipoMovimento { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }

    public enum EnumTipoMovimento
    {
        Entrada,
        Saida
    }
}