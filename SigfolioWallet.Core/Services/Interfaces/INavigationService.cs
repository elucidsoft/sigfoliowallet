﻿namespace SigfolioWallet.Core.Services.Interfaces
{
    public interface INavigationService
    {
        void NavigatePath(NavigationPath navigationPath);

        string Title { get; set; }
    }
}