using TFLAppHandcoded.Dictionary;
namespace TFLAppHandcoded;

class Program
{
    static void Main(string[] args)
    {
            Menu networkMenu=new Menu();

            networkMenu.Display_menu();

            int menuOperation=networkMenu.Tfl_menu();

            networkMenu.StartJourney(menuOperation);

    }
}

