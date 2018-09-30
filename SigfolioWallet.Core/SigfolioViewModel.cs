using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using MvvmCross.ViewModels;

namespace SigfolioWallet.Core
{
    public class SigfolioViewModel : MvxViewModel
    {
        public string Title { get; set; }

        public string Key { get; set; }
        
    }
}
