﻿#pragma checksum "C:\Users\p\source\repos\map\pagekoordynaty.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3EB9E95EDDE767875DBB878A62A7DFE5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace map
{
    partial class pagekoordynaty : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // pagekoordynaty.xaml line 15
                {
                    this.boxlocation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // pagekoordynaty.xaml line 18
                {
                    this.boxdestination = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // pagekoordynaty.xaml line 19
                {
                    this.btnpow = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5: // pagekoordynaty.xaml line 20
                {
                    this.btnszuk = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnszuk).Click += this.btnszuk_Click;
                }
                break;
            case 6: // pagekoordynaty.xaml line 23
                {
                    this.im1 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 7: // pagekoordynaty.xaml line 24
                {
                    this.im2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

