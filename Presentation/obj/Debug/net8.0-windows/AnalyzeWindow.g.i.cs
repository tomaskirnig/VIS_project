﻿#pragma checksum "..\..\..\AnalyzeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9FCAFAFABE6779EE4108781C188F4DDD250DF4E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using Presentation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Presentation {
    
    
    /// <summary>
    /// AnalyzeWindow
    /// </summary>
    public partial class AnalyzeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel HeaderPanel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GamesCountText;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PlayersCountText;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AveragePriceText;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NumberOfSoldGamesText;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TopFiveRatingsText;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart GenreDistributionChart;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart PurchasesOverTimeChart;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AnalyzeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.PieChart PlatformDistributionChart;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Presentation;V1.0.0.0;component/analyzewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AnalyzeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HeaderPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            
            #line 21 "..\..\..\AnalyzeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExportPlainTextButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\AnalyzeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExportCsvButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GamesCountText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.PlayersCountText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.AveragePriceText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.NumberOfSoldGamesText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TopFiveRatingsText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.GenreDistributionChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 10:
            this.PurchasesOverTimeChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 11:
            this.PlatformDistributionChart = ((LiveCharts.Wpf.PieChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

