using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkiaSharp;

namespace IssueCanvas.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public SKPicture? _picture;

    [ObservableProperty]
    public string _content = "Load";

    [RelayCommand]
    private void LoadPicture()
    {
        if (Picture == null)
        {
            using (var fs = new FileStream("serialized.skp", FileMode.Open))
            {
                Picture = SKPicture.Deserialize(fs);
            }

            Content = "Unload";
        }
        else
        {
            Picture.Dispose();
            Picture = null;

            Content = "Load";
        }
    }
}
