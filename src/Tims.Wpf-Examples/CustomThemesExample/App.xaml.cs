using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomThemesExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SetAppTheme("Light", Colors.DarkBlue);
        }

        public static void SetAppTheme(string baseTheme, Color accent)
        {
            var theme = new Theme("MyTheme",
                                    "MyTheme",
                                    baseTheme ?? ThemeManager.BaseColorLightConst,
                                    accent.ToString(),
                                    accent,
                                    new SolidColorBrush(accent),
                                    true,
                                    false);

            var HsvAccent = new HSVColor(accent);

            var newBrush = new SolidColorBrush(new HSVColor(HsvAccent.Hue + 180,
                                                                HsvAccent.Saturation,
                                                                HsvAccent.Value).ToColor());

            newBrush.Freeze();
            App.Current.Resources["My.Brushes.Complementary"] = newBrush;
            ;

            ThemeManager.Current.ChangeTheme(App.Current, theme);
        }
    }
}
