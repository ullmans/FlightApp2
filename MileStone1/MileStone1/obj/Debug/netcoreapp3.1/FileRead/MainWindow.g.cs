﻿#pragma checksum "..\..\..\..\fileRead\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A7B6FCC56E0CC581DEDC11EE7F70B0D0DB3FC380"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MileStone1 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_dataFilePath;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_browseData;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_dataLoadState;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_definitionsFilePath;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_browseDefinitions;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_definitionsLoadState;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\fileRead\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_start;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MileStone1;component/fileread/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\fileRead\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.t_dataFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.b_browseData = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\fileRead\MainWindow.xaml"
            this.b_browseData.Click += new System.Windows.RoutedEventHandler(this.b_browseData_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.t_dataLoadState = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.t_definitionsFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.b_browseDefinitions = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\fileRead\MainWindow.xaml"
            this.b_browseDefinitions.Click += new System.Windows.RoutedEventHandler(this.b_browseDefinitions_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.t_definitionsLoadState = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.b_start = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\fileRead\MainWindow.xaml"
            this.b_start.Click += new System.Windows.RoutedEventHandler(this.b_start_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

