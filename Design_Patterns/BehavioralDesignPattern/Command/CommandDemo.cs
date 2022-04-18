using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Command
{
    public static class CommandDemo
    {
        public static void Run()
        {
            Document document = new Document();
            ICommand openCommand = new OpenCommand(document);
            ICommand saveCommand = new SaveCommand(document);
            ICommand closeCommand = new CloseCommand(document);
            MenuOptions menu = new MenuOptions(openCommand, saveCommand, closeCommand);
            menu.clickOpen();
            menu.clickSave();
            menu.clickClose();
            Console.ReadKey();
        }
    }
}
