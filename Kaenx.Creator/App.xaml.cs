﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kaenx.Creator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string FilePath = "";

        public App()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            this.Startup += Application_Startup;

            void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
                if (e.Exception is System.Windows.Markup.XamlParseException) return;

                string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);

                if(Kaenx.Creator.Properties.Settings.Default.isDebug)
                    errorMessage += "\r\n\r\n" + e.Exception.StackTrace;

                MessageBox.Show(errorMessage, Kaenx.Creator.Properties.Messages.global_exception_title, MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(Kaenx.Creator.Properties.Messages.global_exception, Kaenx.Creator.Properties.Messages.global_exception_title, MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
		{
			if(e.Args?.Length > 0)
                FilePath = e.Args[0];
		}
    }
}
