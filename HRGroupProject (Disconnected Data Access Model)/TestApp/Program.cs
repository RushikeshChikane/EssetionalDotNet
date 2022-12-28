using DAL;
using BOL;
using UI;


int masterChoice;
do
{

    Console.WriteLine("Welcome to Transflower Learning Platform");
    Console.WriteLine("--------------------------------");
    DisplayManager.ShowMainMenu();
    Console.WriteLine("--------------------------------");
    masterChoice = int.Parse(Console.ReadLine());
    int choice = 0;
    switch (masterChoice)
    {
        //Department Choice
        case 1:
            {
                do
                {
                    DisplayManager.ShowDepartmentMenu();
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            DisplayManager.ShowAllDepartments();
                            break;
                        case 2:
                            DisplayManager.ShowDepartmentById();
                            break;
                        case 3:
                            DisplayManager.InertDepartment();
                            break;
                        case 4:
                            DisplayManager.UpdateDepartment();
                            break;
                        case 5:
                            DisplayManager.DeleteDipartment();
                            break;
                        case 0:
                            Console.WriteLine("***Going Back***");
                            break;
                        default:
                            Console.WriteLine("Please Choose Correct Option");
                            break;
                    }

                }
                while (choice != 0);
            }
            break;

        //Employee Choice
        case 2:
            {

            }
            break;

    }




}
while (masterChoice != 0);

