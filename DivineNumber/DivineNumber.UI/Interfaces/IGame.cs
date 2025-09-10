namespace DivineNumber.UI.Interfaces;

public interface IGame
{
    public void StartGame();
    public bool IsInSpot(string userInput);
    public bool IsWrong(string userInput);
    public bool IsNotInRange(string userInput);
    public void DefineCommand(string userInput);
    public void AfterVictory(string userInput);
    
}