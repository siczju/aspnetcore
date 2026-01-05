namespace HeroisJWT.Db
{
    public sealed class Poder
    {
        public string Descricao { get; init; }
        public Poder(string descricao)
        {
            Descricao = descricao;
        }
    }
}
