using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace Voo.University.Sharepoint
{
    /// <summary>
    /// Generate statement report menu item.
    /// </summary>
    public class StatementReportMenuItem : WebControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void OnClick(Object sender, EventArgs e)
        {
            SPListItem item = GetCurrentItem();

        }

        private SPListItem GetCurrentItem()
        {
            return null;
        }
    }
}
