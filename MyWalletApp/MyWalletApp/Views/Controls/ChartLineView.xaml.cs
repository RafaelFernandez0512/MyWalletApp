using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWalletApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartLineView : ContentView
    {
        public static readonly BindableProperty ChartLineProperty = BindableProperty.Create(nameof(ChartLine),typeof(IEnumerable<ChartEntry>), typeof(ChartLineView),propertyChanged: ChartLinePropertyChanged);
        public IEnumerable<ChartEntry> ChartLine 
        {
            get =>(IEnumerable<ChartEntry>)GetValue(ChartLineProperty); 
            set=>SetValue(ChartLineProperty,value);
        }    
        private static void ChartLinePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ChartLineView control)) return;
            var items = (IEnumerable<ChartEntry>)newValue;
            var chart = new LineChart()
            {
                Entries = items,
                BackgroundColor = SkiaSharp.SKColor.Parse("#2C0E82"),
                LineMode = LineMode.Spline,
                LineSize = 12,
                LabelTextSize = 24,
                LabelOrientation =Orientation.Horizontal,
                PointSize = 0,
                EnableYFadeOutGradient =true,
               ValueLabelOrientation=Orientation.Horizontal,
               LabelColor=SkiaSharp.SKColor.Parse("#5E29F2")

            };
            control.chartline.Chart = chart;
        }
        //
        public ChartLineView()
        {
            InitializeComponent();

        }
    }
}