using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.IO;
using Voo.University.Models;

namespace Voo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
//            using (SPSite site = new SPSite("http://localhost/"))
//            {
//                SPList list1 = site.RootWeb.Lists["Test"];
//                SPList list2 = site.RootWeb.Lists["Test2"];

//                SPField testSubjectField = list1.Fields["Test_Subject"];
//                SPField subjectFields = list2.Fields["Subject"];

//                int id = list2.Items[0].ID;

//                SPQuery query = new SPQuery();
//                query.Query = String.Format(@"
//                                <Where>
//                                    <Eq>
//                                        <FieldRef Name='Test_Subject' LookupId='TRUE'/>
//                                        <Value Type='Lookup'>{0}</Value>
//                                    </Eq>
//                                </Where>", id);
//                SPListItemCollection items = list1.GetItems(query);
//                foreach (SPListItem item in items) { System.Console.WriteLine(item.Title); }
//            }
            //using (StreamWriter writer = new StreamWriter(new FileStream("1.txt", FileMode.Create)))
            //{
            //    for (int i = 0; i < 20; i++)
            //    {
            //        writer.WriteLine("0x0100{0}", Guid.NewGuid().ToString().Replace("-", "").ToUpper());
            //    }
            //}

            Group group = new Group(null);

        }
    }
}
