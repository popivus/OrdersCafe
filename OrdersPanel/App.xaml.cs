using System.Windows;
using OrdersPanel.Settings;
using RequestHelper.Helpers;

namespace OrdersPanel
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Start app event void
        /// </summary>
        /// <param name="sender">App</param>
        /// <param name="e">StartupEventArgs</param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            RequestHelper.Helpers.RequestHelper.SetConfiguration(new RequestHelperConfiguration(ApiSettings.Path));
        }
    }
}