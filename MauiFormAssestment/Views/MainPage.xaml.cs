using MauiFormAssestment.Data;

namespace MauiFormAssestment.Views;

public partial class MainPage : ContentPage
{
    private EntryDatabase _db;

    public MainPage(EntryDatabase db)
    {
        InitializeComponent();
        _db = db;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadEntries();
    }

    private async Task LoadEntries()
    {
        var entries = await _db.GetEntriesAsync();
        EntriesView.ItemsSource = entries;
    }

    async void AddEntry_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEntryPage(_db));
    }

    async void EntriesView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is MauiFormAssestment.Models.Entry selectedEntry)
        {
            await Navigation.PushAsync(new ViewEntryPage(_db, selectedEntry));
            EntriesView.SelectedItem = null;
        }
    }

}