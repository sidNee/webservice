using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContract;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Frontend
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            var value1 = Convert.ToDouble(TextBox1.Text);
            var value2 = Convert.ToDouble(TextBox2.Text);

            var job = new CalcJob { Id = Guid.NewGuid(), Value1 = value1, Value2 = value2 };

            var account = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"));

            var client = account.CreateCloudQueueClient();

            var queue = client.GetQueueReference("calc");
            queue.CreateIfNotExists();

            var serializeJob = CalcJobSerializer.Serialize(job);
            CloudQueueMessage message = new CloudQueueMessage((serializeJob));
            queue.AddMessage(message);

            Response.Redirect("Result.aspx?id=" + job.Id);
        }
    }
}