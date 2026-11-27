using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace RefaccionariaDesktop;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        DispatcherUnhandledException += OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += OnDomainUnhandledException;
        base.OnStartup(e);
    }

    private static string LogPath
    {
        get
        {
            var directory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "RefaccionariaDesktop");
            Directory.CreateDirectory(directory);
            return Path.Combine(directory, "startup-errors.log");
        }
    }

    private static void WriteLog(Exception exception)
    {
        try
        {
            File.AppendAllText(LogPath,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {exception}\r\n\r\n",
                Encoding.UTF8);
        }
        catch
        {
            // Logging must never hide the original startup failure.
        }
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        WriteLog(e.Exception);
        MessageBox.Show(
            $"Refaccionaria Desktop encontró un error y no pudo continuar.\n\n" +
            $"{e.Exception.Message}\n\n" +
            $"Se guardó el detalle en:\n{LogPath}",
            "Error al iniciar Refaccionaria Desktop",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
        e.Handled = true;
        Shutdown(-1);
    }

    private static void OnDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception exception)
            WriteLog(exception);
    }
}