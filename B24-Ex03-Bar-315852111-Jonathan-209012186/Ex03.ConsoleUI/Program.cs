using Ex03.ConsoleUI;

class Program
{
    static void Main()
    {
        try
        {
            GarageApplication jbGarageApplication = new();
            jbGarageApplication.RunGarageManagementSystem();
        }
        catch (Exception ex)
        {
            ConsoleUI.PrintFeedback(ex.Message);
        }
    }
}