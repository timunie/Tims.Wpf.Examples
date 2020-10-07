using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DelayShowProgressExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Setup the time
            beginShowProgressTimer = new DispatcherTimer(DispatcherPriority.Input, Dispatcher);
            beginShowProgressTimer.Tick += BeginShowProgressTimer_Tick;
        }

        private async void BeginShowProgressTimer_Tick(object sender, EventArgs e)
        {
            beginShowProgressTimer.Stop();
            AppendText("timer stopped");
            dialogController = await this.ShowProgressAsync("Hi", "Here I am :-)");
            AppendText("progress shown");
            dialogController.SetIndeterminate();
        }

        private DispatcherTimer beginShowProgressTimer;
        private ProgressDialogController dialogController;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearText();

            beginShowProgressTimer.Interval = TimeSpan.FromSeconds(NUD_ShowProgressDelay.Value ?? 0);

            AppendText($"set timer to {NUD_ShowProgressDelay.Value} second(s)");

            beginShowProgressTimer.Start();

            AppendText("timer started");

            // Run our Process
            AppendText($"process started and will run {NUD_TaskDuration.Value} Second(s)");
            await Task.Delay(TimeSpan.FromSeconds(NUD_TaskDuration.Value ?? 1));
            AppendText("process finished");

            // Esure we stop the timer 
            beginShowProgressTimer.Stop();
            AppendText("timer stopped");

            // If we have the dialog close it.
            if (dialogController != null)
            {
                await dialogController.CloseAsync();
                AppendText("dialog closed");
                dialogController = null;
                AppendText("dialog set to 'null'");
            }
        }

        private void AppendText(string text)
        {
            var action = new Action(() => TXT_Output.AppendText($"{DateTime.Now}: {text}{Environment.NewLine}"));
            Dispatcher.BeginInvoke(DispatcherPriority.Send, action);
        }

        private void ClearText()
        {
            var action = new Action(() => TXT_Output.SetCurrentValue(TextBox.TextProperty, null));
            Dispatcher.BeginInvoke(DispatcherPriority.Send, action);
        }
    }
}
