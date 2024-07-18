using BlazorAssessment.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAssessment.Components
{
    public partial class UserDetails : ComponentBase
    {
        [Parameter] public required User SelectedUser { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        private async Task CloseModal()
        {
            await OnClose.InvokeAsync();
        }
    }   
}
