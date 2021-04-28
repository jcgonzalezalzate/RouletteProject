namespace RouletteProject.ApiRest.Models
{
    public class RedisConfiguration
    {
        public string ConnectionStringAdmin => $"{ConnectionStringTxn},allowAdmin=true";

        public string ConnectionStringTxn { get; internal set; }

        public override string ToString()
        {
            return $"{ConnectionStringTxn}";
        }
    }
}
