using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteMvvm.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InteractiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalSoundPage : BaseContentPage
    {
        public LocalSoundPage()
        {
            InitializeComponent();
            var image = new Image();
            
        }
    }
}