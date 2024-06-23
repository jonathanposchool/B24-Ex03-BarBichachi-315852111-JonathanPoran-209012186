using Ex03.ConsoleUI;

// TODO:
/*
 * unused variables
 * unused get/sets
 * seald/public/protected/internal/private
 * usage of necessary things such as string format, etc
 */

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