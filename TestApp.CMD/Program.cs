using System.Resources;
using TestApp.BL.Controller;

namespace TestApp.CMD
{
    class Program
    {
        public static void Main(string[] args)
        {
            ResourceManager resourceManager = new ResourceManager("TestApp.CMD.Languages.Messages", typeof(Program).Assembly);
            MessageInteractionController mic = new MessageInteractionController();
            mic.StartMainController(resourceManager);
        }
    }
}