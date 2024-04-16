namespace GuessTheNumber.Services.Abstractions
{
    public interface IGenerateNumberService
    {
        Random Random { get; }
        int Generate(int startRage, int endRange);
    }
}
