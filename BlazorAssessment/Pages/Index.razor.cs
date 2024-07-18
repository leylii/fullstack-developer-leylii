using BlazorAssessment.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAssessment.Pages
{
    public partial class Index : ComponentBase
    {
        private List<User> users = new();

        // Variable to store the currently selected user: this variable is sent to UserDetails component when a user is selected. 
        private User? selectedUser;
        private bool showModal = false;


        protected override async Task OnInitializedAsync()
        {
            // Simulate fetching a list of users (could be from a database or API in a real scenario)
            users = new List<User>
        {
            new User { UserName = "JohnDoe", UserEmail = "john@example.com", LastLoginDate = DateTime.Now.AddDays(-1) },
            new User { UserName = "Leila", UserEmail = "john@example.com", LastLoginDate = DateTime.Now.AddDays(-4) },
            new User { UserName = "Maryam", UserEmail = "john@example.com", LastLoginDate = DateTime.Now.AddDays(-3) },
            new User { UserName = "Mohammad Reza", UserEmail = "john@example.com", LastLoginDate = DateTime.Now.AddDays(-2) },
            new User { UserName = "Hamideh", UserEmail = "john@example.com", LastLoginDate = DateTime.Now.AddDays(-3) },
            new User { UserName = "Sara", UserEmail = "john@example.com", LastLoginDate = DateTime.Now.AddDays(-7) },
            new User { UserName = "Julia", UserEmail = "jane@example.com", LastLoginDate = DateTime.Now.AddDays(-8) }
        };
        }

        // Method that set the UserDetails input parameter and active the modal
        private void ShowUserDetails(User user)
        {
            selectedUser = user;  // Set the selected user
            showModal = true;     // Set the flag to show the modal
        }

        // Method to close the modal and clear the selected user
        private void CloseModal()
        {
            selectedUser = null;  // Clear the selected user
            showModal = false;    // Set the flag to hide the modal
        }
    }
}
