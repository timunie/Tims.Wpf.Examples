using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace testEmbed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
             //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            
        }
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                String resourceName = String.Empty;
                if (args.Name.Split(',')[0].EndsWith(".resources", StringComparison.InvariantCultureIgnoreCase))
                {
                    resourceName = String.Format("testEmbed.Dependencies.{0}.dll", new AssemblyName(args.Name.Split(',')[0]).Name.Replace(".resources", ""));
                    Debug.WriteLine(String.Format("Resource Loading(RESOURCE): {0}", new AssemblyName(args.Name.Split(',')[0]).Name.Replace(".resources", "")));
                }
                else
                {
                    resourceName = String.Format("testEmbed.Dependencies.{0}.dll", new AssemblyName(args.Name.Split(',')[0]).Name);
                }
                Debug.WriteLine(String.Format("Resource Loading: {0}", resourceName));
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                using (var outstream = new MemoryStream())
                {
                    if (stream != null)
                    {
                        CopyTo(stream, outstream);
                        
                        return Assembly.Load(outstream.GetBuffer());
                    }
                    else
                    {
                        Debug.WriteLine(String.Format("Resource Failed: {0}" + Environment.NewLine + "{1}", resourceName, args.Name));
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }
        public static long CopyTo(Stream source, Stream destination)
        {
            byte[] buffer = new byte[2048];
            int bytesRead;
            long totalBytes = 0;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                destination.Write(buffer, 0, bytesRead);
                totalBytes += bytesRead;
            }
            return totalBytes;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //// get the current app style (theme and accent) from the application
            //Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);
            //// now change app style to the custom accent and current theme
            //ThemeManager.ChangeAppStyle(Application.Current,
            //                            ThemeManager.GetAccent("Red"),
            //                            theme.Item1);

            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
