﻿#pragma checksum "..\..\..\..\..\Views\Client\CreateOrderClient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5F474A8E593FEF6B6ADC9D129481214BCE17E472"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DB_CourseProject.Views.Client;
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


namespace DB_CourseProject.Views.Client {
    
    
    /// <summary>
    /// CreateOrderClient
    /// </summary>
    public partial class CreateOrderClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeAppliance;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginText;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Model;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox servicePack;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid serviceDG;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddOrder;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderDescription;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DB_CourseProject;component/views/client/createorderclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            ((DB_CourseProject.Views.Client.CreateOrderClient)(target)).Loaded += new System.Windows.RoutedEventHandler(this.CreateOrderWindow_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.typeAppliance = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            this.typeAppliance.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.typesText_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.loginText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 68 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.exit = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            this.exit.Click += new System.Windows.RoutedEventHandler(this.exit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Model = ((System.Windows.Controls.ComboBox)(target));
            
            #line 79 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            this.Model.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Model_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.servicePack = ((System.Windows.Controls.ComboBox)(target));
            
            #line 88 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            this.servicePack.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.servicePack_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.serviceDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.AddOrder = ((System.Windows.Controls.Button)(target));
            
            #line 162 "..\..\..\..\..\Views\Client\CreateOrderClient.xaml"
            this.AddOrder.Click += new System.Windows.RoutedEventHandler(this.AddOrder_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.OrderDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

