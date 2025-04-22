using System;
using System.Web;

using ArmDot.Client;

[assembly: EmbedFile(SourcePath: "file_content.txt", RuntimePath: @"$(AssemblyDirectory)\embedded_file.txt")]

[assembly: ArmDot.Client.VirtualizeCode]

namespace SimpleModule
{
    public class SimpleModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            app.Context.Response.Write("<p>SimpleModule: BeginRequest triggered !</p>");
        }

        public void Dispose()
        {
            // Clean-up code if needed
        }
    }
}