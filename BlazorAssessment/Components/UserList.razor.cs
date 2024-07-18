using BlazorAssessment.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorAssessment.Components
{
    public partial class UserList : ComponentBase
    {
        // Parameter to pass a callback function to the component. 
        // This callback will be invoked when a user is selected.
        [Parameter]  public EventCallback<User> OnUserSelected { get; set; }
        // Parameter to pass a list of users to the component. 
        // Initialized to an empty list to prevent null reference issues.
        [Parameter]  public List<User> Users { get; set; } = new List<User>();

        // Method to handle user click events.
        // It is invoked when a user clicks on a user card.
        private async Task HandleUserClick(User user)
        {
            // Invoke the OnUserSelected callback asynchronously with the selected user.
            await OnUserSelected.InvokeAsync(user);
        }
    }
}