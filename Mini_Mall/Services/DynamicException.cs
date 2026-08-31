namespace Fitness_ClubV1.Services
{
    public class DynamicException: Exception
    {
        private string Exname { get; }
        public DynamicException(string exname, string exmessage) : base(exmessage)
        {
            Exname = exname;
        }

        public override string ToString()
        {
            return $"{Exname}: {base.Message}";
        }
    }
}
