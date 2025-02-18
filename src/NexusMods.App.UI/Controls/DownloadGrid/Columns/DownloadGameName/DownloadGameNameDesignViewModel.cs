using System.Reactive.Disposables;
using NexusMods.Abstractions.UI;
using NexusMods.App.UI.Controls.DataGrid;
using NexusMods.App.UI.Pages.Downloads.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace NexusMods.App.UI.Controls.DownloadGrid.Columns.DownloadGameName;

public class DownloadGameNameDesignViewModel : AViewModel<IDownloadGameNameViewModel>, IDownloadGameNameViewModel, IComparableColumn<IDownloadTaskViewModel>
{
    [Reactive]
    public IDownloadTaskViewModel Row { get; set; } = new DownloadTaskDesignViewModel();

    [Reactive]
    public string Game { get; set; } = "";

    public DownloadGameNameDesignViewModel()
    {
        this.WhenActivated(d =>
        {
            this.WhenAnyValue(vm => vm.Row.Game)
                .BindToVM(this, vm => vm.Game)
                .DisposeWith(d);
        });
    }
    
    public int Compare(IDownloadTaskViewModel a, IDownloadTaskViewModel b) => String.Compare(a.Game, b.Game, StringComparison.Ordinal);
}
