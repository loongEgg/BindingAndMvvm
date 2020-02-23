using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace WorkFlowDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(
                "Start a new work flow" + Environment.NewLine
                + "What you want to say?");

            string msg = Console.ReadLine();

            Dictionary<string, object> wfArgs = new Dictionary<string, object>
            {
                { "MessageToShow", msg }
            };

            Activity workflow1 = new Workflow1();
            WorkflowInvoker.Invoke(workflow1, wfArgs);
            Console.ReadLine();
            Console.WriteLine("Thanks for play");
            */

            try
            {
                Dictionary<string, object> wfArgs = new Dictionary<string, object>
                {
                    { "UserName", "King" }
                };

                Activity activity = new Activity1();
                WorkflowInvoker.Invoke(activity, wfArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data["Reason"]);
            }
        }
    }
}
