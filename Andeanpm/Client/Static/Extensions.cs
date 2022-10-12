using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Andeanpm.Client.Static
{
    public static class Extensions
    {
        public static ValueTask NavigateToFragmentAsync(this NavigationManager navigationManager, IJSRuntime jSRuntime)
        {
            var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);

            if (uri.Fragment.Length == 0)
            {
                return default;
            }
            return jSRuntime.InvokeVoidAsync("CustomFunctions.scrollToFragment", uri.Fragment.Substring(1));
        }
    }
}
