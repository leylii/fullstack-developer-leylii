using BlazorAssessment.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorAssessment.Pages
{
    public partial class UserList : ComponentBase
    {
        [Parameter] public EventCallback<User> OnUserSelected { get; set; }
        [Parameter]
        public List<User> Users { get; set; } = new List<User>();


        //private void SelectUser(User user)
        //{
        //    OnUserSelected.InvokeAsync(user);
        //}
        private async Task HandleUserClick(User user)
        {
            await OnUserSelected.InvokeAsync(user);
        }

      


    }
}
