using MauiFormAssestment.Data;

using EntryModel = MauiFormAssestment.Models.Entry;

namespace MauiFormAssestment.Views;

public partial class AddEntryPage : ContentPage
{
    private EntryDatabase _db;
    public AddEntryPage(EntryDatabase db)
	{
		InitializeComponent();
        _db = db;
    }
    async void Add_Clicked(object sender, EventArgs e)
    {
        // Validate required fields
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LastNameEntry.Text))
        {
            await DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        }

        // Explicitly convert nullable DateTime? to DateTime
        // (works whether DobPicker.Date is DateTime or DateTime?)
        DateTime dob = (DateTime)DobPicker.Date;

        // Create the model using fully-qualified type to avoid ambiguity with UI Entry control
        var model = new MauiFormAssestment.Models.Entry
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            DateOfBirth = dob
        };

        // Save to SQLite
        await _db.SaveEntryAsync(model);

        // Optional: show a toast if you have CommunityToolkit.Maui configured
        // await CommunityToolkit.Maui.Alerts.Toast.Make("Entry added.").Show();

        // Navigate back to MainPage which will reload list in OnAppearing
        await Navigation.PopAsync();
    }
}