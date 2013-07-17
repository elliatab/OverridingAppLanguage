using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace OverridingAppLanguage
{    
    partial class MainPage : Page
    {
        private static int index;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.ApplicationModel.Resources.Core.ResourceManager.Current.DefaultContext.QualifierValues.MapChanged -= QualifierValues_MapChanged;
      
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {                
                this.Index.Text = e.Parameter.ToString();
            }
            Windows.ApplicationModel.Resources.Core.ResourceManager.Current.DefaultContext.QualifierValues.MapChanged += QualifierValues_MapChanged;
      
            base.OnNavigatedTo(e);
        }

        private void QualifierValues_MapChanged(IObservableMap<string, string> sender, IMapChangedEventArgs<string> e)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.Frame.Navigate(typeof(MainPage), index++));
        }

        private void SetFrench(object sender, RoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "fr";
        }

        private void SetEnglish(object sender, RoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "en";
        }
    }
}
