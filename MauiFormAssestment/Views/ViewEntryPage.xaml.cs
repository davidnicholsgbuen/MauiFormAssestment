using MauiFormAssestment.Data;
using EntryModel = MauiFormAssestment.Models.Entry;

namespace MauiFormAssestment.Views;

public partial class ViewEntryPage : ContentPage
{
    private EntryDatabase _db;

    private EntryModel _entry;

    public ViewEntryPage(EntryDatabase db, EntryModel entry)
    {
        InitializeComponent();

        _db = db;
        _entry = entry;

        LblID.Text = $"ID: {entry.EntryID}";
        LblFirstName.Text = $"First Name: {entry.FirstName}";
        LblLastName.Text = $"Last Name: {entry.LastName}";
        LblBirthDate.Text = $"Birthdate: {entry.DateOfBirth:MMMM dd, yyyy}";
    }

    async void Delete_Clicked(object sender, EventArgs e)
    {
        //bool confirm = await DisplayAlert("Confirm", "Delete this entry?", "Yes", "No");
        //if (!confirm) return;

        // Delete entry from SQLite
        await _db.DeleteEntryAsync(_entry);

        // Toast message (if CommunityToolkit is installed)
        // await Toast.Make("Entry deleted.").Show();

        // Return to MainPage (which auto-refreshes in OnAppearing)
        await Navigation.PopAsync();
    }
}