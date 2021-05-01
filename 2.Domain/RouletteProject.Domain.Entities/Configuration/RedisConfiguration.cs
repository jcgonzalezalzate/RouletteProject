namespace RouletteProject.Domain.Entities.Configuration
{
    public class RedisConfiguration
    {
        public string ConnectionStringAdmin => $"{ConnectionStringTxn},allowAdmin=true";

        public string ConnectionStringTxn { get; set; }

        public override string ToString()
        {
            return $"{ConnectionStringTxn}";
        }
    }
}
