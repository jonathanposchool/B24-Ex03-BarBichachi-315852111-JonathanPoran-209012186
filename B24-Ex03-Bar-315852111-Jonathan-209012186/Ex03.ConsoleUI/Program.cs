using Ex03.ConsoleUI;

// TODO:
/*
 * unused methods/functions
 * unused variables
 * unused get/sets
 * seald/public/protected/internal/private
 * Exceptions
 * Duplications of code (for example fill tire in vehicle and in tire)
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
            ConsoleUI.PrintException(ex.Message);
        }
    }
}