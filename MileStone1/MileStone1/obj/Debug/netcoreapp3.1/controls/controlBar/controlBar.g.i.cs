﻿#pragma checksum "..\..\..\..\..\controls\controlBar\controlBar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24B8277ED17B12B6B53E0ABDF0DB91E2476AA550"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MileStone1.controls;
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


namespace MileStone1.controls {
    
    
    /// <summary>
    /// ControlBar
    /// </summary>
    public partial class ControlBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_start;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_slowDown;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_pause;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_play;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_speedUp;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_end;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock t_playSpeed;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock t_progress;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider progressBar;
        
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
            System.Uri resourceLocater = new System.Uri("/MileStone1;component/controls/controlbar/controlbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
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
            this.b_start = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.b_start.Click += new System.Windows.RoutedEventHandler(this.b_start_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.b_slowDown = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.b_slowDown.Click += new System.Windows.RoutedEventHandler(this.b_slowDown_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.b_pause = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.b_pause.Click += new System.Windows.RoutedEventHandler(this.b_pause_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.b_play = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.b_play.Click += new System.Windows.RoutedEventHandler(this.b_play_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.b_speedUp = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.b_speedUp.Click += new System.Windows.RoutedEventHandler(this.b_speedUp_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.b_end = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.b_end.Click += new System.Windows.RoutedEventHandler(this.b_end_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.t_playSpeed = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.t_progress = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.progressBar = ((System.Windows.Controls.Slider)(target));
            
            #line 33 "..\..\..\..\..\controls\controlBar\controlBar.xaml"
            this.progressBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SliderValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

