using System;

namespace Voo.Migration
{
    public static class UIUtility
    {
        public static void RenderBorder()
        {
            Console.WriteLine();
            for(int i = 0; i < 60; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        public static void RenderTaskWelcome(String taskNumber)
        {
            Console.WriteLine("Update version: {0}", taskNumber);
            Console.WriteLine();
        }

        public static String GetSiteUrl()
        {
            Console.WriteLine("Site Url(for example: http://localhost/): ");
            return Console.ReadLine();
        }
    }
}