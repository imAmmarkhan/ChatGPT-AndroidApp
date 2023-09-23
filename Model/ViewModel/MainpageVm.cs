using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.Model;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Model.ViewModel
{
    public partial class MainpageVm : ObservableObject
    {
        [ObservableProperty]
        public string question;

        [ObservableProperty]
        public string answer;

        [ObservableProperty]
        public string chatGPTModel;

        [ObservableProperty]
        public string stopReasson;

        [RelayCommand]
        public async Task SearchGPT()   // Testing
        {

            var apiService = new ApiService();
            Root Results = new Root();
            Results = await apiService.ApiResponse(Question);

            var TempResult = new Root();
            TempResult = Results;


            Answer = "Answer is \n" + Results.Text;
            ChatGPTModel = Results.Model;
            StopReasson = Results.FinishReason;
        }
    }
}
